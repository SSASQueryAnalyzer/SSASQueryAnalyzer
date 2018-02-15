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

namespace SSASQueryAnalyzer.Client.Common.Windows.Forms
{
    using SSASQueryAnalyzer.Client.Common.Windows.Drawing;
    using SSASQueryAnalyzer.Server.Infrastructure;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    using SysTimer = System.Timers;
    using SSASQueryAnalyzer.Client.Common.Infrastructure;

    public partial class ResultPresenterExecutionProgressControl : UserControl
    {
        private readonly SSASQueryAnalyzerClient _analyzerClient;
        private readonly Stopwatch _stopwatch = new Stopwatch();

        private readonly SysTimer.Timer _counterTimer = new SysTimer.Timer(TimeSpan.FromMilliseconds(100).TotalMilliseconds);
        private readonly SysTimer.Timer _eventTimer = new SysTimer.Timer(TimeSpan.FromMilliseconds(300).TotalMilliseconds);

        private static string ElapsedTimeFormat = @"hh\:mm\:ss\:fff";
        private static string CancellingMessage = "CANCELLING CURRENT OPERATION";
        private static string InProgressMessage = "ANALYSIS IN PROGRESS! PLEASE WAIT … ";
        private static string LoadingDataMessage = "LOADING ANALYSIS DATA! PLEASE WAIT … ";

        private bool _coldCacheExecution;

        public string TitleMessage
        {
			set 
			{
                switch(value)
                {
                    case "Live":
                        labelTitle.Text = InProgressMessage;
                        break;
                    case "Batch":
                        labelTitle.Text = InProgressMessage;
                        break;
                    case "FromBatch":
                        labelTitle.Text = LoadingDataMessage;
                        break;
                    default:
                        labelTitle.Text = InProgressMessage;
                        break;
                }
            }
        }

        public bool ActivitiesEnabled { get; set; }

        public ResultPresenterExecutionProgressControl(SSASQueryAnalyzerClient analyzerClient)
            : this()
        {
            _analyzerClient = analyzerClient;
        }

        public ResultPresenterExecutionProgressControl()
        {
            InitializeComponent();

            #region FlatButtons

            buttonCancel.FlatAppearance.MouseDownBackColor = CustomColor.ASQAOrange;
            buttonCancel.FlatAppearance.MouseOverBackColor = Color.White;
            buttonCancel.MouseDown += Extension.OnFlatButton_MouseDown;
            buttonCancel.MouseUp += Extension.OnFlatButton_MouseUp;
            buttonCancel.MouseEnter += Extension.OnFlatButton_MouseEnter;
            buttonCancel.MouseLeave += Extension.OnFlatButton_MouseLeave;

            #endregion

            Dock = DockStyle.Fill;
        } 

        private void SetCompleted(Label labelName, Label labelResult)
        {
            labelName.SetActive();
            labelResult.SetCompleted();
            labelName.Visible = true;
            labelResult.Visible = true;
        }

        private void SetInProgress(Label labelName, Label labelResult)
        {
            labelName.SetActive();
            labelResult.SetInProgress();
            labelName.Visible = true;
            labelResult.Visible = true;
        }

        private void UpdateProgress(ProcedureEvents @event)
        {
            try
            {
                if (_coldCacheExecution)
                {
                    #region Cold execution

                    if (@event == ProcedureEvents.ProcedureAnalyzeStepValidateStatement)
                    {
                        #region step
                        panelExecutionBandPre.Visible = true;
                        panelExecutionTaskPre.Visible = true;

                        SetInProgress(labelName_Pre_VerifyMDX, labelResult_Pre_VerifyMDX);
                        return;
                        #endregion
                    }

                    if (@event == ProcedureEvents.ProcedureAnalyzeStepClearCache)
                    {
                        #region step
                        panelExecutionBandPre.Visible = true;
                        panelExecutionTaskPre.Visible = true;

                        SetCompleted(labelName_Pre_VerifyMDX, labelResult_Pre_VerifyMDX);
                        SetInProgress(labelName_Pre_ClearCache, labelResult_Pre_ClearCache);
                        return;
                        #endregion
                    }

                    if (@event == ProcedureEvents.ProcedureAnalyzeStepLoadCubeScript)
                    {
                        #region step
                        panelExecutionBandPre.Visible = true;
                        panelExecutionTaskPre.Visible = true;

                        SetCompleted(labelName_Pre_VerifyMDX, labelResult_Pre_VerifyMDX);
                        SetCompleted(labelName_Pre_ClearCache, labelResult_Pre_ClearCache);
                        SetInProgress(labelName_Pre_LoadCubeMDXScript, labelResult_Pre_LoadCubeMDXScript);
                        return;
                        #endregion
                    }

                    if (@event == ProcedureEvents.ProcedureAnalyzeStepStartAnalyzerTask)
                    {
                        #region step
                        panelExecutionBandPre.Visible = true;
                        panelExecutionTaskPre.Visible = true;
                        SetCompleted(labelName_Pre_VerifyMDX, labelResult_Pre_VerifyMDX);
                        SetCompleted(labelName_Pre_ClearCache, labelResult_Pre_ClearCache);
                        SetCompleted(labelName_Pre_LoadCubeMDXScript, labelResult_Pre_LoadCubeMDXScript);

                        pictureBoxArrowDownTop.Visible = true;

                        panelExecutionBandColdCache.Visible = true;
                        panelExecutionTaskColdCache.Visible = true;
                        SetInProgress(labelName_Cold_RunTraces, labelResult_Cold_RunTraces);
                        return;
                        #endregion
                    }

                    if (@event == ProcedureEvents.ProcedureAnalyzeStepExecuteStatement)
                    {
                        #region step
                        panelExecutionBandPre.Visible = true;
                        panelExecutionTaskPre.Visible = true;
                        SetCompleted(labelName_Pre_VerifyMDX, labelResult_Pre_VerifyMDX);
                        SetCompleted(labelName_Pre_ClearCache, labelResult_Pre_ClearCache);
                        SetCompleted(labelName_Pre_LoadCubeMDXScript, labelResult_Pre_LoadCubeMDXScript);

                        pictureBoxArrowDownTop.Visible = true;

                        panelExecutionBandColdCache.Visible = true;
                        panelExecutionTaskColdCache.Visible = true;
                        SetCompleted(labelName_Cold_RunTraces, labelResult_Cold_RunTraces);
                        SetInProgress(labelName_Cold_ExecuteMDX, labelResult_Cold_ExecuteMDX);
                        return;
                        #endregion
                    }

                    if (@event == ProcedureEvents.ProcedureAnalyzeStepPendingOutcome)
                    {
                        #region step
                        panelExecutionBandPre.Visible = true;
                        panelExecutionTaskPre.Visible = true;
                        SetCompleted(labelName_Pre_VerifyMDX, labelResult_Pre_VerifyMDX);
                        SetCompleted(labelName_Pre_ClearCache, labelResult_Pre_ClearCache);
                        SetCompleted(labelName_Pre_LoadCubeMDXScript, labelResult_Pre_LoadCubeMDXScript);

                        pictureBoxArrowDownTop.Visible = true;

                        panelExecutionBandColdCache.Visible = true;
                        panelExecutionTaskColdCache.Visible = true;
                        SetCompleted(labelName_Cold_RunTraces, labelResult_Cold_RunTraces);
                        SetInProgress(labelName_Cold_ExecuteMDX, labelResult_Cold_ExecuteMDX);  // this task run always with the next one (CollectData)
                        SetInProgress(labelName_Cold_CollectData, labelResult_Cold_CollectData);
                        return;
                        #endregion
                    }

                    if (@event == ProcedureEvents.ProcedureAnalyzeStepCalculateResult)
                    {
                        #region step
                        panelExecutionBandPre.Visible = true;
                        panelExecutionTaskPre.Visible = true;
                        SetCompleted(labelName_Pre_VerifyMDX, labelResult_Pre_VerifyMDX);
                        SetCompleted(labelName_Pre_ClearCache, labelResult_Pre_ClearCache);
                        SetCompleted(labelName_Pre_LoadCubeMDXScript, labelResult_Pre_LoadCubeMDXScript);

                        pictureBoxArrowDownTop.Visible = true;

                        panelExecutionBandColdCache.Visible = true;
                        panelExecutionTaskColdCache.Visible = true;
                        SetCompleted(labelName_Cold_RunTraces, labelResult_Cold_RunTraces);
                        SetCompleted(labelName_Cold_ExecuteMDX, labelResult_Cold_ExecuteMDX);
                        SetCompleted(labelName_Cold_CollectData, labelResult_Cold_CollectData);
                        SetInProgress(labelName_Cold_CalculateMetrics, labelResult_Cold_CalculateMetrics);
                        return;
                        #endregion
                    }

                    if (@event == ProcedureEvents.ProcedureAnalyzeStepSendResult)
                    {
                        #region step
                        panelExecutionBandPre.Visible = true;
                        panelExecutionTaskPre.Visible = true;
                        SetCompleted(labelName_Pre_VerifyMDX, labelResult_Pre_VerifyMDX);
                        SetCompleted(labelName_Pre_ClearCache, labelResult_Pre_ClearCache);
                        SetCompleted(labelName_Pre_LoadCubeMDXScript, labelResult_Pre_LoadCubeMDXScript);

                        pictureBoxArrowDownTop.Visible = true;

                        panelExecutionBandColdCache.Visible = true;
                        panelExecutionTaskColdCache.Visible = true;
                        SetCompleted(labelName_Cold_RunTraces, labelResult_Cold_RunTraces);
                        SetCompleted(labelName_Cold_ExecuteMDX, labelResult_Cold_ExecuteMDX);
                        SetCompleted(labelName_Cold_CollectData, labelResult_Cold_CollectData);
                        SetCompleted(labelName_Cold_CalculateMetrics, labelResult_Cold_CalculateMetrics);
                        pictureBoxArrowDownCenter1.Visible = true;

                        panelExecutionBandPostCold.Visible = true;
                        panelExecutionTaskPostCold.Visible = true;

                        SetInProgress(labelName_PostCold_RetrieveData, labelResult_PostCold_RetrieveData);

                        return;
                        #endregion
                    }

                    #endregion
                }
                else
                {
                    #region Warm execution

                    if (@event == ProcedureEvents.ProcedureAnalyzeStepStartAnalyzerTask)
                    {
                        #region step
                        panelExecutionBandPre.Visible = true;
                        panelExecutionTaskPre.Visible = true;
                        SetCompleted(labelName_Pre_VerifyMDX, labelResult_Pre_VerifyMDX);
                        SetCompleted(labelName_Pre_ClearCache, labelResult_Pre_ClearCache);
                        SetCompleted(labelName_Pre_LoadCubeMDXScript, labelResult_Pre_LoadCubeMDXScript);

                        pictureBoxArrowDownTop.Visible = true;

                        panelExecutionBandColdCache.Visible = true;
                        panelExecutionTaskColdCache.Visible = true;
                        pictureBoxArrowDownCenter1.Visible = true;
                        SetCompleted(labelName_Cold_RunTraces, labelResult_Cold_RunTraces);
                        SetCompleted(labelName_Cold_ExecuteMDX, labelResult_Cold_ExecuteMDX);
                        SetCompleted(labelName_Cold_CollectData, labelResult_Cold_CollectData);
                        SetCompleted(labelName_Cold_CalculateMetrics, labelResult_Cold_CalculateMetrics);

                        panelExecutionBandPostCold.Visible = true;
                        panelExecutionTaskPostCold.Visible = true;

                        SetCompleted(labelName_PostCold_RetrieveData, labelResult_PostCold_RetrieveData);

                        pictureBoxArrowDownCenter2.Visible = true;

                        panelExecutionBandWarmCache.Visible = true;
                        panelExecutionTaskWarmCache.Visible = true;
                        SetInProgress(labelName_Warm_RunTraces, labelResult_Warm_RunTraces);
                        return;
                        #endregion
                    }

                    if (@event == ProcedureEvents.ProcedureAnalyzeStepExecuteStatement)
                    {
                        #region step
                        panelExecutionBandPre.Visible = true;
                        panelExecutionTaskPre.Visible = true;
                        SetCompleted(labelName_Pre_VerifyMDX, labelResult_Pre_VerifyMDX);
                        SetCompleted(labelName_Pre_ClearCache, labelResult_Pre_ClearCache);
                        SetCompleted(labelName_Pre_LoadCubeMDXScript, labelResult_Pre_LoadCubeMDXScript);

                        pictureBoxArrowDownTop.Visible = true;

                        panelExecutionBandColdCache.Visible = true;
                        panelExecutionTaskColdCache.Visible = true;
                        pictureBoxArrowDownCenter1.Visible = true;
                        SetCompleted(labelName_Cold_RunTraces, labelResult_Cold_RunTraces);
                        SetCompleted(labelName_Cold_ExecuteMDX, labelResult_Cold_ExecuteMDX);
                        SetCompleted(labelName_Cold_CollectData, labelResult_Cold_CollectData);
                        SetCompleted(labelName_Cold_CalculateMetrics, labelResult_Cold_CalculateMetrics);

                        panelExecutionBandPostCold.Visible = true;
                        panelExecutionTaskPostCold.Visible = true;

                        SetCompleted(labelName_PostCold_RetrieveData, labelResult_PostCold_RetrieveData);

                        pictureBoxArrowDownCenter2.Visible = true;

                        panelExecutionBandWarmCache.Visible = true;
                        panelExecutionTaskWarmCache.Visible = true;

                        SetCompleted(labelName_Warm_RunTraces, labelResult_Warm_RunTraces);
                        SetInProgress(labelName_Warm_ExecuteMDX, labelResult_Warm_ExecuteMDX);
                        return;
                        #endregion
                    }

                    if (@event == ProcedureEvents.ProcedureAnalyzeStepPendingOutcome)
                    {
                        #region step
                        panelExecutionBandPre.Visible = true;
                        panelExecutionTaskPre.Visible = true;
                        SetCompleted(labelName_Pre_VerifyMDX, labelResult_Pre_VerifyMDX);
                        SetCompleted(labelName_Pre_ClearCache, labelResult_Pre_ClearCache);
                        SetCompleted(labelName_Pre_LoadCubeMDXScript, labelResult_Pre_LoadCubeMDXScript);

                        pictureBoxArrowDownTop.Visible = true;

                        panelExecutionBandColdCache.Visible = true;
                        panelExecutionTaskColdCache.Visible = true;
                        pictureBoxArrowDownCenter1.Visible = true;
                        SetCompleted(labelName_Cold_RunTraces, labelResult_Cold_RunTraces);
                        SetCompleted(labelName_Cold_ExecuteMDX, labelResult_Cold_ExecuteMDX);
                        SetCompleted(labelName_Cold_CollectData, labelResult_Cold_CollectData);
                        SetCompleted(labelName_Cold_CalculateMetrics, labelResult_Cold_CalculateMetrics);

                        panelExecutionBandPostCold.Visible = true;
                        panelExecutionTaskPostCold.Visible = true;

                        SetCompleted(labelName_PostCold_RetrieveData, labelResult_PostCold_RetrieveData);

                        pictureBoxArrowDownCenter2.Visible = true;

                        panelExecutionBandWarmCache.Visible = true;
                        panelExecutionTaskWarmCache.Visible = true;

                        SetCompleted(labelName_Warm_RunTraces, labelResult_Warm_RunTraces);
                        SetInProgress(labelName_Warm_ExecuteMDX, labelResult_Warm_ExecuteMDX); // this task run always with the next one (CollectData)
                        SetInProgress(labelName_Warm_CollectData, labelResult_Warm_CollectData);
                        return;
                        #endregion
                    }

                    if (@event == ProcedureEvents.ProcedureAnalyzeStepCalculateResult)
                    {
                        #region step
                        panelExecutionBandPre.Visible = true;
                        panelExecutionTaskPre.Visible = true;
                        SetCompleted(labelName_Pre_VerifyMDX, labelResult_Pre_VerifyMDX);
                        SetCompleted(labelName_Pre_ClearCache, labelResult_Pre_ClearCache);
                        SetCompleted(labelName_Pre_LoadCubeMDXScript, labelResult_Pre_LoadCubeMDXScript);

                        pictureBoxArrowDownTop.Visible = true;

                        panelExecutionBandColdCache.Visible = true;
                        panelExecutionTaskColdCache.Visible = true;
                        pictureBoxArrowDownCenter1.Visible = true;
                        SetCompleted(labelName_Cold_RunTraces, labelResult_Cold_RunTraces);
                        SetCompleted(labelName_Cold_ExecuteMDX, labelResult_Cold_ExecuteMDX);
                        SetCompleted(labelName_Cold_CollectData, labelResult_Cold_CollectData);
                        SetCompleted(labelName_Cold_CalculateMetrics, labelResult_Cold_CalculateMetrics);

                        panelExecutionBandPostCold.Visible = true;
                        panelExecutionTaskPostCold.Visible = true;

                        SetCompleted(labelName_PostCold_RetrieveData, labelResult_PostCold_RetrieveData);

                        pictureBoxArrowDownCenter2.Visible = true;

                        panelExecutionBandWarmCache.Visible = true;
                        panelExecutionTaskWarmCache.Visible = true;

                        SetCompleted(labelName_Warm_RunTraces, labelResult_Warm_RunTraces);
                        SetCompleted(labelName_Warm_ExecuteMDX, labelResult_Warm_ExecuteMDX);
                        SetCompleted(labelName_Warm_CollectData, labelResult_Warm_CollectData);
                        SetInProgress(labelName_Warm_CalculateMetrics, labelResult_Warm_CalculateMetrics);
                        return;
                        #endregion
                    }

                    if (@event == ProcedureEvents.ProcedureAnalyzeStepSendResult)
                    {
                        #region step
                        panelExecutionBandPre.Visible = true;
                        panelExecutionTaskPre.Visible = true;
                        SetCompleted(labelName_Pre_VerifyMDX, labelResult_Pre_VerifyMDX);
                        SetCompleted(labelName_Pre_ClearCache, labelResult_Pre_ClearCache);
                        SetCompleted(labelName_Pre_LoadCubeMDXScript, labelResult_Pre_LoadCubeMDXScript);

                        pictureBoxArrowDownTop.Visible = true;

                        panelExecutionBandColdCache.Visible = true;
                        panelExecutionTaskColdCache.Visible = true;
                        pictureBoxArrowDownCenter1.Visible = true;
                        SetCompleted(labelName_Cold_RunTraces, labelResult_Cold_RunTraces);
                        SetCompleted(labelName_Cold_ExecuteMDX, labelResult_Cold_ExecuteMDX);
                        SetCompleted(labelName_Cold_CollectData, labelResult_Cold_CollectData);
                        SetCompleted(labelName_Cold_CalculateMetrics, labelResult_Cold_CalculateMetrics);

                        panelExecutionBandPostCold.Visible = true;
                        panelExecutionTaskPostCold.Visible = true;

                        SetCompleted(labelName_PostCold_RetrieveData, labelResult_PostCold_RetrieveData);

                        pictureBoxArrowDownCenter2.Visible = true;

                        panelExecutionBandWarmCache.Visible = true;
                        panelExecutionTaskWarmCache.Visible = true;

                        SetCompleted(labelName_Warm_RunTraces, labelResult_Warm_RunTraces);
                        SetCompleted(labelName_Warm_ExecuteMDX, labelResult_Warm_ExecuteMDX);
                        SetCompleted(labelName_Warm_CollectData, labelResult_Warm_CollectData);
                        SetCompleted(labelName_Warm_CalculateMetrics, labelResult_Warm_CalculateMetrics);

                        pictureBoxArrowDownBottom.Visible = true;

                        panelExecutionBandPostWarm.Visible = true;
                        panelExecutionTaskPostWarm.Visible = true;
                        SetInProgress(labelName_PostWarm_RetrieveData, labelResult_PostWarm_RetrieveData);
                        return;
                        #endregion
                    }

                    #endregion
                }
            }
            finally
            {
                tableLayoutPanelMain.Refresh();
            }
        }

        private void OnEventTimerElapsed(object sender, SysTimer.ElapsedEventArgs e)
        {
            var action = new Action(() =>
            {
                UpdateProgress(_analyzerClient.GetLastEvent());
            });

            this.Invoke(action);
        }

        private void OnCounterTimerElapsed(object sender, SysTimer.ElapsedEventArgs e)
        {
            var action = new Action(() =>
            {
                labelTimer.Text = _stopwatch.Elapsed.ToString(ElapsedTimeFormat);
            });

            this.Invoke(action);
        }

        public void StartMonitor()
        {
            _coldCacheExecution = true;

            var resetAllActivitiesEnabled = new Action(() =>
            {
                #region Set inactive

                var labelName = new[] 
                {
                    labelName_Pre_VerifyMDX,
                    labelName_Pre_ClearCache,
                    labelName_Pre_LoadCubeMDXScript,
                    labelName_Cold_RunTraces,
                    labelName_Cold_CalculateMetrics,
                    labelName_Cold_ExecuteMDX,
                    labelName_Cold_CollectData,
                    labelName_PostCold_RetrieveData,
                    labelName_Warm_RunTraces,
                    labelName_Warm_CalculateMetrics,
                    labelName_Warm_ExecuteMDX,
                    labelName_Warm_CollectData,
                    labelName_PostWarm_RetrieveData,
                    labelName_PostWarm_RenderingData
                };

                foreach (var label in labelName)
                    label.SetInactive();

                var labelResult = new[] 
                {
                    labelResult_Pre_VerifyMDX,
                    labelResult_Pre_ClearCache,
                    labelResult_Pre_LoadCubeMDXScript,
                    labelResult_Cold_RunTraces,
                    labelResult_Cold_CalculateMetrics,
                    labelResult_Cold_ExecuteMDX,
                    labelResult_Cold_CollectData,
                    labelResult_PostCold_RetrieveData,
                    labelResult_Warm_RunTraces,
                    labelResult_Warm_CollectData,
                    labelResult_Warm_ExecuteMDX,
                    labelResult_Warm_CalculateMetrics,
                    labelResult_PostWarm_RetrieveData,
                    labelResult_PostWarm_RenderingData
                };

                foreach (var label in labelResult)
                    label.SetInactive();

                #endregion

                labelTimer.Text = TimeSpan.Zero.ToString(ElapsedTimeFormat);
            });

            var resetAllActivitiesDisabled = new Action(() =>
            {
                #region Hide activities rows

                int firstRow = 8;
                int lastRow = 27;
                int currentRow = lastRow;
                while (currentRow >= firstRow)
                {
                    tableLayoutPanelMain.RowStyles[currentRow].Height = 0;
                    currentRow--;
                }

                #endregion

                labelTimer.Text = TimeSpan.Zero.ToString(ElapsedTimeFormat);
            });

            this.Invoke(ActivitiesEnabled ? resetAllActivitiesEnabled : resetAllActivitiesDisabled);

            _stopwatch.Reset();
            _stopwatch.Start();

            _counterTimer.Elapsed += OnCounterTimerElapsed;
            _counterTimer.Start();

            if (ActivitiesEnabled)
            {
                _eventTimer.Elapsed += OnEventTimerElapsed;
                _eventTimer.Start();
            }
        }

        public void StopMonitor()
        {
            _stopwatch.Stop();

            _eventTimer.Stop();
            _eventTimer.Elapsed -= OnEventTimerElapsed;

            _counterTimer.Stop();
            _counterTimer.Elapsed -= OnCounterTimerElapsed;
        }

        public void StartMonitor_Batch()
        {
            _coldCacheExecution = true;

            var resetAll = new Action(() =>
            {
                #region Hide activities rows

                int firstRow = 8;
                int lastRow = 27;
                int currentRow = lastRow;
                while (currentRow >= firstRow)
                {
                    tableLayoutPanelMain.RowStyles[currentRow].Height = 0;
                    currentRow--;
                }

                #endregion

                labelTimer.Text = TimeSpan.Zero.ToString(ElapsedTimeFormat);
            });

            this.Invoke(resetAll);

            _stopwatch.Reset();
            _stopwatch.Start();

            _counterTimer.Elapsed += OnCounterTimerElapsed;
            _counterTimer.Start();
        }

        public void StopMonitor_Batch()
        {
            _stopwatch.Stop();

            _counterTimer.Stop();
            _counterTimer.Elapsed -= OnCounterTimerElapsed;
        }

        public void ColdCacheExecutionCompleted()
        {
            _coldCacheExecution = false;

            if (!ActivitiesEnabled)
                return;

            var action = new Action(() =>
            {
                #region Set completed
                panelExecutionBandPre.Visible = true;
                panelExecutionTaskPre.Visible = true;
                SetCompleted(labelName_Pre_VerifyMDX, labelResult_Pre_VerifyMDX);
                SetCompleted(labelName_Pre_ClearCache, labelResult_Pre_ClearCache);
                SetCompleted(labelName_Pre_LoadCubeMDXScript, labelResult_Pre_LoadCubeMDXScript);

                pictureBoxArrowDownTop.Visible = true;

                panelExecutionBandColdCache.Visible = true;
                panelExecutionTaskColdCache.Visible = true;
                pictureBoxArrowDownCenter1.Visible = true;
                SetCompleted(labelName_Cold_RunTraces, labelResult_Cold_RunTraces);
                SetCompleted(labelName_Cold_ExecuteMDX, labelResult_Cold_ExecuteMDX);
                SetCompleted(labelName_Cold_CollectData, labelResult_Cold_CollectData);
                SetCompleted(labelName_Cold_CalculateMetrics, labelResult_Cold_CalculateMetrics);

                panelExecutionBandPostCold.Visible = true;
                panelExecutionTaskPostCold.Visible = true;

                SetCompleted(labelName_PostCold_RetrieveData, labelResult_PostCold_RetrieveData);

                pictureBoxArrowDownCenter2.Visible = true;

                panelExecutionBandWarmCache.Visible = true;
                panelExecutionTaskWarmCache.Visible = true;

                #endregion
            });

            this.Invoke(action);
        }

        public void WarmCacheExecutionCompleted()
        {
            if (!ActivitiesEnabled)
                return;

            var action = new Action(() =>
            {
                #region Set completed

                panelExecutionBandPre.Visible = true;
                panelExecutionTaskPre.Visible = true;
                SetCompleted(labelName_Pre_VerifyMDX, labelResult_Pre_VerifyMDX);
                SetCompleted(labelName_Pre_ClearCache, labelResult_Pre_ClearCache);
                SetCompleted(labelName_Pre_LoadCubeMDXScript, labelResult_Pre_LoadCubeMDXScript);
                pictureBoxArrowDownTop.Visible = true;
                panelExecutionBandColdCache.Visible = true;
                panelExecutionTaskColdCache.Visible = true;
                pictureBoxArrowDownCenter1.Visible = true;
                SetCompleted(labelName_Cold_RunTraces, labelResult_Cold_RunTraces);
                SetCompleted(labelName_Cold_ExecuteMDX, labelResult_Cold_ExecuteMDX);
                SetCompleted(labelName_Cold_CollectData, labelResult_Cold_CollectData);
                SetCompleted(labelName_Cold_CalculateMetrics, labelResult_Cold_CalculateMetrics);
                panelExecutionBandPostCold.Visible = true;
                panelExecutionTaskPostCold.Visible = true;
                SetCompleted(labelName_PostCold_RetrieveData, labelResult_PostCold_RetrieveData);
                pictureBoxArrowDownCenter2.Visible = true;
                panelExecutionBandWarmCache.Visible = true;
                panelExecutionTaskWarmCache.Visible = true;
                SetCompleted(labelName_Warm_RunTraces, labelResult_Warm_RunTraces);
                SetCompleted(labelName_Warm_ExecuteMDX, labelResult_Warm_ExecuteMDX);
                SetCompleted(labelName_Warm_CollectData, labelResult_Warm_CollectData);
                SetCompleted(labelName_Warm_CalculateMetrics, labelResult_Warm_CalculateMetrics);
                pictureBoxArrowDownBottom.Visible = true;
                panelExecutionBandPostWarm.Visible = true;
                panelExecutionTaskPostWarm.Visible = true;
                SetCompleted(labelName_PostWarm_RetrieveData, labelResult_PostWarm_RetrieveData);
                SetInProgress(labelName_PostWarm_RenderingData, labelResult_PostWarm_RenderingData);

                #endregion
            });

            this.Invoke(action);
        }

        private void OnButtonCancel_Click(object sender, EventArgs e)
        {
            labelTitle.Text = CancellingMessage;

            _analyzerClient.Cancel();

            buttonCancel.Enabled = false;
        }
    }

    internal static class LabelExtension
    {
        public static void SetActive(this Label label)
        {
            label.ForeColor = CustomColor.ActiveColor;
        }

        public static void SetInactive(this Label label)
        {
            label.ForeColor = CustomColor.InactiveColor;
        }

        public static void SetInProgress(this Label label)
        {
            label.Text = "in progress ...";
            label.ForeColor = CustomColor.InProgressColor;
        }

        public static void SetCompleted(this Label label)
        {
            label.Text = "completed";
            label.ForeColor = Color.DarkGreen;
        }
    }
}
