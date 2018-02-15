//----------------------------------------------------------------------------
// MIT License
// 
// Copyright (c) 2017 SSASQueryAnalyzer
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//----------------------------------------------------------------------------


namespace SSASQueryAnalyzer.Client.Common.Infrastructure
{
    using SSASQueryAnalyzer.Client.Common.Infrastructure.AnalysisServices;
    using SSASQueryAnalyzer.Server.Infrastructure;
    using System;
    using System.Linq;

    public class AnalyzerStatistics : IDisposable
    {
        public enum CalculationComputationType
        {
            Block,        
            CellByCell,  
            Mixed,      
            Uncertain   
        }

        #region Consts

        private const string PerformanceCountersCategoryMemory = "Memory";
        private const string PerformanceCountersCategoryMemoryNameMemoryUsageKB = "Memory usage KB";

        private const string PerformanceCountersCategoryCache = "Cache";
        private const string PerformanceCountersCategoryCacheNameTotalLookups = "Total lookups";
        private const string PerformanceCountersCategoryCacheNameTotalInserts = "Total inserts";
        private const string PerformanceCountersCategoryCacheNameTotalMisses = "Total misses";
        private const string PerformanceCountersCategoryCacheNameTotalDirectHits = "Total direct hits";

        private const string PerformanceCountersCategoryMdx = "MDX";
        private const string PerformanceCountersCategoryMdxNameTotalFlatCacheInserts = "Total flat cache inserts";
        private const string PerformanceCountersCategoryMdxNameTotalExisting = "Total EXISTING";
        private const string PerformanceCountersCategoryMdxNameTotalAutoexist = "Total autoexist";
        private const string PerformanceCountersCategoryMdxNameTotalNonEmpty = "Total NON EMPTY";
        private const string PerformanceCountersCategoryMdxNameTotalSonarSubcubes = "Total sonar subcubes";
        private const string PerformanceCountersCategoryMdxNameTotalCellsCalculated = "Total cells calculated";
        private const string PerformanceCountersCategoryMdxNameNumberOfCalculationCovers = "Number of calculation covers";
        private const string PerformanceCountersCategoryMdxNameNumberOfCellByCellEvaluationNodes = "Number of cell-by-cell evaluation nodes";
        private const string PerformanceCountersCategoryMdxNameNumberOfBulkModeEvaluationNodes = "Number of bulk-mode evaluation nodes";

        private const string PerformanceCountersCategoryStorageEngineQuery = "Storage Engine Query";
        private const string PerformanceCountersCategoryStorageEngineQueryNameTotalMeasureGroupQueries = "Total measure group queries";

        #endregion

        private bool _disposed;

        public AnalyzerExecutionResult ColdCacheExecutionResult { get; private set; }
        public AnalyzerExecutionResult WarmCacheExecutionResult { get; private set; }

        public static AnalyzerStatistics CreateFromAnalyzerExecutionResults(AnalyzerExecutionResult coldCacheExecutionResult, AnalyzerExecutionResult warmCacheExecutionResult)
        {
            if (coldCacheExecutionResult == null) throw new ArgumentNullException("coldCacheExecutionResult");
            if (warmCacheExecutionResult == null) throw new ArgumentNullException("warmCacheExecutionResult");

            return new AnalyzerStatistics(coldCacheExecutionResult, warmCacheExecutionResult);
        }

        public static AnalyzerStatistics CreateFromAnalyzerBatchResults(string connectionStringBatch, string batchID)
        {
            var coldCacheExecutionResult = AnalyzerExecutionResult.CreateFromBatch(connectionStringBatch, batchID, ClearCacheMode.Default);
            var warmCacheExecutionResult = AnalyzerExecutionResult.CreateFromBatch(connectionStringBatch, batchID, ClearCacheMode.Nothing);

            return CreateFromAnalyzerExecutionResults(coldCacheExecutionResult, warmCacheExecutionResult);
        }

        private AnalyzerStatistics(AnalyzerExecutionResult coldCacheExecutionResult, AnalyzerExecutionResult warmCacheExecutionResult)
        {
            ColdCacheExecutionResult = coldCacheExecutionResult;
            WarmCacheExecutionResult = warmCacheExecutionResult;
        }

        #region Engine usage

        public float EngineUsageWarmCacheExecutionImprovementPercentage
        {
            get 
            {
                var coldQueryDurationTicks = ColdCacheExecutionResult.EnginePerformances.Sum((p) => p.QueryDuration.Ticks);
                var warmQueryDurationTicks = WarmCacheExecutionResult.EnginePerformances.Sum((p) => p.QueryDuration.Ticks);

                if (coldQueryDurationTicks != 0)
                    return (float)(coldQueryDurationTicks - warmQueryDurationTicks) / coldQueryDurationTicks * 100;

                return 0F;
            }
        }

        public TimeSpan EngineUsageColdCacheQueryDuration
        {
            get
            {
                var ticks = ColdCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.QueryDuration.Ticks);

                return TimeSpan.FromTicks(ticks);
            }
        }

        public TimeSpan EngineUsageWarmCacheQueryDuration
        {
            get
            {
                var ticks = WarmCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.QueryDuration.Ticks);

                return TimeSpan.FromTicks(ticks);
            }
        }

        public TimeSpan EngineUsageColdCacheFormulaEngineDuration
        {
            get
            {
                var ticks = ColdCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.FormulaEngineDuration.Ticks);

                return TimeSpan.FromTicks(ticks);
            }
        }

        public TimeSpan EngineUsageWarmCacheFormulaEngineDuration
        {
            get
            {
                var ticks = WarmCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.FormulaEngineDuration.Ticks);

                return TimeSpan.FromTicks(ticks);
            }
        }

        public TimeSpan EngineUsageColdCacheStorageEngineDuration
        {
            get
            {
                var ticks = ColdCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.StorageEngineDuration.Ticks);

                return TimeSpan.FromTicks(ticks);
            }
        }

        public TimeSpan EngineUsageWarmCacheStorageEngineDuration
        {
            get
            {
                var ticks = WarmCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.StorageEngineDuration.Ticks);

                return TimeSpan.FromTicks(ticks);
            }
        }

        #endregion

        #region Data retrieve

        public CalculationComputationType DataRetrieveColdCacheCalculationComputationType
        {
            get
            {
                var profilerComputationType = CalculationComputationType.Uncertain;
                var performanceComputationType = CalculationComputationType.Uncertain;

                #region Calculate performanceComputationType

                long numberOfCellByCellEvaluationNodes = ColdCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameNumberOfCellByCellEvaluationNodes))
                    .SelectMany((p) => p)
                    .Last().Value;

                long numberOfBlockModeEvaluationNodes = ColdCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameNumberOfBulkModeEvaluationNodes))
                    .SelectMany((p) => p)
                    .Last().Value;

                if (numberOfCellByCellEvaluationNodes > 0 && numberOfBlockModeEvaluationNodes == 0)
                {
                    performanceComputationType = CalculationComputationType.CellByCell;
                }
                else if (numberOfCellByCellEvaluationNodes == 0 && numberOfBlockModeEvaluationNodes > 0)
                {
                    performanceComputationType = CalculationComputationType.Block;
                }
                else if (numberOfCellByCellEvaluationNodes > 0 && numberOfBlockModeEvaluationNodes > 0)
                {
                    performanceComputationType = CalculationComputationType.Mixed;
                }

                #endregion

                #region Calculate profilerComputationType

                int occurance = ColdCacheExecutionResult.Profilers.SelectMany((p) => p)
                    .Where((p) => p.EventClass == TraceEventClass.CalculateNonEmptyEnd)
                    .Count();

                if (occurance > 0)
                {
                    if (ColdCacheExecutionResult.Profilers.SelectMany((p) => p).Where((p) => p.EventClass == TraceEventClass.CalculateNonEmptyEnd).All((p) => p.IntegerData == 11 || p.IntegerData == 12 || p.IntegerData == 13))
                    {
                        profilerComputationType = CalculationComputationType.CellByCell;
                    }
                    else if (ColdCacheExecutionResult.Profilers.SelectMany((p) => p).Where((p) => p.EventClass == TraceEventClass.CalculateNonEmptyEnd).All((p) => p.IntegerData == 1 || p.IntegerData == 2 || p.IntegerData == 3))
                    {
                        profilerComputationType = CalculationComputationType.Block;
                    }
                    else
                    {
                        profilerComputationType = CalculationComputationType.Mixed;
                    }
                }

                #endregion

                if (performanceComputationType == profilerComputationType)
                    return performanceComputationType;

                if (performanceComputationType == CalculationComputationType.Uncertain)
                    return profilerComputationType;

                if (profilerComputationType == CalculationComputationType.Uncertain)
                    return performanceComputationType;
                
                return CalculationComputationType.Mixed;
            }
        }
        public CalculationComputationType DataRetrieveWarmCacheCalculationComputationType
        {
            get
            {
                var profilerComputationType = CalculationComputationType.Uncertain;
                var performanceComputationType = CalculationComputationType.Uncertain;

                #region Calculate performanceComputationType

                long numberOfCellByCellEvaluationNodes = WarmCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameNumberOfCellByCellEvaluationNodes))
                    .SelectMany((p) => p)
                    .Last().Value;

                long numberOfBlockModeEvaluationNodes = WarmCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameNumberOfBulkModeEvaluationNodes))
                    .SelectMany((p) => p)
                    .Last().Value;

                if (numberOfCellByCellEvaluationNodes > 0 && numberOfBlockModeEvaluationNodes == 0)
                {
                    performanceComputationType = CalculationComputationType.CellByCell;
                }
                else if (numberOfCellByCellEvaluationNodes == 0 && numberOfBlockModeEvaluationNodes > 0)
                {
                    performanceComputationType = CalculationComputationType.Block;
                }
                else if (numberOfCellByCellEvaluationNodes > 0 && numberOfBlockModeEvaluationNodes > 0)
                {
                    performanceComputationType = CalculationComputationType.Mixed;
                }

                #endregion

                #region Calculate profilerComputationType

                int occurance = WarmCacheExecutionResult.Profilers.SelectMany((p) => p)
                    .Where((p) => p.EventClass == TraceEventClass.CalculateNonEmptyEnd)
                    .Count();

                if (occurance > 0)
                {
                    if (WarmCacheExecutionResult.Profilers.SelectMany((p) => p).Where((p) => p.EventClass == TraceEventClass.CalculateNonEmptyEnd).All((p) => p.IntegerData == 11 || p.IntegerData == 12 || p.IntegerData == 13))
                    {
                        profilerComputationType = CalculationComputationType.CellByCell;
                    }
                    else if (WarmCacheExecutionResult.Profilers.SelectMany((p) => p).Where((p) => p.EventClass == TraceEventClass.CalculateNonEmptyEnd).All((p) => p.IntegerData == 1 || p.IntegerData == 2 || p.IntegerData == 3))
                    {
                        profilerComputationType = CalculationComputationType.Block;
                    }
                    else
                    {
                        profilerComputationType = CalculationComputationType.Mixed;
                    }
                }

                #endregion

                if (performanceComputationType == profilerComputationType)
                    return performanceComputationType;

                if (performanceComputationType == CalculationComputationType.Uncertain)
                    return profilerComputationType;
                
                if (profilerComputationType == CalculationComputationType.Uncertain)
                    return performanceComputationType;
                
                return CalculationComputationType.Mixed;
            }
        }

        public int DataRetrieveColdCacheTotalRead
        {
            get
            {
                return ColdCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.CachesRead + p.PartitionsRead + p.AggregationsRead);
            }
        }
        public int DataRetrieveWarmCacheTotalRead
        {
            get
            {
                return WarmCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.CachesRead + p.PartitionsRead + p.AggregationsRead);
            }
        }

        public int DataRetrieveColdCacheMeasureGroupCacheRead
        {
            get
            {
                return ColdCacheExecutionResult.Profilers.SelectMany((e) => e)
                    .Count((e) => 
                        e.EventClass == TraceEventClass.GetDataFromCache && 
                        e.EventSubclass == TraceEventSubclass.GetDataFromMeasureGroupCache);
            }
        }
        public int DataRetrieveWarmCacheMeasureGroupCacheRead
        {
            get
            {
                return WarmCacheExecutionResult.Profilers.SelectMany((e) => e)
                    .Count((e) => 
                        e.EventClass == TraceEventClass.GetDataFromCache && 
                        e.EventSubclass == TraceEventSubclass.GetDataFromMeasureGroupCache);
            }
        }

        public int DataRetrieveColdCachePersistedCacheRead
        {
            get
            {
                return ColdCacheExecutionResult.Profilers.SelectMany((e) => e)
                    .Count((e) => 
                        e.EventClass == TraceEventClass.GetDataFromCache && 
                        e.EventSubclass == TraceEventSubclass.GetDataFromPersistedCache);
            }
        }
        public int DataRetrieveWarmCachePersistedCacheRead
        {
            get
            {
                return WarmCacheExecutionResult.Profilers.SelectMany((e) => e)
                    .Count((e) => 
                        e.EventClass == TraceEventClass.GetDataFromCache && 
                        e.EventSubclass == TraceEventSubclass.GetDataFromPersistedCache);
            }
        }

        public int DataRetrieveColdCacheCalculationCacheGlobalScopeRead
        {
            get
            {
                return ColdCacheExecutionResult.Profilers.SelectMany((e) => e)
                    .Count((e) => 
                        e.EventClass == TraceEventClass.GetDataFromCache && 
                        e.EventSubclass == TraceEventSubclass.GetDataFromCalculationCache && 
                        e.TextData.Equals("Global Scope", StringComparison.InvariantCultureIgnoreCase));
            }
        }
        public int DataRetrieveWarmCacheCalculationCacheGlobalScopeRead
        {
            get
            {
                return WarmCacheExecutionResult.Profilers.SelectMany((e) => e)
                    .Count((e) =>
                        e.EventClass == TraceEventClass.GetDataFromCache && 
                        e.EventSubclass == TraceEventSubclass.GetDataFromCalculationCache &&
                        e.TextData.Equals("Global Scope", StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public int DataRetrieveColdCacheCalculationCacheSessionScopeRead
        {
            get
            {
                return ColdCacheExecutionResult.Profilers.SelectMany((e) => e)
                    .Count((e) =>
                        e.EventClass == TraceEventClass.GetDataFromCache && 
                        e.EventSubclass == TraceEventSubclass.GetDataFromCalculationCache &&
                        e.TextData.Equals("Session Scope", StringComparison.InvariantCultureIgnoreCase));
            }
        }
        public int DataRetrieveWarmCacheCalculationCacheSessionScopeRead
        {
            get
            {
                return WarmCacheExecutionResult.Profilers.SelectMany((e) => e)
                    .Count((e) =>
                        e.EventClass == TraceEventClass.GetDataFromCache && 
                        e.EventSubclass == TraceEventSubclass.GetDataFromCalculationCache &&
                        e.TextData.Equals("Session Scope", StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public int DataRetrieveColdCacheCalculationCacheQueryScopeRead
        {
            get
            {
                return ColdCacheExecutionResult.Profilers.SelectMany((e) => e)
                    .Count((e) =>
                        e.EventClass == TraceEventClass.GetDataFromCache &&
                        e.EventSubclass == TraceEventSubclass.GetDataFromCalculationCache &&
                        e.TextData.Equals("Query Scope", StringComparison.InvariantCultureIgnoreCase));
            }
        }
        public int DataRetrieveWarmCacheCalculationCacheQueryScopeRead
        {
            get
            {
                return WarmCacheExecutionResult.Profilers.SelectMany((e) => e)
                    .Count((e) =>
                        e.EventClass == TraceEventClass.GetDataFromCache &&
                        e.EventSubclass == TraceEventSubclass.GetDataFromCalculationCache &&
                        e.TextData.Equals("Query Scope", StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public int DataRetrieveColdCacheFlatCacheRead
        {
            get
            {
                return ColdCacheExecutionResult.Profilers.SelectMany((e) => e)
                    .Count((e) =>
                        e.EventClass == TraceEventClass.GetDataFromCache && 
                        e.EventSubclass == TraceEventSubclass.GetDataFromFlatCache);
            }
        }
        public int DataRetrieveWarmCacheFlatCacheRead
        {
            get
            {
                return WarmCacheExecutionResult.Profilers.SelectMany((e) => e)
                    .Count((e) =>
                        e.EventClass == TraceEventClass.GetDataFromCache && 
                        e.EventSubclass == TraceEventSubclass.GetDataFromFlatCache);
            }
        }

        public int DataRetrieveColdCacheAggregationsRead
        {
            get
            {
                return ColdCacheExecutionResult.EnginePerformances.Single()
                    .AggregationsRead;
            }
        }
        public int DataRetrieveWarmCacheAggregationsRead
        {
            get
            {
                return WarmCacheExecutionResult.EnginePerformances.Single()
                    .AggregationsRead;
            }
        }

        public int DataRetrieveColdCachePartitionsRead
        {
            get
            {
                return ColdCacheExecutionResult.EnginePerformances.Single()
                    .PartitionsRead;
            }
        }
        public int DataRetrieveWarmCachePartitionsRead
        {
            get
            {
                return WarmCacheExecutionResult.EnginePerformances.Single()
                    .PartitionsRead;
            }
        }

        public int DataRetrieveColdCacheAggregationsHit
        {
            get
            {
                return ColdCacheExecutionResult.EnginePerformances.Single()
                    .AggregationsHit;
            }
        }
        public int DataRetrieveWarmCacheAggregationsHit
        {
            get
            {
                return WarmCacheExecutionResult.EnginePerformances.Single()
                    .AggregationsHit;
            }
        }

        public int DataRetrieveColdCachePartitionsHit
        {
            get
            {
                return ColdCacheExecutionResult.EnginePerformances.Single()
                    .PartitionsHit;
            }
        }
        public int DataRetrieveWarmCachePartitionsHit
        {
            get
            {
                return WarmCacheExecutionResult.EnginePerformances.Single()
                    .PartitionsHit;
            }
        }

        #endregion

        #region Resource usage

        public int ResourceUsageColdCacheReads
        {
            get
            {
                return ColdCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.ResourceUsageReads);
            }
        }
        public int ResourceUsageWarmCacheReads
        {
            get
            {
                return WarmCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.ResourceUsageReads);
            }
        }

        public long ResourceUsageColdCacheReadKB
        {
            get
            {
                return ColdCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.ResourceUsageReadKB);
            }
        }
        public long ResourceUsageWarmCacheReadKB
        {
            get
            {
                return WarmCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.ResourceUsageReadKB);
            }
        }

        public int ResourceUsageColdCacheWrites 
        {
            get
            {
                return ColdCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.ResourceUsageWrites);
            }
        }
        public int ResourceUsageWarmCacheWrites 
        {
            get
            {
                return WarmCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.ResourceUsageWrites);
            }
        }

        public long ResourceUsageColdCacheWriteKB
        {
            get
            {
                return ColdCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.ResourceUsageWriteKB);
            }
        }
        public long ResourceUsageWarmCacheWriteKB
        {
            get
            {
                return WarmCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.ResourceUsageWriteKB);
            }
        }

        public long ResourceUsageColdCacheCpuTimeMS
        {
            get
            {
                return ColdCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.ResourceUsageCpuTimeMS);
            }
        }
        public long ResourceUsageWarmCacheCpuTimeMS
        {
            get
            {
                return WarmCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.ResourceUsageCpuTimeMS);
            }
        }

        public int ResourceUsageColdCacheRowsScanned
        {
            get
            {
                return ColdCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.ResourceUsageRowsScanned);
            }
        }
        public int ResourceUsageWarmCacheRowsScanned
        {
            get
            {
                return WarmCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.ResourceUsageRowsScanned);
            }
        }

        public int ResourceUsageColdCacheRowsReturned 
        {
            get
            {
                return ColdCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.ResourceUsageRowsReturned);
            }
        }
        public int ResourceUsageWarmCacheRowsReturned 
        {
            get
            {
                return WarmCacheExecutionResult.EnginePerformances
                    .Sum((p) => p.ResourceUsageRowsReturned);
            }
        }

        #endregion

        #region Performance counters

        public long PerformanceCountersColdCacheMemoryMemoryUsageKB
        {
            get
            {
                return ColdCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMemory) && p.Name.Equals(PerformanceCountersCategoryMemoryNameMemoryUsageKB))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }
        public long PerformanceCountersWarmCacheMemoryMemoryUsageKB
        {
            get
            {
                return WarmCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMemory) && p.Name.Equals(PerformanceCountersCategoryMemoryNameMemoryUsageKB))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }

        public long PerformanceCountersColdCacheCacheTotalLookups
        {
            get
            {
                return ColdCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryCache) && p.Name.Equals(PerformanceCountersCategoryCacheNameTotalLookups))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }
        public long PerformanceCountersWarmCacheCacheTotalLookups
        {
            get
            {
                return WarmCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryCache) && p.Name.Equals(PerformanceCountersCategoryCacheNameTotalLookups))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }

        public long PerformanceCountersColdCacheCacheTotalInserts
        {
            get
            {
                return ColdCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryCache) && p.Name.Equals(PerformanceCountersCategoryCacheNameTotalInserts))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }
        public long PerformanceCountersWarmCacheCacheTotalInserts
        {
            get
            {
                return WarmCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryCache) && p.Name.Equals(PerformanceCountersCategoryCacheNameTotalInserts))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }

        public long PerformanceCountersColdCacheCacheTotalMisses
        {
            get
            {
                return ColdCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryCache) && p.Name.Equals(PerformanceCountersCategoryCacheNameTotalMisses))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }
        public long PerformanceCountersWarmCacheCacheTotalMisses
        {
            get
            {
                return WarmCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryCache) && p.Name.Equals(PerformanceCountersCategoryCacheNameTotalMisses))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }

        public long PerformanceCountersColdCacheCacheTotalDirectHits
        {
            get
            {
                return ColdCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryCache) && p.Name.Equals(PerformanceCountersCategoryCacheNameTotalDirectHits))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }
        public long PerformanceCountersWarmCacheCacheTotalDirectHits
        {
            get
            {
                return WarmCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryCache) && p.Name.Equals(PerformanceCountersCategoryCacheNameTotalDirectHits))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }

        public long PerformanceCountersColdCacheMdxTotalFlatCacheInserts
        {
            get
            {
                return ColdCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameTotalFlatCacheInserts))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }
        public long PerformanceCountersWarmCacheMdxTotalFlatCacheInserts
        {
            get
            {
                return WarmCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameTotalFlatCacheInserts))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }

        public long PerformanceCountersColdCacheMdxTotalExisting
        {
            get
            {
                return ColdCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameTotalExisting))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }
        public long PerformanceCountersWarmCacheMdxTotalExisting
        {
            get
            {
                return WarmCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameTotalExisting))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }

        public long PerformanceCountersColdCacheMdxTotalAutoexist
        {
            get
            {
                return ColdCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameTotalAutoexist))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }
        public long PerformanceCountersWarmCacheMdxTotalAutoexist
        {
            get
            {
                return WarmCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameTotalAutoexist))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }

        public long PerformanceCountersColdCacheMdxTotalNonEmpty
        {
            get
            {
                return ColdCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameTotalNonEmpty))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }
        public long PerformanceCountersWarmCacheMdxTotalNonEmpty
        {
            get
            {
                return WarmCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameTotalNonEmpty))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }

        public long PerformanceCountersColdCacheMdxTotalSonarSubcubes
        {
            get
            {
                return ColdCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameTotalSonarSubcubes))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }
        public long PerformanceCountersWarmCacheMdxTotalSonarSubcubes
        {
            get
            {
                return WarmCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameTotalSonarSubcubes))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }

        public long PerformanceCountersColdCacheMdxTotalCellsCalculated
        {
            get
            {
                return ColdCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameTotalCellsCalculated))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }
        public long PerformanceCountersWarmCacheMdxTotalCellsCalculated
        {
            get
            {
                return WarmCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameTotalCellsCalculated))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }

        public long PerformanceCountersColdCacheMdxNumberOfCalculationCovers
        {
            get
            {
                return ColdCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameNumberOfCalculationCovers))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }
        public long PerformanceCountersWarmCacheMdxNumberOfCalculationCovers
        {
            get
            {
                return WarmCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameNumberOfCalculationCovers))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }

        public long PerformanceCountersColdCacheCategoryMdxNameNumberOfCellByCellEvaluationNodes
        {
            get
            {
                return ColdCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameNumberOfCellByCellEvaluationNodes))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }
        public long PerformanceCountersWarmCacheCategoryMdxNameNumberOfCellByCellEvaluationNodes
        {
            get
            {
                return WarmCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameNumberOfCellByCellEvaluationNodes))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }

        public long PerformanceCountersColdCacheCategoryMdxNameNumberOfBulkModeEvaluationNodes
        {
            get
            {
                return ColdCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameNumberOfBulkModeEvaluationNodes))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }
        public long PerformanceCountersWarmCacheCategoryMdxNameNumberOfBulkModeEvaluationNodes
        {
            get
            {
                return WarmCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryMdx) && p.Name.Equals(PerformanceCountersCategoryMdxNameNumberOfBulkModeEvaluationNodes))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }

        public long PerformanceCountersColdCacheStorageEngineQueryTotalMeasureGroupQueries
        {
            get
            {
                return ColdCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryStorageEngineQuery) && p.Name.Equals(PerformanceCountersCategoryStorageEngineQueryNameTotalMeasureGroupQueries))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }
        public long PerformanceCountersWarmCacheStorageEngineQueryTotalMeasureGroupQueries
        {
            get
            {
                return WarmCacheExecutionResult.Performances
                    .Where((p) => p.Category.Equals(PerformanceCountersCategoryStorageEngineQuery) && p.Name.Equals(PerformanceCountersCategoryStorageEngineQueryNameTotalMeasureGroupQueries))
                    .SelectMany((p) => p)
                    .Last().Value;
            }
        }

        #endregion

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (ColdCacheExecutionResult != null)
                    {
                        ColdCacheExecutionResult.Dispose();
                        ColdCacheExecutionResult = null;
                    }

                    if (WarmCacheExecutionResult != null)
                    {
                        WarmCacheExecutionResult.Dispose();
                        WarmCacheExecutionResult = null;
                    }
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
