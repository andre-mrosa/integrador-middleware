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
            beSearch = new DevExpress.XtraEditors.ButtonEdit();
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
            esiFilters = new DevExpress.XtraLayout.EmptySpaceItem();
            lciSearch = new DevExpress.XtraLayout.LayoutControlItem();
            lciLogs = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)deEndDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)deEndDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)deStartDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)deStartDate.Properties.CalendarTimeProperties).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)beSearch.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)esiFilters).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciLogs).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(lblTitle);
            layoutControl1.Controls.Add(lblSubtitle);
            layoutControl1.Controls.Add(beSearch);
            layoutControl1.Controls.Add(deEndDate);
            layoutControl1.Controls.Add(deStartDate);
            layoutControl1.Controls.Add(cbeLogType);
            layoutControl1.Controls.Add(gcLogs);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Margin = new Padding(3, 2, 3, 2);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(771, 459);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // lblTitle
            // 
            lblTitle.Appearance.Font = new Font("Segoe UI Semibold", 15.75F);
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Location = new Point(16, 16);
            lblTitle.Margin = new Padding(3, 2, 3, 2);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(45, 30);
            lblTitle.StyleController = layoutControl1;
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Logs";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.DisabledText;
            lblSubtitle.Appearance.Options.UseForeColor = true;
            lblSubtitle.Location = new Point(16, 52);
            lblSubtitle.Margin = new Padding(3, 2, 3, 2);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(345, 13);
            lblSubtitle.StyleController = layoutControl1;
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Registo de todas as etapas. Duplo clique numa linha para ver o detalhe.";
            //
            // beSearch
            //
            beSearch.Location = new Point(561, 90);
            beSearch.Margin = new Padding(3, 2, 3, 2);
            beSearch.Name = "beSearch";
            beSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search) });
            beSearch.Properties.NullValuePrompt = "Pesquisar nas logs...";
            beSearch.Size = new Size(194, 28);
            beSearch.StyleController = layoutControl1;
            beSearch.TabIndex = 6;
            beSearch.EditValueChanged += beSearch_EditValueChanged;
            // 
            // deEndDate
            // 
            deEndDate.EditValue = null;
            deEndDate.Location = new Point(307, 90);
            deEndDate.Margin = new Padding(3, 2, 3, 2);
            deEndDate.Name = "deEndDate";
            deEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            deEndDate.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            deEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            deEndDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm";
            deEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            deEndDate.Properties.EditFormat.FormatString = "dd-MM-yyyy HH:mm";
            deEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            deEndDate.Properties.MaskSettings.Set("mask", "dd-MM-yyyy HH:mm");
            deEndDate.Size = new Size(141, 28);
            deEndDate.StyleController = layoutControl1;
            deEndDate.TabIndex = 4;
            deEndDate.EditValueChanged += Filter_Changed;
            // 
            // deStartDate
            // 
            deStartDate.EditValue = null;
            deStartDate.Location = new Point(160, 90);
            deStartDate.Margin = new Padding(3, 2, 3, 2);
            deStartDate.Name = "deStartDate";
            deStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            deStartDate.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            deStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            deStartDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm";
            deStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            deStartDate.Properties.EditFormat.FormatString = "dd-MM-yyyy HH:mm";
            deStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            deStartDate.Properties.MaskSettings.Set("mask", "dd-MM-yyyy HH:mm");
            deStartDate.Size = new Size(141, 28);
            deStartDate.StyleController = layoutControl1;
            deStartDate.TabIndex = 3;
            deStartDate.EditValueChanged += Filter_Changed;
            // 
            // cbeLogType
            // 
            cbeLogType.Location = new Point(16, 90);
            cbeLogType.Margin = new Padding(3, 2, 3, 2);
            cbeLogType.Name = "cbeLogType";
            cbeLogType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbeLogType.Size = new Size(138, 28);
            cbeLogType.StyleController = layoutControl1;
            cbeLogType.TabIndex = 2;
            cbeLogType.SelectedIndexChanged += Filter_Changed;
            // 
            // gcLogs
            // 
            gcLogs.DataSource = integratorLogsBindingSource;
            gcLogs.EmbeddedNavigator.Margin = new Padding(3, 2, 3, 2);
            gcLogs.Location = new Point(16, 117);
            gcLogs.MainView = gvLogs;
            gcLogs.Margin = new Padding(3, 2, 3, 2);
            gcLogs.Name = "gcLogs";
            gcLogs.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemMemoExEdit1 });
            gcLogs.Size = new Size(739, 326);
            gcLogs.TabIndex = 6;
            gcLogs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvLogs });
            // 
            // integratorLogsBindingSource
            // 
            integratorLogsBindingSource.DataSource = typeof(Common.Logging.IntegratorLog);
            // 
            // gvLogs
            // 
            gvLogs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colTimestamp, colLevel, colSource, colMessage, colException, colPayload });
            gvLogs.DetailHeight = 268;
            gvLogs.GridControl = gcLogs;
            gvLogs.Name = "gvLogs";
            gvLogs.OptionsBehavior.Editable = false;
            gvLogs.OptionsBehavior.ReadOnly = true;
            gvLogs.OptionsEditForm.PopupEditFormWidth = 686;
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
            colTimestamp.MinWidth = 17;
            colTimestamp.Name = "colTimestamp";
            colTimestamp.Visible = true;
            colTimestamp.VisibleIndex = 0;
            colTimestamp.Width = 120;
            // 
            // colLevel
            // 
            colLevel.AppearanceCell.Font = new Font("Segoe UI Semibold", 9.75F);
            colLevel.AppearanceCell.Options.UseFont = true;
            colLevel.Caption = "Nível";
            colLevel.FieldName = "Level";
            colLevel.MinWidth = 17;
            colLevel.Name = "colLevel";
            colLevel.Visible = true;
            colLevel.VisibleIndex = 1;
            colLevel.Width = 86;
            // 
            // colSource
            // 
            colSource.Caption = "Origem";
            colSource.FieldName = "Source";
            colSource.MinWidth = 17;
            colSource.Name = "colSource";
            colSource.Visible = true;
            colSource.VisibleIndex = 2;
            colSource.Width = 120;
            // 
            // colMessage
            // 
            colMessage.Caption = "Mensagem";
            colMessage.FieldName = "Message";
            colMessage.MinWidth = 17;
            colMessage.Name = "colMessage";
            colMessage.Visible = true;
            colMessage.VisibleIndex = 3;
            colMessage.Width = 309;
            // 
            // colException
            // 
            colException.Caption = "Exceção";
            colException.ColumnEdit = repositoryItemMemoExEdit1;
            colException.FieldName = "Exception";
            colException.MinWidth = 17;
            colException.Name = "colException";
            colException.Visible = true;
            colException.VisibleIndex = 4;
            colException.Width = 137;
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
            colPayload.MinWidth = 17;
            colPayload.Name = "colPayload";
            colPayload.Width = 62;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lciTitle, lciSubtitle, lciLogType, lciStartDate, lciEndDate, esiFilters, lciSearch, lciLogs });
            Root.Name = "Root";
            Root.Size = new Size(771, 459);
            Root.TextVisible = false;
            // 
            // lciTitle
            // 
            lciTitle.Control = lblTitle;
            lciTitle.Location = new Point(0, 0);
            lciTitle.Name = "lciTitle";
            lciTitle.Size = new Size(745, 36);
            lciTitle.TextVisible = false;
            // 
            // lciSubtitle
            // 
            lciSubtitle.Control = lblSubtitle;
            lciSubtitle.Location = new Point(0, 36);
            lciSubtitle.Name = "lciSubtitle";
            lciSubtitle.Size = new Size(745, 19);
            lciSubtitle.TextVisible = false;
            // 
            // lciLogType
            // 
            lciLogType.Control = cbeLogType;
            lciLogType.Location = new Point(0, 55);
            lciLogType.MaxSize = new Size(144, 40);
            lciLogType.MinSize = new Size(144, 20);
            lciLogType.Name = "lciLogType";
            lciLogType.Size = new Size(144, 40);
            lciLogType.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lciLogType.Text = "Nível";
            lciLogType.TextLocation = DevExpress.Utils.Locations.Top;
            lciLogType.TextSize = new Size(30, 13);
            // 
            // lciStartDate
            // 
            lciStartDate.Control = deStartDate;
            lciStartDate.Location = new Point(144, 55);
            lciStartDate.MaxSize = new Size(147, 40);
            lciStartDate.MinSize = new Size(56, 20);
            lciStartDate.Name = "lciStartDate";
            lciStartDate.Size = new Size(147, 40);
            lciStartDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lciStartDate.Text = "Desde";
            lciStartDate.TextLocation = DevExpress.Utils.Locations.Top;
            lciStartDate.TextSize = new Size(30, 13);
            // 
            // lciEndDate
            // 
            lciEndDate.Control = deEndDate;
            lciEndDate.Location = new Point(291, 55);
            lciEndDate.MaxSize = new Size(147, 40);
            lciEndDate.MinSize = new Size(56, 20);
            lciEndDate.Name = "lciEndDate";
            lciEndDate.Size = new Size(147, 40);
            lciEndDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lciEndDate.Text = "Até";
            lciEndDate.TextLocation = DevExpress.Utils.Locations.Top;
            lciEndDate.TextSize = new Size(30, 13);
            // 
            // esiFilters
            // 
            esiFilters.Location = new Point(438, 55);
            esiFilters.Name = "esiFilters";
            esiFilters.Size = new Size(107, 40);
            //
            // lciSearch
            //
            lciSearch.Control = beSearch;
            lciSearch.Location = new Point(545, 55);
            lciSearch.MaxSize = new Size(320, 40);
            lciSearch.MinSize = new Size(200, 20);
            lciSearch.Name = "lciSearch";
            lciSearch.Size = new Size(200, 40);
            lciSearch.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            lciSearch.Text = "Pesquisar";
            lciSearch.TextLocation = DevExpress.Utils.Locations.Top;
            lciSearch.TextSize = new Size(30, 13);
            // 
            // lciLogs
            // 
            lciLogs.Control = gcLogs;
            lciLogs.Location = new Point(0, 95);
            lciLogs.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 12, 0);
            lciLogs.Name = "lciLogs";
            lciLogs.Size = new Size(745, 332);
            lciLogs.TextVisible = false;
            // 
            // LogsUserControl
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LogsUserControl";
            Size = new Size(771, 459);
            Load += LogsUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)beSearch.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)esiFilters).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciSearch).EndInit();
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
        private DevExpress.XtraLayout.LayoutControlItem lciTitle;
        private DevExpress.XtraLayout.LayoutControlItem lciSubtitle;
        private DevExpress.XtraLayout.LayoutControlItem lciLogType;
        private DevExpress.XtraLayout.LayoutControlItem lciStartDate;
        private DevExpress.XtraLayout.LayoutControlItem lciEndDate;
        private DevExpress.XtraLayout.EmptySpaceItem esiFilters;
        private DevExpress.XtraEditors.ButtonEdit beSearch;
        private DevExpress.XtraLayout.LayoutControlItem lciSearch;
        private DevExpress.XtraLayout.LayoutControlItem lciLogs;
    }
}
