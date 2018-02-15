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

namespace SSASQueryAnalyzer.Server.Infrastructure
{
    using System;

    public enum ProcedureEvents: int
    {
        /// <summary>
        /// 
        /// </summary>
        UnhandledException = 0,

        /// <summary>
        /// 
        /// </summary>
        ApplicationException = 1,

        /// <summary>
        /// 
        /// </summary>
        ProcedureInstallBegin = 2,

        /// <summary>
        /// 
        /// </summary>
        ProcedureInstallEnd = 3,

        /// <summary>
        /// 
        /// </summary>
        ProcedureInstallStepInstallTrace = 4,

        /// <summary>
        /// 
        /// </summary>
        ProcedureUninstallBegin = 5,

        /// <summary>
        /// 
        /// </summary>
        ProcedureUninstallEnd = 6,

        /// <summary>
        /// 
        /// </summary>
        ProcedureUninstallStepUninstallTrace = 7,

        /// <summary>
        /// 
        /// </summary>
        ProcedureAnalyzeBegin = 8,

        /// <summary>
        /// 
        /// </summary>
        ProcedureAnalyzeEnd = 9,

        /// <summary>
        /// 
        /// </summary>
        ProcedureAnalyzeStepPrepare = 10,

        /// <summary>
        /// 
        /// </summary>
        ProcedureAnalyzeStepCancelTask = 11,

        /// <summary>
        /// Step verify statement 
        /// </summary>
        ProcedureAnalyzeStepValidateStatement = 21,

        /// <summary>
        /// Step clear cache
        /// </summary>
        ProcedureAnalyzeStepClearCache = 22,

        /// <summary>
        /// Step load cube script
        /// </summary>
        ProcedureAnalyzeStepLoadCubeScript = 23,

        /// <summary>
        /// Step run traces, profiler and performance
        /// </summary>
        ProcedureAnalyzeStepStartAnalyzerTask = 24,

        /// <summary>
        /// Step execute statement
        /// </summary>
        ProcedureAnalyzeStepExecuteStatement = 25,

        /// <summary>
        /// Step collect data
        /// </summary>
        ProcedureAnalyzeStepPendingOutcome = 26,

        /// <summary>
        /// Step calculate metrics
        /// </summary>
        ProcedureAnalyzeStepCalculateResult = 27,

        /// <summary>
        /// Step retrieving data
        /// </summary>
        ProcedureAnalyzeStepSendResult = 28,

        /// <summary>
        /// 
        /// </summary>
        ProcedureReconfigureBegin = 29,

        /// <summary>
        /// 
        /// </summary>
        ProcedureReconfigureEnd = 30,

        /// <summary>
        /// 
        /// </summary>
        ProcedureReconfigureStepReconfigureTrace = 31,

        /// <summary>
        /// 
        /// </summary>
        ProcedureGetConfigurationBegin = 32,

        /// <summary>
        /// 
        /// </summary>
        ProcedureGetConfigurationEnd = 33,
    }
}
