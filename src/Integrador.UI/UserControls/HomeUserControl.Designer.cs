namespace Integrador.UI.UserControls
{
    partial class HomeUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeUserControl));
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            lblSubtitle = new DevExpress.XtraEditors.LabelControl();
            sbRunNow = new DevExpress.XtraEditors.SimpleButton();
            sbRefresh = new DevExpress.XtraEditors.SimpleButton();
            hccStatus = new DevExpress.XtraEditors.HtmlContentControl();
            lblRunsTitle = new DevExpress.XtraEditors.LabelControl();
            gcRuns = new DevExpress.XtraGrid.GridControl();
            gvRuns = new DevExpress.XtraGrid.Views.Grid.GridView();
            colStartedAt = new DevExpress.XtraGrid.Columns.GridColumn();
            colDuration = new DevExpress.XtraGrid.Columns.GridColumn();
            colTrigger = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            lciTitle = new DevExpress.XtraLayout.LayoutControlItem();
            lciSubtitle = new DevExpress.XtraLayout.LayoutControlItem();
            lciRefresh = new DevExpress.XtraLayout.LayoutControlItem();
            lciRunNow = new DevExpress.XtraLayout.LayoutControlItem();
            lciStatus = new DevExpress.XtraLayout.LayoutControlItem();
            lciRunsTitle = new DevExpress.XtraLayout.LayoutControlItem();
            lciRuns = new DevExpress.XtraLayout.LayoutControlItem();
            esiHeader = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)hccStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gcRuns).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvRuns).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciTitle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciSubtitle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciRefresh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciRunNow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciRunsTitle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciRuns).BeginInit();
            ((System.ComponentModel.ISupportInitialize)esiHeader).BeginInit();
            SuspendLayout();
            //
            // layoutControl1
            //
            layoutControl1.Controls.Add(lblTitle);
            layoutControl1.Controls.Add(lblSubtitle);
            layoutControl1.Controls.Add(sbRunNow);
            layoutControl1.Controls.Add(sbRefresh);
            layoutControl1.Controls.Add(hccStatus);
            layoutControl1.Controls.Add(lblRunsTitle);
            layoutControl1.Controls.Add(gcRuns);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(900, 600);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            //
            // lblTitle
            //
            lblTitle.Appearance.Font = new Font("Segoe UI Semibold", 15.75F);
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Location = new Point(24, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(54, 30);
            lblTitle.StyleController = layoutControl1;
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Início";
            //
            // lblSubtitle
            //
            lblSubtitle.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.DisabledText;
            lblSubtitle.Appearance.Options.UseForeColor = true;
            lblSubtitle.Location = new Point(24, 60);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(240, 17);
            lblSubtitle.StyleController = layoutControl1;
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Estado das ligações e últimas execuções";
            //
            // sbRunNow
            //
            sbRunNow.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            sbRunNow.Appearance.Options.UseBackColor = true;
            sbRunNow.Location = new Point(708, 24);
            sbRunNow.Name = "sbRunNow";
            sbRunNow.Size = new Size(168, 34);
            sbRunNow.StyleController = layoutControl1;
            sbRunNow.TabIndex = 3;
            sbRunNow.Text = "Executar integração";
            sbRunNow.Click += sbRunNow_Click;
            //
            // sbRefresh
            //
            sbRefresh.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("sbRefresh.ImageOptions.SvgImage");
            sbRefresh.ImageOptions.SvgImageSize = new Size(16, 16);
            sbRefresh.Location = new Point(592, 24);
            sbRefresh.Name = "sbRefresh";
            sbRefresh.Size = new Size(108, 34);
            sbRefresh.StyleController = layoutControl1;
            sbRefresh.TabIndex = 2;
            sbRefresh.Text = "Atualizar";
            sbRefresh.Click += sbRefresh_Click;
            //
            // hccStatus
            //
            hccStatus.HtmlTemplate.Styles = resources.GetString("hccStatus.HtmlTemplate.Styles");
            hccStatus.HtmlTemplate.Template = resources.GetString("hccStatus.HtmlTemplate.Template");
            hccStatus.Location = new Point(24, 93);
            hccStatus.Name = "hccStatus";
            hccStatus.Size = new Size(852, 96);
            hccStatus.TabIndex = 4;
            //
            // lblRunsTitle
            //
            lblRunsTitle.Appearance.Font = new Font("Segoe UI Semibold", 11.25F);
            lblRunsTitle.Appearance.Options.UseFont = true;
            lblRunsTitle.Location = new Point(24, 213);
            lblRunsTitle.Name = "lblRunsTitle";
            lblRunsTitle.Size = new Size(127, 20);
            lblRunsTitle.StyleController = layoutControl1;
            lblRunsTitle.TabIndex = 5;
            lblRunsTitle.Text = "Últimas execuções";
            //
            // gcRuns
            //
            gcRuns.Location = new Point(24, 241);
            gcRuns.MainView = gvRuns;
            gcRuns.Name = "gcRuns";
            gcRuns.Size = new Size(852, 335);
            gcRuns.TabIndex = 6;
            gcRuns.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvRuns });
            //
            // gvRuns
            //
            gvRuns.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colStartedAt, colDuration, colTrigger, colStatus, colMessage });
            gvRuns.GridControl = gcRuns;
            gvRuns.Name = "gvRuns";
            gvRuns.OptionsBehavior.Editable = false;
            gvRuns.OptionsBehavior.ReadOnly = true;
            gvRuns.CustomColumnDisplayText += gvRuns_CustomColumnDisplayText;
            gvRuns.RowCellStyle += gvRuns_RowCellStyle;
            //
            // colStartedAt
            //
            colStartedAt.Caption = "Início";
            colStartedAt.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            colStartedAt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colStartedAt.FieldName = "StartedAt";
            colStartedAt.Name = "colStartedAt";
            colStartedAt.Visible = true;
            colStartedAt.VisibleIndex = 0;
            colStartedAt.Width = 150;
            //
            // colDuration
            //
            colDuration.Caption = "Duração";
            colDuration.FieldName = "Duration";
            colDuration.Name = "colDuration";
            colDuration.Visible = true;
            colDuration.VisibleIndex = 1;
            colDuration.Width = 90;
            //
            // colTrigger
            //
            colTrigger.Caption = "Origem";
            colTrigger.FieldName = "Trigger";
            colTrigger.Name = "colTrigger";
            colTrigger.Visible = true;
            colTrigger.VisibleIndex = 2;
            colTrigger.Width = 90;
            //
            // colStatus
            //
            colStatus.AppearanceCell.Font = new Font("Segoe UI Semibold", 9.75F);
            colStatus.AppearanceCell.Options.UseFont = true;
            colStatus.Caption = "Estado";
            colStatus.FieldName = "Status";
            colStatus.Name = "colStatus";
            colStatus.Visible = true;
            colStatus.VisibleIndex = 3;
            colStatus.Width = 100;
            //
            // colMessage
            //
            colMessage.Caption = "Mensagem";
            colMessage.FieldName = "Message";
            colMessage.Name = "colMessage";
            colMessage.Visible = true;
            colMessage.VisibleIndex = 4;
            colMessage.Width = 420;
            //
            // Root
            //
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lciTitle, esiHeader, lciRefresh, lciRunNow, lciSubtitle, lciStatus, lciRunsTitle, lciRuns });
            Root.Name = "Root";
            Root.Padding = new DevExpress.XtraLayout.Utils.Padding(22, 22, 22, 22);
            Root.Size = new Size(900, 600);
            Root.TextVisible = false;
            //
            // lciTitle
            //
            lciTitle.Control = lblTitle;
            lciTitle.Location = new Point(0, 0);
            lciTitle.Name = "lciTitle";
            lciTitle.Size = new Size(120, 38);
            lciTitle.TextVisible = false;
            //
            // esiHeader
            //
            esiHeader.Location = new Point(120, 0);
            esiHeader.Name = "esiHeader";
            esiHeader.Size = new Size(448, 38);
            //
            // lciRefresh
            //
            lciRefresh.Control = sbRefresh;
            lciRefresh.Location = new Point(568, 0);
            lciRefresh.MaxSize = new Size(112, 38);
            lciRefresh.MinSize = new Size(112, 38);
            lciRefresh.Name = "lciRefresh";
            lciRefresh.Size = new Size(112, 38);
            lciRefresh.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lciRefresh.TextVisible = false;
            //
            // lciRunNow
            //
            lciRunNow.Control = sbRunNow;
            lciRunNow.Location = new Point(680, 0);
            lciRunNow.MaxSize = new Size(176, 38);
            lciRunNow.MinSize = new Size(176, 38);
            lciRunNow.Name = "lciRunNow";
            lciRunNow.Size = new Size(176, 38);
            lciRunNow.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lciRunNow.TextVisible = false;
            //
            // lciSubtitle
            //
            lciSubtitle.Control = lblSubtitle;
            lciSubtitle.Location = new Point(0, 38);
            lciSubtitle.Name = "lciSubtitle";
            lciSubtitle.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 0, 12);
            lciSubtitle.Size = new Size(856, 31);
            lciSubtitle.TextVisible = false;
            //
            // lciStatus
            //
            lciStatus.Control = hccStatus;
            lciStatus.Location = new Point(0, 69);
            lciStatus.MaxSize = new Size(0, 100);
            lciStatus.MinSize = new Size(200, 100);
            lciStatus.Name = "lciStatus";
            lciStatus.Size = new Size(856, 100);
            lciStatus.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lciStatus.TextVisible = false;
            //
            // lciRunsTitle
            //
            lciRunsTitle.Control = lblRunsTitle;
            lciRunsTitle.Location = new Point(0, 169);
            lciRunsTitle.Name = "lciRunsTitle";
            lciRunsTitle.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 20, 6);
            lciRunsTitle.Size = new Size(856, 50);
            lciRunsTitle.TextVisible = false;
            //
            // lciRuns
            //
            lciRuns.Control = gcRuns;
            lciRuns.Location = new Point(0, 219);
            lciRuns.Name = "lciRuns";
            lciRuns.Size = new Size(856, 337);
            lciRuns.TextVisible = false;
            //
            // HomeUserControl
            //
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "HomeUserControl";
            Size = new Size(900, 600);
            Load += HomeUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            layoutControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)hccStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)gcRuns).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvRuns).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciTitle).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciSubtitle).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciRefresh).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciRunNow).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciRunsTitle).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciRuns).EndInit();
            ((System.ComponentModel.ISupportInitialize)esiHeader).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblSubtitle;
        private DevExpress.XtraEditors.SimpleButton sbRunNow;
        private DevExpress.XtraEditors.SimpleButton sbRefresh;
        private DevExpress.XtraEditors.HtmlContentControl hccStatus;
        private DevExpress.XtraEditors.LabelControl lblRunsTitle;
        private DevExpress.XtraGrid.GridControl gcRuns;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRuns;
        private DevExpress.XtraGrid.Columns.GridColumn colStartedAt;
        private DevExpress.XtraGrid.Columns.GridColumn colDuration;
        private DevExpress.XtraGrid.Columns.GridColumn colTrigger;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colMessage;
        private DevExpress.XtraLayout.LayoutControlItem lciTitle;
        private DevExpress.XtraLayout.LayoutControlItem lciSubtitle;
        private DevExpress.XtraLayout.LayoutControlItem lciRefresh;
        private DevExpress.XtraLayout.LayoutControlItem lciRunNow;
        private DevExpress.XtraLayout.LayoutControlItem lciStatus;
        private DevExpress.XtraLayout.LayoutControlItem lciRunsTitle;
        private DevExpress.XtraLayout.LayoutControlItem lciRuns;
        private DevExpress.XtraLayout.EmptySpaceItem esiHeader;
    }
}
