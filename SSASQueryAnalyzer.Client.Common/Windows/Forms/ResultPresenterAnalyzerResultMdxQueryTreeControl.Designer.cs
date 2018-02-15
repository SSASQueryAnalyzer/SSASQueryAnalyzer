namespace SSASQueryAnalyzer.Client.Common.Windows.Forms
{
    using SSASQueryAnalyzer.Client.Common.Infrastructure.Configuration;

    partial class ResultPresenterAnalyzerResultMdxQueryTreeControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultPresenterAnalyzerResultMdxQueryTreeControl));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Format String");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Value");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Measure 01", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Value");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Measure 02", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Value");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Measure 03", new System.Windows.Forms.TreeNode[] {
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Format String");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Value");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Measure 04", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Value");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Measure 05", new System.Windows.Forms.TreeNode[] {
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Measures", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode10,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Measure 06");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("MDX Query", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode5,
            treeNode13,
            treeNode14});
            this.MDXQueryIcons = new System.Windows.Forms.ImageList(this.components);
            this.MDXQuerySelectedIcons = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanelGlobal = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MDXQueryTreeView = new System.Windows.Forms.TreeView();
            this.tableLayoutPanelGlobal.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MDXQueryIcons
            // 
            this.MDXQueryIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MDXQueryIcons.ImageStream")));
            this.MDXQueryIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.MDXQueryIcons.Images.SetKeyName(0, "Measure-Green32.png");
            this.MDXQueryIcons.Images.SetKeyName(1, "Measure-Orange32.png");
            this.MDXQueryIcons.Images.SetKeyName(2, "Measure-Red32.png");
            this.MDXQueryIcons.Images.SetKeyName(3, "CalculatedMeasure-Green32.png");
            this.MDXQueryIcons.Images.SetKeyName(4, "CalculatedMeasure-Orange32.png");
            this.MDXQueryIcons.Images.SetKeyName(5, "CalculatedMeasure-Red32.png");
            this.MDXQueryIcons.Images.SetKeyName(6, "MultipleMeasure-Green32.png");
            this.MDXQueryIcons.Images.SetKeyName(7, "MultipleMeasure-Orange32.png");
            this.MDXQueryIcons.Images.SetKeyName(8, "MultipleMeasure-Red32.png");
            this.MDXQueryIcons.Images.SetKeyName(9, "MDXQuery32.png");
            this.MDXQueryIcons.Images.SetKeyName(10, "Property32.png");
            // 
            // MDXQuerySelectedIcons
            // 
            this.MDXQuerySelectedIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.MDXQuerySelectedIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.MDXQuerySelectedIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tableLayoutPanelGlobal
            // 
            this.tableLayoutPanelGlobal.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanelGlobal.ColumnCount = 1;
            this.tableLayoutPanelGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGlobal.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanelGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGlobal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelGlobal.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelGlobal.Name = "tableLayoutPanelGlobal";
            this.tableLayoutPanelGlobal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableLayoutPanelGlobal.RowCount = 1;
            this.tableLayoutPanelGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelGlobal.Size = new System.Drawing.Size(849, 474);
            this.tableLayoutPanelGlobal.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MDXQueryTreeView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 468);
            this.panel1.TabIndex = 0;
            // 
            // MDXQueryTreeView
            // 
            this.MDXQueryTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MDXQueryTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MDXQueryTreeView.ImageIndex = 0;
            this.MDXQueryTreeView.ImageList = this.MDXQueryIcons;
            this.MDXQueryTreeView.Location = new System.Drawing.Point(0, 0);
            this.MDXQueryTreeView.Name = "MDXQueryTreeView";
            treeNode1.ImageKey = "Property32.png";
            treeNode1.Name = "Node2";
            treeNode1.SelectedImageKey = "Property32.png";
            treeNode1.Text = "Format String";
            treeNode2.ImageKey = "Property32.png";
            treeNode2.Name = "Node3";
            treeNode2.SelectedImageKey = "Property32.png";
            treeNode2.Text = "Value";
            treeNode3.ImageKey = "Measure-Green32.png";
            treeNode3.Name = "Node1";
            treeNode3.SelectedImageKey = "Measure-Green32.png";
            treeNode3.Text = "Measure 01";
            treeNode4.ImageKey = "Property32.png";
            treeNode4.Name = "Node5";
            treeNode4.SelectedImageKey = "Property32.png";
            treeNode4.Text = "Value";
            treeNode5.ImageKey = "CalculatedMeasure-Red32.png";
            treeNode5.Name = "Node4";
            treeNode5.SelectedImageKey = "CalculatedMeasure-Red32.png";
            treeNode5.Text = "Measure 02";
            treeNode6.ImageKey = "Property32.png";
            treeNode6.Name = "Node8";
            treeNode6.SelectedImageKey = "Property32.png";
            treeNode6.Text = "Value";
            treeNode7.ImageKey = "Measure-Green32.png";
            treeNode7.Name = "Node7";
            treeNode7.SelectedImageKey = "Measure-Green32.png";
            treeNode7.Text = "Measure 03";
            treeNode8.ImageKey = "Property32.png";
            treeNode8.Name = "Node10";
            treeNode8.SelectedImageKey = "Property32.png";
            treeNode8.Text = "Format String";
            treeNode9.ImageKey = "Property32.png";
            treeNode9.Name = "Node11";
            treeNode9.SelectedImageKey = "Property32.png";
            treeNode9.Text = "Value";
            treeNode10.ImageKey = "Measure-Orange32.png";
            treeNode10.Name = "Node9";
            treeNode10.SelectedImageKey = "Measure-Orange32.png";
            treeNode10.Text = "Measure 04";
            treeNode11.ImageKey = "Property32.png";
            treeNode11.Name = "Node13";
            treeNode11.SelectedImageKey = "Property32.png";
            treeNode11.Text = "Value";
            treeNode12.ImageKey = "Measure-Orange32.png";
            treeNode12.Name = "Node12";
            treeNode12.SelectedImageKey = "Measure-Orange32.png";
            treeNode12.Text = "Measure 05";
            treeNode13.ImageKey = "MultipleMeasure-Orange32.png";
            treeNode13.Name = "Node6";
            treeNode13.SelectedImageKey = "MultipleMeasure-Orange32.png";
            treeNode13.Text = "Measures";
            treeNode14.ImageKey = "CalculatedMeasure-Green32.png";
            treeNode14.Name = "Node14";
            treeNode14.SelectedImageKey = "CalculatedMeasure-Green32.png";
            treeNode14.Text = "Measure 06";
            treeNode15.ImageKey = "MDXQuery32.png";
            treeNode15.Name = "MDXQueryRoot";
            treeNode15.SelectedImageKey = "MDXQuery32.png";
            treeNode15.Text = "MDX Query";
            this.MDXQueryTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode15});
            this.MDXQueryTreeView.SelectedImageIndex = 0;
            this.MDXQueryTreeView.Size = new System.Drawing.Size(843, 468);
            this.MDXQueryTreeView.StateImageList = this.MDXQuerySelectedIcons;
            this.MDXQueryTreeView.TabIndex = 1;
            // 
            // ResultPresenterAnalyzerResultMdxQueryTreeControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.tableLayoutPanelGlobal);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ResultPresenterAnalyzerResultMdxQueryTreeControl";
            this.Size = new System.Drawing.Size(849, 474);
            this.tableLayoutPanelGlobal.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList MDXQueryIcons;
        private System.Windows.Forms.ImageList MDXQuerySelectedIcons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGlobal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView MDXQueryTreeView;

    }
}
