namespace Integrador.UI.UserControls
{
    partial class LogsUserControl
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
            components = new System.ComponentModel.Container();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            lblSubtitle = new DevExpress.XtraEditors.LabelControl();
            sbFilter = new DevExpress.XtraEditors.SimpleButton();
            deEndDate = new DevExpress.XtraEditors.DateEdit();
            deStartDate = new DevExpress.XtraEditors.DateEdit();
            cbeLogType = new DevExpress.XtraEditors.ImageComboBoxEdit();
            gcLogs = new DevExpress.XtraGrid.GridControl();
            integratorLogsBindingSource = new BindingSource(components);
            gvLogs = new DevExpress.XtraGrid.Views.Grid.GridView();
            colTimestamp = new DevExpress.XtraGrid.Columns.GridColumn();
            colLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            colSource = new DevExpress.XtraGrid.Columns.GridColumn();
            colMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            colException = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            colPayload = new DevExpress.XtraGrid.Columns.GridColumn();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            lciTitle = new DevExpress.XtraLayout.LayoutControlItem();
            lciSubtitle = new DevExpress.XtraLayout.LayoutControlItem();
            lciLogType = new DevExpress.XtraLayout.LayoutControlItem();
            lciStartDate = new DevExpress.XtraLayout.LayoutControlItem();
            lciEndDate = new DevExpress.XtraLayout.LayoutControlItem();
            lciFilter = new DevExpress.XtraLayout.LayoutControlItem();
            esiFilters = new DevExpress.XtraLayout.EmptySpaceItem();
            lciLogs = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)deEndDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)deEndDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)deStartDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)deStartDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbeLogType.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gcLogs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)integratorLogsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvLogs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemMemoExEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciTitle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciSubtitle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciLogType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciStartDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciEndDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciFilter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)esiFilters).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciLogs).BeginInit();
            SuspendLayout();
            //
            // layoutControl1
            //
            layoutControl1.Controls.Add(lblTitle);
            layoutControl1.Controls.Add(lblSubtitle);
            layoutControl1.Controls.Add(sbFilter);
            layoutControl1.Controls.Add(deEndDate);
            layoutControl1.Controls.Add(deStartDate);
            layoutControl1.Controls.Add(cbeLogType);
            layoutControl1.Controls.Add(gcLogs);
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
            lblTitle.Size = new Size(42, 30);
            lblTitle.StyleController = layoutControl1;
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Logs";
            //
            // lblSubtitle
            //
            lblSubtitle.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.DisabledText;
            lblSubtitle.Appearance.Options.UseForeColor = true;
            lblSubtitle.Location = new Point(24, 62);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(330, 17);
            lblSubtitle.StyleController = layoutControl1;
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Registo de todas as etapas. Duplo clique numa linha para ver o detalhe.";
            //
            // cbeLogType
            //
            cbeLogType.Location = new Point(24, 117);
            cbeLogType.Name = "cbeLogType";
            cbeLogType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbeLogType.Size = new Size(156, 30);
            cbeLogType.StyleController = layoutControl1;
            cbeLogType.TabIndex = 2;
            //
            // deStartDate
            //
            deStartDate.EditValue = null;
            deStartDate.Location = new Point(192, 117);
            deStartDate.Name = "deStartDate";
            deStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            deStartDate.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            deStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            deStartDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm";
            deStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            deStartDate.Properties.EditFormat.FormatString = "dd-MM-yyyy HH:mm";
            deStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            deStartDate.Properties.MaskSettings.Set("mask", "dd-MM-yyyy HH:mm");
            deStartDate.Size = new Size(156, 30);
            deStartDate.StyleController = layoutControl1;
            deStartDate.TabIndex = 3;
            //
            // deEndDate
            //
            deEndDate.EditValue = null;
            deEndDate.Location = new Point(360, 117);
            deEndDate.Name = "deEndDate";
            deEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            deEndDate.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            deEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            deEndDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm";
            deEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            deEndDate.Properties.EditFormat.FormatString = "dd-MM-yyyy HH:mm";
            deEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            deEndDate.Properties.MaskSettings.Set("mask", "dd-MM-yyyy HH:mm");
            deEndDate.Size = new Size(156, 30);
            deEndDate.StyleController = layoutControl1;
            deEndDate.TabIndex = 4;
            //
            // sbFilter
            //
            sbFilter.Location = new Point(528, 117);
            sbFilter.Name = "sbFilter";
            sbFilter.Size = new Size(92, 30);
            sbFilter.StyleController = layoutControl1;
            sbFilter.TabIndex = 5;
            sbFilter.Text = "Filtrar";
            sbFilter.Click += sbFilter_Click;
            //
            // gcLogs
            //
            gcLogs.DataSource = integratorLogsBindingSource;
            gcLogs.Location = new Point(24, 163);
            gcLogs.MainView = gvLogs;
            gcLogs.Name = "gcLogs";
            gcLogs.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemMemoExEdit1 });
            gcLogs.Size = new Size(852, 413);
            gcLogs.TabIndex = 6;
            gcLogs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvLogs });
            //
            // integratorLogsBindingSource
            //
            integratorLogsBindingSource.DataSource = typeof(Integrador.Common.Logging.IntegratorLog);
            //
            // gvLogs
            //
            gvLogs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colTimestamp, colLevel, colSource, colMessage, colException, colPayload });
            gvLogs.GridControl = gcLogs;
            gvLogs.Name = "gvLogs";
            gvLogs.OptionsBehavior.Editable = false;
            gvLogs.OptionsBehavior.ReadOnly = true;
            gvLogs.OptionsFind.AlwaysVisible = true;
            gvLogs.OptionsFind.FindNullPrompt = "Pesquisar nas logs...";
            gvLogs.OptionsFind.ShowFindButton = false;
            gvLogs.RowCellStyle += gvLogs_RowCellStyle;
            gvLogs.CustomColumnDisplayText += gvLogs_CustomColumnDisplayText;
            gvLogs.DoubleClick += gvLogs_DoubleClick;
            //
            // colTimestamp
            //
            colTimestamp.Caption = "Data";
            colTimestamp.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss";
            colTimestamp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colTimestamp.FieldName = "LoggedAt";
            colTimestamp.GroupFormat.FormatString = "dd-MM-yyyy HH:mm:ss";
            colTimestamp.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colTimestamp.Name = "colTimestamp";
            colTimestamp.Visible = true;
            colTimestamp.VisibleIndex = 0;
            colTimestamp.Width = 140;
            //
            // colLevel
            //
            colLevel.AppearanceCell.Font = new Font("Segoe UI Semibold", 9.75F);
            colLevel.AppearanceCell.Options.UseFont = true;
            colLevel.Caption = "Nível";
            colLevel.FieldName = "Level";
            colLevel.Name = "colLevel";
            colLevel.Visible = true;
            colLevel.VisibleIndex = 1;
            colLevel.Width = 100;
            //
            // colSource
            //
            colSource.Caption = "Origem";
            colSource.FieldName = "Source";
            colSource.Name = "colSource";
            colSource.Visible = true;
            colSource.VisibleIndex = 2;
            colSource.Width = 140;
            //
            // colMessage
            //
            colMessage.Caption = "Mensagem";
            colMessage.FieldName = "Message";
            colMessage.Name = "colMessage";
            colMessage.Visible = true;
            colMessage.VisibleIndex = 3;
            colMessage.Width = 360;
            //
            // colException
            //
            colException.Caption = "Exceção";
            colException.ColumnEdit = repositoryItemMemoExEdit1;
            colException.FieldName = "Exception";
            colException.Name = "colException";
            colException.Visible = true;
            colException.VisibleIndex = 4;
            colException.Width = 160;
            //
            // repositoryItemMemoExEdit1
            //
            repositoryItemMemoExEdit1.AutoHeight = false;
            repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            //
            // colPayload
            //
            colPayload.Caption = "Payload";
            colPayload.FieldName = "Payload";
            colPayload.Name = "colPayload";
            colPayload.Width = 72;
            //
            // Root
            //
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lciTitle, lciSubtitle, lciLogType, lciStartDate, lciEndDate, lciFilter, esiFilters, lciLogs });
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
            lciTitle.Size = new Size(856, 38);
            lciTitle.TextVisible = false;
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
            // lciLogType
            //
            lciLogType.Control = cbeLogType;
            lciLogType.Location = new Point(0, 69);
            lciLogType.MaxSize = new Size(168, 0);
            lciLogType.MinSize = new Size(168, 56);
            lciLogType.Name = "lciLogType";
            lciLogType.Size = new Size(168, 56);
            lciLogType.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lciLogType.Text = "Nível";
            lciLogType.TextLocation = DevExpress.Utils.Locations.Top;
            lciLogType.TextSize = new Size(60, 17);
            //
            // lciStartDate
            //
            lciStartDate.Control = deStartDate;
            lciStartDate.Location = new Point(168, 69);
            lciStartDate.MaxSize = new Size(168, 0);
            lciStartDate.MinSize = new Size(168, 56);
            lciStartDate.Name = "lciStartDate";
            lciStartDate.Size = new Size(168, 56);
            lciStartDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lciStartDate.Text = "Desde";
            lciStartDate.TextLocation = DevExpress.Utils.Locations.Top;
            lciStartDate.TextSize = new Size(60, 17);
            //
            // lciEndDate
            //
            lciEndDate.Control = deEndDate;
            lciEndDate.Location = new Point(336, 69);
            lciEndDate.MaxSize = new Size(168, 0);
            lciEndDate.MinSize = new Size(168, 56);
            lciEndDate.Name = "lciEndDate";
            lciEndDate.Size = new Size(168, 56);
            lciEndDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lciEndDate.Text = "Até";
            lciEndDate.TextLocation = DevExpress.Utils.Locations.Top;
            lciEndDate.TextSize = new Size(60, 17);
            //
            // lciFilter
            //
            lciFilter.Control = sbFilter;
            lciFilter.ControlAlignment = ContentAlignment.BottomLeft;
            lciFilter.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 12);
            lciFilter.FillControlToClientArea = false;
            lciFilter.Location = new Point(504, 69);
            lciFilter.MaxSize = new Size(104, 0);
            lciFilter.MinSize = new Size(104, 56);
            lciFilter.Name = "lciFilter";
            lciFilter.Size = new Size(104, 56);
            lciFilter.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lciFilter.TextVisible = false;
            //
            // esiFilters
            //
            esiFilters.Location = new Point(608, 69);
            esiFilters.Name = "esiFilters";
            esiFilters.Size = new Size(248, 56);
            //
            // lciLogs
            //
            lciLogs.Control = gcLogs;
            lciLogs.Location = new Point(0, 125);
            lciLogs.Name = "lciLogs";
            lciLogs.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 14, 2);
            lciLogs.Size = new Size(856, 431);
            lciLogs.TextVisible = false;
            //
            // LogsUserControl
            //
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Name = "LogsUserControl";
            Size = new Size(900, 600);
            Load += LogsUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            layoutControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)deEndDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)deEndDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)deStartDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)deStartDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbeLogType.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gcLogs).EndInit();
            ((System.ComponentModel.ISupportInitialize)integratorLogsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvLogs).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemMemoExEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciTitle).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciSubtitle).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciLogType).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciStartDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciEndDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciFilter).EndInit();
            ((System.ComponentModel.ISupportInitialize)esiFilters).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciLogs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblSubtitle;
        private DevExpress.XtraGrid.GridControl gcLogs;
        private BindingSource integratorLogsBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLogs;
        private DevExpress.XtraGrid.Columns.GridColumn colTimestamp;
        private DevExpress.XtraGrid.Columns.GridColumn colLevel;
        private DevExpress.XtraGrid.Columns.GridColumn colSource;
        private DevExpress.XtraGrid.Columns.GridColumn colMessage;
        private DevExpress.XtraGrid.Columns.GridColumn colException;
        private DevExpress.XtraGrid.Columns.GridColumn colPayload;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraEditors.DateEdit deEndDate;
        private DevExpress.XtraEditors.DateEdit deStartDate;
        private DevExpress.XtraEditors.ImageComboBoxEdit cbeLogType;
        private DevExpress.XtraEditors.SimpleButton sbFilter;
        private DevExpress.XtraLayout.LayoutControlItem lciTitle;
        private DevExpress.XtraLayout.LayoutControlItem lciSubtitle;
        private DevExpress.XtraLayout.LayoutControlItem lciLogType;
        private DevExpress.XtraLayout.LayoutControlItem lciStartDate;
        private DevExpress.XtraLayout.LayoutControlItem lciEndDate;
        private DevExpress.XtraLayout.LayoutControlItem lciFilter;
        private DevExpress.XtraLayout.EmptySpaceItem esiFilters;
        private DevExpress.XtraLayout.LayoutControlItem lciLogs;
    }
}
