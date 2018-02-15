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

namespace SSASQueryAnalyzer.Client.Common.Infrastructure.AnalysisServices
{
    using System;
    using System.Runtime.InteropServices;

    public enum TraceEventClass
    {
        // Summary:
        //     Type not available.
        NotAvailable,
        //
        // Summary:
        //     Collects all new connection events since the trace was started, such as when
        //     a client requests a connection to a server running an instance of SQL Server.
        AuditLogin,
        //
        // Summary:
        //     Collects all new disconnect events since the trace was started, such as when
        //     a client issues a disconnect command.
        AuditLogout,
        //
        // Summary:
        //     Service was shut down, started, or paused.
        AuditServerStartsAndStops,
        //
        // Summary:
        //     Progress report started.
        ProgressReportBegin,
        //
        // Summary:
        //     Progress report end.
        ProgressReportEnd,
        //
        // Summary:
        //     Progress report current.
        ProgressReportCurrent,
        //
        // Summary:
        //     Progress report error.
        ProgressReportError,
        //
        // Summary:
        //     A query began.
        QueryBegin,
        //
        // Summary:
        //     A query ended.
        QueryEnd,
        //
        // Summary:
        //     A subcube was queried; useful for usage-based optimization.
        QuerySubcube,
        //
        // Summary:
        //     A subcube was queried; detailed information is traced.
        QuerySubcubeVerbose,
        //
        // Summary:
        //     A command began.
        CommandBegin,
        //
        // Summary:
        //     A command ended.
        CommandEnd,
        //
        // Summary:
        //     The server experienced an error.
        Error,
        //
        // Summary:
        //     Object permissions were changed.
        AuditObjectPermission,
        //
        // Summary:
        //     The type is AuditAdminOperations.
        AuditAdminOperations,
        //
        // Summary:
        //     The server state discovery started.
        ServerStateDiscoverBegin,
        //
        // Summary:
        //     Contents of the server state discover response.
        ServerStateDiscoverData,
        //
        // Summary:
        //     The server state discovery ended.
        ServerStateDiscoverEnd,
        //
        // Summary:
        //     A discover request began.
        DiscoverBegin,
        //
        // Summary:
        //     A discover request ended.
        DiscoverEnd,
        //
        // Summary:
        //     Collection of notification events.
        Notification,
        //
        // Summary:
        //     A collection of user-defined events.
        UserDefined,
        //
        // Summary:
        //     Collection of connection events.
        ExistingConnection,
        //
        // Summary:
        //     Collection of session events.
        ExistingSession,
        //
        // Summary:
        //     A session was initialized.
        SessionInitialize,
        //
        // Summary:
        //     Collection of lock-related events.
        Deadlock,
        //
        // Summary:
        //     A metadata lock timed out.
        Locktimeout,
        //
        // Summary:
        //     The type is LockAcquired.
        LockAcquired,
        //
        // Summary:
        //     The type is LockReleased.
        LockReleased,
        //
        // Summary:
        //     The type is LockWaiting.
        LockWaiting,
        //
        // Summary:
        //     An answer was generated with data from an aggregation.
        GetDataFromAggregation,
        //
        // Summary:
        //     An answer was generated with data from one of the caches.
        GetDataFromCache,
        //
        // Summary:
        //     Cube querying for a query began.
        QueryCubeBegin,
        //
        // Summary:
        //     Cube querying for a query ended.
        QueryCubeEnd,
        //
        // Summary:
        //     Calculation of non-empty for a query began.
        CalculateNonEmptyBegin,
        //
        // Summary:
        //     Calculation of non-empty for a query is currently running.
        CalculateNonEmptyCurrent,
        //
        // Summary:
        //     Calculation of non-empty for a query ended.
        CalculateNonEmptyEnd,
        //
        // Summary:
        //     Serialization of results for a query began.
        SerializeResultsBegin,
        //
        // Summary:
        //     Serialization of results for a query is currently running.
        SerializeResultsCurrent,
        //
        // Summary:
        //     Serialization of results for a query ended.
        SerializeResultsEnd,
        //
        // Summary:
        //     MDX Script execution began.
        ExecuteMdxScriptBegin,
        //
        // Summary:
        //     MDX Script execution is currently running.
        ExecuteMdxScriptCurrent,
        //
        // Summary:
        //     MDX Script execution ended.
        ExecuteMdxScriptEnd,
        //
        // Summary:
        //     A dimension was queried.
        QueryDimension,
        //
        // Summary:
        //     The type is VertiPaqSEQueryBegin.
        VertiPaqSEQueryBegin,
        //
        // Summary:
        //     The type is VertiPaqSEQueryEnd.
        VertiPaqSEQueryEnd,
        //
        // Summary:
        //     The type is ResourceUsage.
        ResourceUsage,
        //
        // Summary:
        //     The type is VertiPaqSEQueryBeginCacheMatch.
        VertiPaqSEQueryCacheMatch,
        //
        // Summary:
        //     The file loading began.
        FileLoadBegin,
        //
        // Summary:
        //     The file loading ended.
        FileLoadEnd,
        //
        // Summary:
        //     The file saving began.
        FileSaveBegin,
        //
        // Summary:
        //     The file saving ended.
        FileSaveEnd,
        //
        // Summary:
        //     The type is PageOutBegin.
        PageOutBegin,
        //
        // Summary:
        //     The type is PageOutEnd.
        PageOutEnd,
        //
        // Summary:
        //     The type is PageInBegin.
        PageInBegin,
        //
        // Summary:
        //     The type is PageInEnd.
        PageInEnd,
        //
        // Summary:
        //     A DirectQuery operation began.
        DirectQueryBegin,
        //
        // Summary:
        //     A DirectQuery operation ended.
        DirectQueryEnd,
        //
        // Summary:
        //     Calculation of results for a query.
        CalculationEvaluation,
        //
        // Summary:
        //     Calculation of detailed information results for a query.
        CalculationEvaluationDetailedInformation,
        //
        // Summary:
        //     The DAX query plan.
        DAXQueryPlan,
        //
        WLGroupCPUThrottling,
        //
        WLGroupExceedsMemoryLimit,
        //
        WLGroupExceedsProcessingLimit,
    }
}
