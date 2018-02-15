namespace SSASQueryAnalyzer.Client.SSMS.VSPackage.Windows.Forms
{
    using SSASQueryAnalyzer.Client.Common.Properties;
    
    partial class AsqaHelperBatchModeControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMaster = new System.Windows.Forms.Panel();
            this.panelAnalysisSearch = new System.Windows.Forms.Panel();
            this.panelData = new System.Windows.Forms.Panel();
            this.panelAnalysisSearchResult = new System.Windows.Forms.Panel();
            this.gridViewAnalysisData = new System.Windows.Forms.DataGridView();
            this.labelAnalysisSearchRowsCount = new System.Windows.Forms.Label();
            this.panelAnalysisSearchCommands = new System.Windows.Forms.Panel();
            this.panelAnalysisSearchCommandsTop = new System.Windows.Forms.Panel();
            this.buttonLoadAnalysisData = new System.Windows.Forms.Button();
            this.buttonShowQuery = new System.Windows.Forms.Button();
            this.panelAnalysisSearchCommandsBottom = new System.Windows.Forms.Panel();
            this.panelQueryText = new System.Windows.Forms.Panel();
            this.richTextBoxQuery = new System.Windows.Forms.RichTextBox();
            this.panelQueryTextCommands = new System.Windows.Forms.Panel();
            this.panelQueryTextCommandsTop = new System.Windows.Forms.Panel();
            this.buttonBackFromQuery = new System.Windows.Forms.Button();
            this.panelQueryTextCommandsBottom = new System.Windows.Forms.Panel();
            this.panelAnalysisSearchParameters = new System.Windows.Forms.Panel();
            this.checkBoxResults = new System.Windows.Forms.CheckBox();
            this.labelAnalysisName = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.comboBoxAnalysisName = new System.Windows.Forms.ComboBox();
            this.labelBatchID = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelCube = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelDatabase = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelDate = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelInstance = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelUser = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.comboBoxBatchID = new System.Windows.Forms.ComboBox();
            this.comboBoxCube = new System.Windows.Forms.ComboBox();
            this.comboBoxDatabase = new System.Windows.Forms.ComboBox();
            this.comboBoxDate = new System.Windows.Forms.ComboBox();
            this.comboBoxInstance = new System.Windows.Forms.ComboBox();
            this.comboBoxUserName = new System.Windows.Forms.ComboBox();
            this.buttonAnalysisSearchRefresh = new System.Windows.Forms.Button();
            this.panelSearchAnalysisBottom = new System.Windows.Forms.Panel();
            this.panelAnalysisSearchTitle = new System.Windows.Forms.Panel();
            this.pictureAnalysisSearch = new System.Windows.Forms.PictureBox();
            this.labelAnalysisSearchTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.panelLoadFromDb = new System.Windows.Forms.Panel();
            this.checkBoxFilterControls = new System.Windows.Forms.CheckBox();
            this.pictureLoadFromDb = new System.Windows.Forms.PictureBox();
            this.customLabelLoadFromDbTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.panelLoadFromDbBottom = new System.Windows.Forms.Panel();
            this.panelSQLInstance = new System.Windows.Forms.Panel();
            this.pictureSQLInstance = new System.Windows.Forms.PictureBox();
            this.labelSQLInstanceTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.labelSQLInstanceInfo = new System.Windows.Forms.Label();
            this.comboBoxSQLInstances = new System.Windows.Forms.ComboBox();
            this.labelASQADBVersion = new System.Windows.Forms.Label();
            this.buttonASQADBInstall = new System.Windows.Forms.Button();
            this.buttonASQADBUninstall = new System.Windows.Forms.Button();
            this.panelSQLInstanceBottom = new System.Windows.Forms.Panel();
            this.panelBatchMode = new System.Windows.Forms.Panel();
            this.pictureBatchMode = new System.Windows.Forms.PictureBox();
            this.customLabelBatchModeTitle = new SSASQueryAnalyzer.Client.Common.Windows.Forms.CustomLabelControl();
            this.panelBatchModeBottom = new System.Windows.Forms.Panel();
            this.panelMaster.SuspendLayout();
            this.panelAnalysisSearch.SuspendLayout();
            this.panelData.SuspendLayout();
            this.panelAnalysisSearchResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAnalysisData)).BeginInit();
            this.panelAnalysisSearchCommands.SuspendLayout();
            this.panelQueryText.SuspendLayout();
            this.panelQueryTextCommands.SuspendLayout();
            this.panelAnalysisSearchParameters.SuspendLayout();
            this.panelAnalysisSearchTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAnalysisSearch)).BeginInit();
            this.panelLoadFromDb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLoadFromDb)).BeginInit();
            this.panelSQLInstance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSQLInstance)).BeginInit();
            this.panelBatchMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBatchMode)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMaster
            // 
            this.panelMaster.BackColor = System.Drawing.Color.White;
            this.panelMaster.Controls.Add(this.panelAnalysisSearch);
            this.panelMaster.Controls.Add(this.panelLoadFromDb);
            this.panelMaster.Controls.Add(this.panelSQLInstance);
            this.panelMaster.Controls.Add(this.panelBatchMode);
            this.panelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMaster.Location = new System.Drawing.Point(0, 0);
            this.panelMaster.Margin = new System.Windows.Forms.Padding(4);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Size = new System.Drawing.Size(450, 730);
            this.panelMaster.TabIndex = 0;
            // 
            // panelAnalysisSearch
            // 
            this.panelAnalysisSearch.Controls.Add(this.panelData);
            this.panelAnalysisSearch.Controls.Add(this.panelAnalysisSearchParameters);
            this.panelAnalysisSearch.Controls.Add(this.panelAnalysisSearchTitle);
            this.panelAnalysisSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAnalysisSearch.Location = new System.Drawing.Point(0, 260);
            this.panelAnalysisSearch.Name = "panelAnalysisSearch";
            this.panelAnalysisSearch.Size = new System.Drawing.Size(450, 470);
            this.panelAnalysisSearch.TabIndex = 7;
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.panelAnalysisSearchResult);
            this.panelData.Controls.Add(this.panelQueryText);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 316);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(450, 154);
            this.panelData.TabIndex = 94;
            // 
            // panelAnalysisSearchResult
            // 
            this.panelAnalysisSearchResult.BackColor = System.Drawing.Color.White;
            this.panelAnalysisSearchResult.Controls.Add(this.gridViewAnalysisData);
            this.panelAnalysisSearchResult.Controls.Add(this.labelAnalysisSearchRowsCount);
            this.panelAnalysisSearchResult.Controls.Add(this.panelAnalysisSearchCommands);
            this.panelAnalysisSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAnalysisSearchResult.Location = new System.Drawing.Point(0, 0);
            this.panelAnalysisSearchResult.Margin = new System.Windows.Forms.Padding(0);
            this.panelAnalysisSearchResult.Name = "panelAnalysisSearchResult";
            this.panelAnalysisSearchResult.Size = new System.Drawing.Size(450, 154);
            this.panelAnalysisSearchResult.TabIndex = 99;
            // 
            // gridViewAnalysisData
            // 
            this.gridViewAnalysisData.AllowUserToAddRows = false;
            this.gridViewAnalysisData.AllowUserToDeleteRows = false;
            this.gridViewAnalysisData.AllowUserToOrderColumns = true;
            this.gridViewAnalysisData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridViewAnalysisData.BackgroundColor = System.Drawing.Color.White;
            this.gridViewAnalysisData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridViewAnalysisData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewAnalysisData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewAnalysisData.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridViewAnalysisData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridViewAnalysisData.GridColor = System.Drawing.Color.Black;
            this.gridViewAnalysisData.Location = new System.Drawing.Point(0, 0);
            this.gridViewAnalysisData.Margin = new System.Windows.Forms.Padding(4);
            this.gridViewAnalysisData.MultiSelect = false;
            this.gridViewAnalysisData.Name = "gridViewAnalysisData";
            this.gridViewAnalysisData.ReadOnly = true;
            this.gridViewAnalysisData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridViewAnalysisData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridViewAnalysisData.RowHeadersVisible = false;
            this.gridViewAnalysisData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewAnalysisData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViewAnalysisData.Size = new System.Drawing.Size(450, 93);
            this.gridViewAnalysisData.TabIndex = 6;
            this.gridViewAnalysisData.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OnGridViewAnalysisData_ColumnHeaderMouseClick);
            this.gridViewAnalysisData.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.OnGridViewAnalysisData_DataBindingComplete);
            this.gridViewAnalysisData.Click += new System.EventHandler(this.OnGridViewAnalysisData_Click);
            // 
            // labelAnalysisSearchRowsCount
            // 
            this.labelAnalysisSearchRowsCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelAnalysisSearchRowsCount.Location = new System.Drawing.Point(0, 93);
            this.labelAnalysisSearchRowsCount.Name = "labelAnalysisSearchRowsCount";
            this.labelAnalysisSearchRowsCount.Size = new System.Drawing.Size(450, 17);
            this.labelAnalysisSearchRowsCount.TabIndex = 5;
            this.labelAnalysisSearchRowsCount.Text = "Rows: 0";
            this.labelAnalysisSearchRowsCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelAnalysisSearchCommands
            // 
            this.panelAnalysisSearchCommands.BackColor = System.Drawing.Color.White;
            this.panelAnalysisSearchCommands.Controls.Add(this.panelAnalysisSearchCommandsTop);
            this.panelAnalysisSearchCommands.Controls.Add(this.buttonLoadAnalysisData);
            this.panelAnalysisSearchCommands.Controls.Add(this.buttonShowQuery);
            this.panelAnalysisSearchCommands.Controls.Add(this.panelAnalysisSearchCommandsBottom);
            this.panelAnalysisSearchCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAnalysisSearchCommands.Location = new System.Drawing.Point(0, 110);
            this.panelAnalysisSearchCommands.Margin = new System.Windows.Forms.Padding(4);
            this.panelAnalysisSearchCommands.Name = "panelAnalysisSearchCommands";
            this.panelAnalysisSearchCommands.Size = new System.Drawing.Size(450, 44);
            this.panelAnalysisSearchCommands.TabIndex = 3;
            // 
            // panelAnalysisSearchCommandsTop
            // 
            this.panelAnalysisSearchCommandsTop.BackColor = System.Drawing.Color.Black;
            this.panelAnalysisSearchCommandsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAnalysisSearchCommandsTop.Location = new System.Drawing.Point(0, 0);
            this.panelAnalysisSearchCommandsTop.Name = "panelAnalysisSearchCommandsTop";
            this.panelAnalysisSearchCommandsTop.Size = new System.Drawing.Size(450, 1);
            this.panelAnalysisSearchCommandsTop.TabIndex = 95;
            // 
            // buttonLoadAnalysisData
            // 
            this.buttonLoadAnalysisData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadAnalysisData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonLoadAnalysisData.Enabled = false;
            this.buttonLoadAnalysisData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadAnalysisData.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonLoadAnalysisData.Location = new System.Drawing.Point(272, 8);
            this.buttonLoadAnalysisData.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLoadAnalysisData.Name = "buttonLoadAnalysisData";
            this.buttonLoadAnalysisData.Size = new System.Drawing.Size(170, 28);
            this.buttonLoadAnalysisData.TabIndex = 81;
            this.buttonLoadAnalysisData.Text = "Load analysis data";
            this.buttonLoadAnalysisData.UseVisualStyleBackColor = true;
            this.buttonLoadAnalysisData.Click += new System.EventHandler(this.OnButtonLoadAnalysisData_Click);
            // 
            // buttonShowQuery
            // 
            this.buttonShowQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonShowQuery.Enabled = false;
            this.buttonShowQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonShowQuery.Location = new System.Drawing.Point(87, 8);
            this.buttonShowQuery.Margin = new System.Windows.Forms.Padding(0);
            this.buttonShowQuery.Name = "buttonShowQuery";
            this.buttonShowQuery.Size = new System.Drawing.Size(170, 28);
            this.buttonShowQuery.TabIndex = 80;
            this.buttonShowQuery.Text = "Show query";
            this.buttonShowQuery.UseVisualStyleBackColor = true;
            this.buttonShowQuery.Click += new System.EventHandler(this.OnButtonShowQuery_Click);
            // 
            // panelAnalysisSearchCommandsBottom
            // 
            this.panelAnalysisSearchCommandsBottom.BackColor = System.Drawing.Color.Black;
            this.panelAnalysisSearchCommandsBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAnalysisSearchCommandsBottom.Location = new System.Drawing.Point(0, 43);
            this.panelAnalysisSearchCommandsBottom.Name = "panelAnalysisSearchCommandsBottom";
            this.panelAnalysisSearchCommandsBottom.Size = new System.Drawing.Size(450, 1);
            this.panelAnalysisSearchCommandsBottom.TabIndex = 92;
            // 
            // panelQueryText
            // 
            this.panelQueryText.BackColor = System.Drawing.Color.White;
            this.panelQueryText.Controls.Add(this.richTextBoxQuery);
            this.panelQueryText.Controls.Add(this.panelQueryTextCommands);
            this.panelQueryText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelQueryText.Location = new System.Drawing.Point(0, 0);
            this.panelQueryText.Margin = new System.Windows.Forms.Padding(0);
            this.panelQueryText.Name = "panelQueryText";
            this.panelQueryText.Size = new System.Drawing.Size(450, 154);
            this.panelQueryText.TabIndex = 98;
            // 
            // richTextBoxQuery
            // 
            this.richTextBoxQuery.BackColor = System.Drawing.Color.White;
            this.richTextBoxQuery.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxQuery.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBoxQuery.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxQuery.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBoxQuery.Name = "richTextBoxQuery";
            this.richTextBoxQuery.ReadOnly = true;
            this.richTextBoxQuery.Size = new System.Drawing.Size(450, 110);
            this.richTextBoxQuery.TabIndex = 86;
            this.richTextBoxQuery.Text = "fdgdbg\ndhsgnsf\ngnsnfnf\nsfgnshfnhn ";
            // 
            // panelQueryTextCommands
            // 
            this.panelQueryTextCommands.BackColor = System.Drawing.Color.White;
            this.panelQueryTextCommands.Controls.Add(this.panelQueryTextCommandsTop);
            this.panelQueryTextCommands.Controls.Add(this.buttonBackFromQuery);
            this.panelQueryTextCommands.Controls.Add(this.panelQueryTextCommandsBottom);
            this.panelQueryTextCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelQueryTextCommands.Location = new System.Drawing.Point(0, 110);
            this.panelQueryTextCommands.Margin = new System.Windows.Forms.Padding(4);
            this.panelQueryTextCommands.Name = "panelQueryTextCommands";
            this.panelQueryTextCommands.Size = new System.Drawing.Size(450, 44);
            this.panelQueryTextCommands.TabIndex = 0;
            // 
            // panelQueryTextCommandsTop
            // 
            this.panelQueryTextCommandsTop.BackColor = System.Drawing.Color.Black;
            this.panelQueryTextCommandsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelQueryTextCommandsTop.Location = new System.Drawing.Point(0, 0);
            this.panelQueryTextCommandsTop.Name = "panelQueryTextCommandsTop";
            this.panelQueryTextCommandsTop.Size = new System.Drawing.Size(450, 1);
            this.panelQueryTextCommandsTop.TabIndex = 94;
            // 
            // buttonBackFromQuery
            // 
            this.buttonBackFromQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBackFromQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonBackFromQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackFromQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonBackFromQuery.Location = new System.Drawing.Point(316, 8);
            this.buttonBackFromQuery.Margin = new System.Windows.Forms.Padding(0);
            this.buttonBackFromQuery.Name = "buttonBackFromQuery";
            this.buttonBackFromQuery.Size = new System.Drawing.Size(123, 28);
            this.buttonBackFromQuery.TabIndex = 80;
            this.buttonBackFromQuery.Text = "Back";
            this.buttonBackFromQuery.UseVisualStyleBackColor = true;
            this.buttonBackFromQuery.Click += new System.EventHandler(this.OnButtonBackFromQuery_Click);
            // 
            // panelQueryTextCommandsBottom
            // 
            this.panelQueryTextCommandsBottom.BackColor = System.Drawing.Color.Black;
            this.panelQueryTextCommandsBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelQueryTextCommandsBottom.Location = new System.Drawing.Point(0, 43);
            this.panelQueryTextCommandsBottom.Name = "panelQueryTextCommandsBottom";
            this.panelQueryTextCommandsBottom.Size = new System.Drawing.Size(450, 1);
            this.panelQueryTextCommandsBottom.TabIndex = 93;
            // 
            // panelAnalysisSearchParameters
            // 
            this.panelAnalysisSearchParameters.BackColor = System.Drawing.Color.White;
            this.panelAnalysisSearchParameters.Controls.Add(this.checkBoxResults);
            this.panelAnalysisSearchParameters.Controls.Add(this.labelAnalysisName);
            this.panelAnalysisSearchParameters.Controls.Add(this.comboBoxAnalysisName);
            this.panelAnalysisSearchParameters.Controls.Add(this.labelBatchID);
            this.panelAnalysisSearchParameters.Controls.Add(this.labelCube);
            this.panelAnalysisSearchParameters.Controls.Add(this.labelDatabase);
            this.panelAnalysisSearchParameters.Controls.Add(this.labelDate);
            this.panelAnalysisSearchParameters.Controls.Add(this.labelInstance);
            this.panelAnalysisSearchParameters.Controls.Add(this.labelUser);
            this.panelAnalysisSearchParameters.Controls.Add(this.comboBoxBatchID);
            this.panelAnalysisSearchParameters.Controls.Add(this.comboBoxCube);
            this.panelAnalysisSearchParameters.Controls.Add(this.comboBoxDatabase);
            this.panelAnalysisSearchParameters.Controls.Add(this.comboBoxDate);
            this.panelAnalysisSearchParameters.Controls.Add(this.comboBoxInstance);
            this.panelAnalysisSearchParameters.Controls.Add(this.comboBoxUserName);
            this.panelAnalysisSearchParameters.Controls.Add(this.buttonAnalysisSearchRefresh);
            this.panelAnalysisSearchParameters.Controls.Add(this.panelSearchAnalysisBottom);
            this.panelAnalysisSearchParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAnalysisSearchParameters.Location = new System.Drawing.Point(0, 48);
            this.panelAnalysisSearchParameters.Margin = new System.Windows.Forms.Padding(4);
            this.panelAnalysisSearchParameters.Name = "panelAnalysisSearchParameters";
            this.panelAnalysisSearchParameters.Size = new System.Drawing.Size(450, 268);
            this.panelAnalysisSearchParameters.TabIndex = 93;
            // 
            // checkBoxResults
            // 
            this.checkBoxResults.AutoSize = true;
            this.checkBoxResults.Checked = true;
            this.checkBoxResults.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxResults.Location = new System.Drawing.Point(46, 235);
            this.checkBoxResults.Name = "checkBoxResults";
            this.checkBoxResults.Size = new System.Drawing.Size(81, 17);
            this.checkBoxResults.TabIndex = 90;
            this.checkBoxResults.Text = "Hide results";
            this.checkBoxResults.UseVisualStyleBackColor = true;
            this.checkBoxResults.CheckedChanged += new System.EventHandler(this.OnCheckBoxResults_CheckedChanged);
            // 
            // labelAnalysisName
            // 
            this.labelAnalysisName.BorderColor = System.Drawing.Color.Black;
            this.labelAnalysisName.BorderHeightOffset = 2;
            this.labelAnalysisName.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelAnalysisName.BorderWidthOffset = 2;
            this.labelAnalysisName.DrawBorder = false;
            this.labelAnalysisName.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnalysisName.Location = new System.Drawing.Point(44, 165);
            this.labelAnalysisName.Margin = new System.Windows.Forms.Padding(0);
            this.labelAnalysisName.Name = "labelAnalysisName";
            this.labelAnalysisName.Size = new System.Drawing.Size(80, 26);
            this.labelAnalysisName.TabIndex = 93;
            this.labelAnalysisName.Text = "Analysis Name";
            this.labelAnalysisName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxAnalysisName
            // 
            this.comboBoxAnalysisName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAnalysisName.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxAnalysisName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAnalysisName.Enabled = false;
            this.comboBoxAnalysisName.FormattingEnabled = true;
            this.comboBoxAnalysisName.Location = new System.Drawing.Point(142, 168);
            this.comboBoxAnalysisName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxAnalysisName.Name = "comboBoxAnalysisName";
            this.comboBoxAnalysisName.Size = new System.Drawing.Size(301, 21);
            this.comboBoxAnalysisName.Sorted = true;
            this.comboBoxAnalysisName.TabIndex = 92;
            this.comboBoxAnalysisName.DropDown += new System.EventHandler(this.OnComboBoxName_DropDown);
            // 
            // labelBatchID
            // 
            this.labelBatchID.BorderColor = System.Drawing.Color.Black;
            this.labelBatchID.BorderHeightOffset = 2;
            this.labelBatchID.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelBatchID.BorderWidthOffset = 2;
            this.labelBatchID.DrawBorder = false;
            this.labelBatchID.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBatchID.Location = new System.Drawing.Point(44, 196);
            this.labelBatchID.Margin = new System.Windows.Forms.Padding(0);
            this.labelBatchID.Name = "labelBatchID";
            this.labelBatchID.Size = new System.Drawing.Size(80, 26);
            this.labelBatchID.TabIndex = 85;
            this.labelBatchID.Text = "Analysis ID";
            this.labelBatchID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCube
            // 
            this.labelCube.BorderColor = System.Drawing.Color.Black;
            this.labelCube.BorderHeightOffset = 2;
            this.labelCube.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelCube.BorderWidthOffset = 2;
            this.labelCube.DrawBorder = false;
            this.labelCube.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCube.Location = new System.Drawing.Point(44, 134);
            this.labelCube.Margin = new System.Windows.Forms.Padding(0);
            this.labelCube.Name = "labelCube";
            this.labelCube.Size = new System.Drawing.Size(62, 26);
            this.labelCube.TabIndex = 73;
            this.labelCube.Text = "Cube";
            this.labelCube.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDatabase
            // 
            this.labelDatabase.BorderColor = System.Drawing.Color.Black;
            this.labelDatabase.BorderHeightOffset = 2;
            this.labelDatabase.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelDatabase.BorderWidthOffset = 2;
            this.labelDatabase.DrawBorder = false;
            this.labelDatabase.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDatabase.Location = new System.Drawing.Point(44, 103);
            this.labelDatabase.Margin = new System.Windows.Forms.Padding(0);
            this.labelDatabase.Name = "labelDatabase";
            this.labelDatabase.Size = new System.Drawing.Size(65, 26);
            this.labelDatabase.TabIndex = 71;
            this.labelDatabase.Text = "Database";
            this.labelDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDate
            // 
            this.labelDate.BorderColor = System.Drawing.Color.Black;
            this.labelDate.BorderHeightOffset = 2;
            this.labelDate.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelDate.BorderWidthOffset = 2;
            this.labelDate.DrawBorder = false;
            this.labelDate.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.Location = new System.Drawing.Point(44, 10);
            this.labelDate.Margin = new System.Windows.Forms.Padding(0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(65, 26);
            this.labelDate.TabIndex = 69;
            this.labelDate.Text = "Date";
            this.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelInstance
            // 
            this.labelInstance.BorderColor = System.Drawing.Color.Black;
            this.labelInstance.BorderHeightOffset = 2;
            this.labelInstance.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelInstance.BorderWidthOffset = 2;
            this.labelInstance.DrawBorder = false;
            this.labelInstance.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstance.Location = new System.Drawing.Point(44, 72);
            this.labelInstance.Margin = new System.Windows.Forms.Padding(0);
            this.labelInstance.Name = "labelInstance";
            this.labelInstance.Size = new System.Drawing.Size(94, 26);
            this.labelInstance.TabIndex = 70;
            this.labelInstance.Text = "SSAS instance";
            this.labelInstance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelUser
            // 
            this.labelUser.BorderColor = System.Drawing.Color.Black;
            this.labelUser.BorderHeightOffset = 2;
            this.labelUser.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelUser.BorderWidthOffset = 2;
            this.labelUser.DrawBorder = false;
            this.labelUser.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Location = new System.Drawing.Point(44, 41);
            this.labelUser.Margin = new System.Windows.Forms.Padding(0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(62, 26);
            this.labelUser.TabIndex = 84;
            this.labelUser.Text = "User Name";
            this.labelUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxBatchID
            // 
            this.comboBoxBatchID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxBatchID.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxBatchID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBatchID.Enabled = false;
            this.comboBoxBatchID.FormattingEnabled = true;
            this.comboBoxBatchID.Location = new System.Drawing.Point(142, 199);
            this.comboBoxBatchID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxBatchID.Name = "comboBoxBatchID";
            this.comboBoxBatchID.Size = new System.Drawing.Size(301, 21);
            this.comboBoxBatchID.Sorted = true;
            this.comboBoxBatchID.TabIndex = 86;
            this.comboBoxBatchID.DropDown += new System.EventHandler(this.OnComboBoxBatchID_DropDown);
            // 
            // comboBoxCube
            // 
            this.comboBoxCube.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCube.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxCube.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCube.Enabled = false;
            this.comboBoxCube.FormattingEnabled = true;
            this.comboBoxCube.Location = new System.Drawing.Point(142, 137);
            this.comboBoxCube.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxCube.Name = "comboBoxCube";
            this.comboBoxCube.Size = new System.Drawing.Size(301, 21);
            this.comboBoxCube.Sorted = true;
            this.comboBoxCube.TabIndex = 75;
            this.comboBoxCube.DropDown += new System.EventHandler(this.OnComboBoxCube_DropDown);
            // 
            // comboBoxDatabase
            // 
            this.comboBoxDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDatabase.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDatabase.Enabled = false;
            this.comboBoxDatabase.FormattingEnabled = true;
            this.comboBoxDatabase.Location = new System.Drawing.Point(142, 106);
            this.comboBoxDatabase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxDatabase.Name = "comboBoxDatabase";
            this.comboBoxDatabase.Size = new System.Drawing.Size(301, 21);
            this.comboBoxDatabase.Sorted = true;
            this.comboBoxDatabase.TabIndex = 73;
            this.comboBoxDatabase.DropDown += new System.EventHandler(this.OnComboBoxDatabase_DropDown);
            // 
            // comboBoxDate
            // 
            this.comboBoxDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDate.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDate.Enabled = false;
            this.comboBoxDate.FormattingEnabled = true;
            this.comboBoxDate.Location = new System.Drawing.Point(142, 13);
            this.comboBoxDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxDate.Name = "comboBoxDate";
            this.comboBoxDate.Size = new System.Drawing.Size(301, 21);
            this.comboBoxDate.Sorted = true;
            this.comboBoxDate.TabIndex = 3;
            this.comboBoxDate.DropDown += new System.EventHandler(this.OnComboBoxDate_DropDown);
            // 
            // comboBoxInstance
            // 
            this.comboBoxInstance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxInstance.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInstance.Enabled = false;
            this.comboBoxInstance.FormattingEnabled = true;
            this.comboBoxInstance.Location = new System.Drawing.Point(142, 75);
            this.comboBoxInstance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxInstance.Name = "comboBoxInstance";
            this.comboBoxInstance.Size = new System.Drawing.Size(301, 21);
            this.comboBoxInstance.Sorted = true;
            this.comboBoxInstance.TabIndex = 4;
            this.comboBoxInstance.DropDown += new System.EventHandler(this.OnComboBoxInstance_DropDown);
            // 
            // comboBoxUserName
            // 
            this.comboBoxUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxUserName.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUserName.Enabled = false;
            this.comboBoxUserName.FormattingEnabled = true;
            this.comboBoxUserName.Location = new System.Drawing.Point(142, 44);
            this.comboBoxUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxUserName.Name = "comboBoxUserName";
            this.comboBoxUserName.Size = new System.Drawing.Size(301, 21);
            this.comboBoxUserName.Sorted = true;
            this.comboBoxUserName.TabIndex = 4;
            this.comboBoxUserName.DropDown += new System.EventHandler(this.OnComboBoxUser_DropDown);
            // 
            // buttonAnalysisSearchRefresh
            // 
            this.buttonAnalysisSearchRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAnalysisSearchRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAnalysisSearchRefresh.Enabled = false;
            this.buttonAnalysisSearchRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnalysisSearchRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAnalysisSearchRefresh.Location = new System.Drawing.Point(272, 228);
            this.buttonAnalysisSearchRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAnalysisSearchRefresh.Name = "buttonAnalysisSearchRefresh";
            this.buttonAnalysisSearchRefresh.Size = new System.Drawing.Size(170, 28);
            this.buttonAnalysisSearchRefresh.TabIndex = 79;
            this.buttonAnalysisSearchRefresh.Text = "Refresh";
            this.buttonAnalysisSearchRefresh.UseVisualStyleBackColor = true;
            this.buttonAnalysisSearchRefresh.Click += new System.EventHandler(this.OnButtonRefresh_Click);
            // 
            // panelSearchAnalysisBottom
            // 
            this.panelSearchAnalysisBottom.BackColor = System.Drawing.Color.Black;
            this.panelSearchAnalysisBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSearchAnalysisBottom.Location = new System.Drawing.Point(0, 267);
            this.panelSearchAnalysisBottom.Name = "panelSearchAnalysisBottom";
            this.panelSearchAnalysisBottom.Size = new System.Drawing.Size(450, 1);
            this.panelSearchAnalysisBottom.TabIndex = 91;
            // 
            // panelAnalysisSearchTitle
            // 
            this.panelAnalysisSearchTitle.BackColor = System.Drawing.Color.Transparent;
            this.panelAnalysisSearchTitle.Controls.Add(this.pictureAnalysisSearch);
            this.panelAnalysisSearchTitle.Controls.Add(this.labelAnalysisSearchTitle);
            this.panelAnalysisSearchTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAnalysisSearchTitle.Location = new System.Drawing.Point(0, 0);
            this.panelAnalysisSearchTitle.Name = "panelAnalysisSearchTitle";
            this.panelAnalysisSearchTitle.Size = new System.Drawing.Size(450, 48);
            this.panelAnalysisSearchTitle.TabIndex = 92;
            // 
            // pictureAnalysisSearch
            // 
            this.pictureAnalysisSearch.Image = global::SSASQueryAnalyzer.Client.SSMS.VSPackage.Properties.Resources.SearchTest_32x32;
            this.pictureAnalysisSearch.Location = new System.Drawing.Point(8, 8);
            this.pictureAnalysisSearch.Name = "pictureAnalysisSearch";
            this.pictureAnalysisSearch.Size = new System.Drawing.Size(32, 32);
            this.pictureAnalysisSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureAnalysisSearch.TabIndex = 88;
            this.pictureAnalysisSearch.TabStop = false;
            // 
            // labelAnalysisSearchTitle
            // 
            this.labelAnalysisSearchTitle.BorderColor = System.Drawing.Color.Black;
            this.labelAnalysisSearchTitle.BorderHeightOffset = 2;
            this.labelAnalysisSearchTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelAnalysisSearchTitle.BorderWidthOffset = 2;
            this.labelAnalysisSearchTitle.DrawBorder = false;
            this.labelAnalysisSearchTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnalysisSearchTitle.Location = new System.Drawing.Point(44, 14);
            this.labelAnalysisSearchTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelAnalysisSearchTitle.Name = "labelAnalysisSearchTitle";
            this.labelAnalysisSearchTitle.Size = new System.Drawing.Size(110, 20);
            this.labelAnalysisSearchTitle.TabIndex = 87;
            this.labelAnalysisSearchTitle.Text = "Search an analysis";
            this.labelAnalysisSearchTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelLoadFromDb
            // 
            this.panelLoadFromDb.BackColor = System.Drawing.Color.Transparent;
            this.panelLoadFromDb.Controls.Add(this.checkBoxFilterControls);
            this.panelLoadFromDb.Controls.Add(this.pictureLoadFromDb);
            this.panelLoadFromDb.Controls.Add(this.customLabelLoadFromDbTitle);
            this.panelLoadFromDb.Controls.Add(this.panelLoadFromDbBottom);
            this.panelLoadFromDb.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLoadFromDb.Location = new System.Drawing.Point(0, 212);
            this.panelLoadFromDb.Name = "panelLoadFromDb";
            this.panelLoadFromDb.Size = new System.Drawing.Size(450, 48);
            this.panelLoadFromDb.TabIndex = 85;
            // 
            // checkBoxFilterControls
            // 
            this.checkBoxFilterControls.AutoSize = true;
            this.checkBoxFilterControls.Location = new System.Drawing.Point(44, 17);
            this.checkBoxFilterControls.Name = "checkBoxFilterControls";
            this.checkBoxFilterControls.Size = new System.Drawing.Size(110, 17);
            this.checkBoxFilterControls.TabIndex = 89;
            this.checkBoxFilterControls.Text = "Hide filter controls";
            this.checkBoxFilterControls.UseVisualStyleBackColor = true;
            this.checkBoxFilterControls.CheckedChanged += new System.EventHandler(this.OnCheckBoxFilterControls_CheckedChanged);
            // 
            // pictureLoadFromDb
            // 
            this.pictureLoadFromDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureLoadFromDb.Image = global::SSASQueryAnalyzer.Client.SSMS.VSPackage.Properties.Resources.LoadFromDB_32x32;
            this.pictureLoadFromDb.Location = new System.Drawing.Point(408, 8);
            this.pictureLoadFromDb.Name = "pictureLoadFromDb";
            this.pictureLoadFromDb.Size = new System.Drawing.Size(34, 34);
            this.pictureLoadFromDb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureLoadFromDb.TabIndex = 78;
            this.pictureLoadFromDb.TabStop = false;
            // 
            // customLabelLoadFromDbTitle
            // 
            this.customLabelLoadFromDbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customLabelLoadFromDbTitle.AutoSize = true;
            this.customLabelLoadFromDbTitle.BorderColor = System.Drawing.Color.Black;
            this.customLabelLoadFromDbTitle.BorderHeightOffset = 2;
            this.customLabelLoadFromDbTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.customLabelLoadFromDbTitle.BorderWidthOffset = 2;
            this.customLabelLoadFromDbTitle.DrawBorder = false;
            this.customLabelLoadFromDbTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabelLoadFromDbTitle.Location = new System.Drawing.Point(213, 19);
            this.customLabelLoadFromDbTitle.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelLoadFromDbTitle.Name = "customLabelLoadFromDbTitle";
            this.customLabelLoadFromDbTitle.Size = new System.Drawing.Size(194, 12);
            this.customLabelLoadFromDbTitle.TabIndex = 79;
            this.customLabelLoadFromDbTitle.Text = "Load Batch analysis from ASQA database";
            this.customLabelLoadFromDbTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panelLoadFromDbBottom
            // 
            this.panelLoadFromDbBottom.BackColor = System.Drawing.Color.Black;
            this.panelLoadFromDbBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLoadFromDbBottom.Location = new System.Drawing.Point(0, 47);
            this.panelLoadFromDbBottom.Name = "panelLoadFromDbBottom";
            this.panelLoadFromDbBottom.Size = new System.Drawing.Size(450, 1);
            this.panelLoadFromDbBottom.TabIndex = 86;
            // 
            // panelSQLInstance
            // 
            this.panelSQLInstance.Controls.Add(this.pictureSQLInstance);
            this.panelSQLInstance.Controls.Add(this.labelSQLInstanceTitle);
            this.panelSQLInstance.Controls.Add(this.labelSQLInstanceInfo);
            this.panelSQLInstance.Controls.Add(this.comboBoxSQLInstances);
            this.panelSQLInstance.Controls.Add(this.labelASQADBVersion);
            this.panelSQLInstance.Controls.Add(this.buttonASQADBInstall);
            this.panelSQLInstance.Controls.Add(this.buttonASQADBUninstall);
            this.panelSQLInstance.Controls.Add(this.panelSQLInstanceBottom);
            this.panelSQLInstance.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSQLInstance.Location = new System.Drawing.Point(0, 48);
            this.panelSQLInstance.Name = "panelSQLInstance";
            this.panelSQLInstance.Size = new System.Drawing.Size(450, 164);
            this.panelSQLInstance.TabIndex = 84;
            // 
            // pictureSQLInstance
            // 
            this.pictureSQLInstance.Image = global::SSASQueryAnalyzer.Client.SSMS.VSPackage.Properties.Resources.SQLServer_32x32;
            this.pictureSQLInstance.Location = new System.Drawing.Point(8, 8);
            this.pictureSQLInstance.Name = "pictureSQLInstance";
            this.pictureSQLInstance.Size = new System.Drawing.Size(34, 34);
            this.pictureSQLInstance.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureSQLInstance.TabIndex = 89;
            this.pictureSQLInstance.TabStop = false;
            // 
            // labelSQLInstanceTitle
            // 
            this.labelSQLInstanceTitle.AutoSize = true;
            this.labelSQLInstanceTitle.BorderColor = System.Drawing.Color.Black;
            this.labelSQLInstanceTitle.BorderHeightOffset = 2;
            this.labelSQLInstanceTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.labelSQLInstanceTitle.BorderWidthOffset = 2;
            this.labelSQLInstanceTitle.DrawBorder = false;
            this.labelSQLInstanceTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSQLInstanceTitle.Location = new System.Drawing.Point(44, 19);
            this.labelSQLInstanceTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelSQLInstanceTitle.Name = "labelSQLInstanceTitle";
            this.labelSQLInstanceTitle.Size = new System.Drawing.Size(97, 12);
            this.labelSQLInstanceTitle.TabIndex = 80;
            this.labelSQLInstanceTitle.Text = "SQL Server instance";
            this.labelSQLInstanceTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSQLInstanceInfo
            // 
            this.labelSQLInstanceInfo.AutoSize = true;
            this.labelSQLInstanceInfo.Location = new System.Drawing.Point(44, 45);
            this.labelSQLInstanceInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSQLInstanceInfo.Name = "labelSQLInstanceInfo";
            this.labelSQLInstanceInfo.Size = new System.Drawing.Size(259, 13);
            this.labelSQLInstanceInfo.TabIndex = 82;
            this.labelSQLInstanceInfo.Text = "Select the SQL Server instance to use in Batch mode";
            this.labelSQLInstanceInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxSQLInstances
            // 
            this.comboBoxSQLInstances.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSQLInstances.DisplayMember = "Item1.ServerName";
            this.comboBoxSQLInstances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSQLInstances.FormattingEnabled = true;
            this.comboBoxSQLInstances.Location = new System.Drawing.Point(43, 66);
            this.comboBoxSQLInstances.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSQLInstances.Name = "comboBoxSQLInstances";
            this.comboBoxSQLInstances.Size = new System.Drawing.Size(400, 21);
            this.comboBoxSQLInstances.Sorted = true;
            this.comboBoxSQLInstances.TabIndex = 76;
            this.comboBoxSQLInstances.DropDown += new System.EventHandler(this.OnComboBoxSQLInstances_DropDown);
            this.comboBoxSQLInstances.SelectionChangeCommitted += new System.EventHandler(this.OnComboBoxSQLInstances_SelectionChangeCommitted);
            this.comboBoxSQLInstances.DropDownClosed += new System.EventHandler(this.OnComboBoxSQLInstances_DropDownClosed);
            // 
            // labelASQADBVersion
            // 
            this.labelASQADBVersion.AutoSize = true;
            this.labelASQADBVersion.Location = new System.Drawing.Point(44, 97);
            this.labelASQADBVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelASQADBVersion.Name = "labelASQADBVersion";
            this.labelASQADBVersion.Size = new System.Drawing.Size(53, 13);
            this.labelASQADBVersion.TabIndex = 77;
            this.labelASQADBVersion.Text = "<version>";
            // 
            // buttonASQADBInstall
            // 
            this.buttonASQADBInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonASQADBInstall.Enabled = false;
            this.buttonASQADBInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonASQADBInstall.Location = new System.Drawing.Point(44, 124);
            this.buttonASQADBInstall.Margin = new System.Windows.Forms.Padding(4);
            this.buttonASQADBInstall.Name = "buttonASQADBInstall";
            this.buttonASQADBInstall.Size = new System.Drawing.Size(170, 28);
            this.buttonASQADBInstall.TabIndex = 78;
            this.buttonASQADBInstall.Text = "Install ASQA database";
            this.buttonASQADBInstall.UseVisualStyleBackColor = true;
            this.buttonASQADBInstall.Click += new System.EventHandler(this.OnButtonASQADBInstall_Click);
            // 
            // buttonASQADBUninstall
            // 
            this.buttonASQADBUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonASQADBUninstall.Enabled = false;
            this.buttonASQADBUninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonASQADBUninstall.Location = new System.Drawing.Point(272, 124);
            this.buttonASQADBUninstall.Margin = new System.Windows.Forms.Padding(4);
            this.buttonASQADBUninstall.Name = "buttonASQADBUninstall";
            this.buttonASQADBUninstall.Size = new System.Drawing.Size(170, 28);
            this.buttonASQADBUninstall.TabIndex = 79;
            this.buttonASQADBUninstall.Text = "Uninstall ASQA database";
            this.buttonASQADBUninstall.UseVisualStyleBackColor = true;
            this.buttonASQADBUninstall.Click += new System.EventHandler(this.OnButtonASQADBUninstall_Click);
            // 
            // panelSQLInstanceBottom
            // 
            this.panelSQLInstanceBottom.BackColor = System.Drawing.Color.Black;
            this.panelSQLInstanceBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSQLInstanceBottom.Location = new System.Drawing.Point(0, 163);
            this.panelSQLInstanceBottom.Name = "panelSQLInstanceBottom";
            this.panelSQLInstanceBottom.Size = new System.Drawing.Size(450, 1);
            this.panelSQLInstanceBottom.TabIndex = 90;
            // 
            // panelBatchMode
            // 
            this.panelBatchMode.BackColor = System.Drawing.Color.Transparent;
            this.panelBatchMode.Controls.Add(this.pictureBatchMode);
            this.panelBatchMode.Controls.Add(this.customLabelBatchModeTitle);
            this.panelBatchMode.Controls.Add(this.panelBatchModeBottom);
            this.panelBatchMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBatchMode.Location = new System.Drawing.Point(0, 0);
            this.panelBatchMode.Name = "panelBatchMode";
            this.panelBatchMode.Size = new System.Drawing.Size(450, 48);
            this.panelBatchMode.TabIndex = 83;
            // 
            // pictureBatchMode
            // 
            this.pictureBatchMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBatchMode.Image = global::SSASQueryAnalyzer.Client.SSMS.VSPackage.Properties.Resources.BatchMode_32x32;
            this.pictureBatchMode.Location = new System.Drawing.Point(408, 8);
            this.pictureBatchMode.Name = "pictureBatchMode";
            this.pictureBatchMode.Size = new System.Drawing.Size(34, 34);
            this.pictureBatchMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBatchMode.TabIndex = 78;
            this.pictureBatchMode.TabStop = false;
            // 
            // customLabelBatchModeTitle
            // 
            this.customLabelBatchModeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customLabelBatchModeTitle.AutoSize = true;
            this.customLabelBatchModeTitle.BorderColor = System.Drawing.Color.Black;
            this.customLabelBatchModeTitle.BorderHeightOffset = 2;
            this.customLabelBatchModeTitle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.customLabelBatchModeTitle.BorderWidthOffset = 2;
            this.customLabelBatchModeTitle.DrawBorder = false;
            this.customLabelBatchModeTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabelBatchModeTitle.Location = new System.Drawing.Point(275, 19);
            this.customLabelBatchModeTitle.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelBatchModeTitle.Name = "customLabelBatchModeTitle";
            this.customLabelBatchModeTitle.Size = new System.Drawing.Size(131, 12);
            this.customLabelBatchModeTitle.TabIndex = 79;
            this.customLabelBatchModeTitle.Text = "Batch mode configurations";
            this.customLabelBatchModeTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panelBatchModeBottom
            // 
            this.panelBatchModeBottom.BackColor = System.Drawing.Color.Black;
            this.panelBatchModeBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBatchModeBottom.Location = new System.Drawing.Point(0, 47);
            this.panelBatchModeBottom.Name = "panelBatchModeBottom";
            this.panelBatchModeBottom.Size = new System.Drawing.Size(450, 1);
            this.panelBatchModeBottom.TabIndex = 86;
            // 
            // AsqaHelperBatchModeControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.panelMaster);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AsqaHelperBatchModeControl";
            this.Size = new System.Drawing.Size(450, 730);
            this.panelMaster.ResumeLayout(false);
            this.panelAnalysisSearch.ResumeLayout(false);
            this.panelData.ResumeLayout(false);
            this.panelAnalysisSearchResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAnalysisData)).EndInit();
            this.panelAnalysisSearchCommands.ResumeLayout(false);
            this.panelQueryText.ResumeLayout(false);
            this.panelQueryTextCommands.ResumeLayout(false);
            this.panelAnalysisSearchParameters.ResumeLayout(false);
            this.panelAnalysisSearchParameters.PerformLayout();
            this.panelAnalysisSearchTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureAnalysisSearch)).EndInit();
            this.panelLoadFromDb.ResumeLayout(false);
            this.panelLoadFromDb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLoadFromDb)).EndInit();
            this.panelSQLInstance.ResumeLayout(false);
            this.panelSQLInstance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSQLInstance)).EndInit();
            this.panelBatchMode.ResumeLayout(false);
            this.panelBatchMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBatchMode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMaster;
        private System.Windows.Forms.Panel panelSQLInstance;
        private System.Windows.Forms.Label labelSQLInstanceInfo;
        private Common.Windows.Forms.CustomLabelControl labelSQLInstanceTitle;
        private System.Windows.Forms.Button buttonASQADBUninstall;
        private System.Windows.Forms.Button buttonASQADBInstall;
        private System.Windows.Forms.Label labelASQADBVersion;
        private System.Windows.Forms.ComboBox comboBoxSQLInstances;
        private System.Windows.Forms.Panel panelBatchMode;
        private Common.Windows.Forms.CustomLabelControl customLabelBatchModeTitle;
        private System.Windows.Forms.PictureBox pictureBatchMode;
        private System.Windows.Forms.Panel panelBatchModeBottom;
        private System.Windows.Forms.Panel panelSQLInstanceBottom;
        private Common.Windows.Forms.CustomLabelControl labelAnalysisSearchTitle;
        private System.Windows.Forms.PictureBox pictureAnalysisSearch;
        private System.Windows.Forms.PictureBox pictureSQLInstance;
        private System.Windows.Forms.Panel panelAnalysisSearchResult;
        private System.Windows.Forms.DataGridView gridViewAnalysisData;
        private System.Windows.Forms.Label labelAnalysisSearchRowsCount;
        private System.Windows.Forms.Panel panelAnalysisSearchCommands;
        private System.Windows.Forms.Panel panelAnalysisSearchCommandsTop;
        private System.Windows.Forms.Button buttonLoadAnalysisData;
        private System.Windows.Forms.Button buttonShowQuery;
        private System.Windows.Forms.Panel panelAnalysisSearchCommandsBottom;
        private System.Windows.Forms.Panel panelQueryText;
        private System.Windows.Forms.RichTextBox richTextBoxQuery;
        private System.Windows.Forms.Panel panelQueryTextCommands;
        private System.Windows.Forms.Panel panelQueryTextCommandsTop;
        private System.Windows.Forms.Button buttonBackFromQuery;
        private System.Windows.Forms.Panel panelQueryTextCommandsBottom;
        private System.Windows.Forms.Panel panelAnalysisSearchTitle;
        private System.Windows.Forms.CheckBox checkBoxFilterControls;
        private System.Windows.Forms.Panel panelAnalysisSearchParameters;
        private Common.Windows.Forms.CustomLabelControl labelAnalysisName;
        private System.Windows.Forms.ComboBox comboBoxAnalysisName;
        private Common.Windows.Forms.CustomLabelControl labelBatchID;
        private Common.Windows.Forms.CustomLabelControl labelCube;
        private Common.Windows.Forms.CustomLabelControl labelDatabase;
        private Common.Windows.Forms.CustomLabelControl labelDate;
        private Common.Windows.Forms.CustomLabelControl labelInstance;
        private Common.Windows.Forms.CustomLabelControl labelUser;
        private System.Windows.Forms.ComboBox comboBoxBatchID;
        private System.Windows.Forms.ComboBox comboBoxCube;
        private System.Windows.Forms.ComboBox comboBoxDatabase;
        private System.Windows.Forms.ComboBox comboBoxDate;
        private System.Windows.Forms.ComboBox comboBoxInstance;
        private System.Windows.Forms.ComboBox comboBoxUserName;
        private System.Windows.Forms.Button buttonAnalysisSearchRefresh;
        private System.Windows.Forms.Panel panelSearchAnalysisBottom;
        private System.Windows.Forms.Panel panelAnalysisSearch;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Panel panelLoadFromDb;
        private System.Windows.Forms.PictureBox pictureLoadFromDb;
        private Common.Windows.Forms.CustomLabelControl customLabelLoadFromDbTitle;
        private System.Windows.Forms.Panel panelLoadFromDbBottom;
        private System.Windows.Forms.CheckBox checkBoxResults;
    }
}
