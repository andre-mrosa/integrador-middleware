namespace Integrador.UI.Forms
{
    partial class LogDetailForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            lblHeader = new DevExpress.XtraEditors.LabelControl();
            meMessage = new DevExpress.XtraEditors.MemoEdit();
            meException = new DevExpress.XtraEditors.MemoEdit();
            mePayload = new DevExpress.XtraEditors.MemoEdit();
            sbCopy = new DevExpress.XtraEditors.SimpleButton();
            sbClose = new DevExpress.XtraEditors.SimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            lciHeader = new DevExpress.XtraLayout.LayoutControlItem();
            lciMessage = new DevExpress.XtraLayout.LayoutControlItem();
            lciException = new DevExpress.XtraLayout.LayoutControlItem();
            lciPayload = new DevExpress.XtraLayout.LayoutControlItem();
            lciCopy = new DevExpress.XtraLayout.LayoutControlItem();
            lciClose = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)meMessage.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)meException.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mePayload.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciHeader).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciMessage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciException).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciPayload).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciCopy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciClose).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            SuspendLayout();
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(lblHeader);
            layoutControl1.Controls.Add(meMessage);
            layoutControl1.Controls.Add(meException);
            layoutControl1.Controls.Add(mePayload);
            layoutControl1.Controls.Add(sbCopy);
            layoutControl1.Controls.Add(sbClose);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(800, 600);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // lblHeader
            // 
            lblHeader.Appearance.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblHeader.Appearance.Options.UseFont = true;
            lblHeader.Location = new Point(12, 12);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(8, 20);
            lblHeader.StyleController = layoutControl1;
            lblHeader.TabIndex = 4;
            lblHeader.Text = "-";
            // 
            // meMessage
            // 
            meMessage.Location = new Point(12, 52);
            meMessage.Name = "meMessage";
            meMessage.Properties.ReadOnly = true;
            meMessage.Size = new Size(776, 80);
            meMessage.StyleController = layoutControl1;
            meMessage.TabIndex = 5;
            // 
            // meException
            // 
            meException.Location = new Point(12, 152);
            meException.Name = "meException";
            meException.Properties.ReadOnly = true;
            meException.Properties.ScrollBars = ScrollBars.Both;
            meException.Properties.WordWrap = false;
            meException.Size = new Size(776, 180);
            meException.StyleController = layoutControl1;
            meException.TabIndex = 6;
            // 
            // mePayload
            // 
            mePayload.Location = new Point(12, 352);
            mePayload.Name = "mePayload";
            mePayload.Properties.ReadOnly = true;
            mePayload.Properties.ScrollBars = ScrollBars.Both;
            mePayload.Properties.WordWrap = false;
            mePayload.Size = new Size(776, 202);
            mePayload.StyleController = layoutControl1;
            mePayload.TabIndex = 7;
            // 
            // sbCopy
            // 
            sbCopy.Location = new Point(560, 558);
            sbCopy.Name = "sbCopy";
            sbCopy.Size = new Size(110, 30);
            sbCopy.StyleController = layoutControl1;
            sbCopy.TabIndex = 8;
            sbCopy.Text = "Copiar tudo";
            sbCopy.Click += sbCopy_Click;
            // 
            // sbClose
            // 
            sbClose.DialogResult = DialogResult.Cancel;
            sbClose.Location = new Point(674, 558);
            sbClose.Name = "sbClose";
            sbClose.Size = new Size(114, 30);
            sbClose.StyleController = layoutControl1;
            sbClose.TabIndex = 9;
            sbClose.Text = "Fechar";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lciHeader, lciMessage, lciException, lciPayload, lciCopy, lciClose, emptySpaceItem1 });
            Root.Name = "Root";
            Root.Size = new Size(800, 600);
            Root.TextVisible = false;
            // 
            // lciHeader
            // 
            lciHeader.Control = lblHeader;
            lciHeader.Location = new Point(0, 0);
            lciHeader.Name = "lciHeader";
            lciHeader.Size = new Size(780, 24);
            lciHeader.TextVisible = false;
            // 
            // lciMessage
            // 
            lciMessage.Control = meMessage;
            lciMessage.Location = new Point(0, 24);
            lciMessage.Name = "lciMessage";
            lciMessage.Size = new Size(780, 100);
            lciMessage.Text = "Mensagem";
            lciMessage.TextLocation = DevExpress.Utils.Locations.Top;
            lciMessage.TextSize = new Size(52, 13);
            // 
            // lciException
            // 
            lciException.Control = meException;
            lciException.Location = new Point(0, 124);
            lciException.Name = "lciException";
            lciException.Size = new Size(780, 200);
            lciException.Text = "Exceção";
            lciException.TextLocation = DevExpress.Utils.Locations.Top;
            lciException.TextSize = new Size(52, 13);
            // 
            // lciPayload
            // 
            lciPayload.Control = mePayload;
            lciPayload.Location = new Point(0, 324);
            lciPayload.Name = "lciPayload";
            lciPayload.Size = new Size(780, 222);
            lciPayload.Text = "Payload";
            lciPayload.TextLocation = DevExpress.Utils.Locations.Top;
            lciPayload.TextSize = new Size(52, 13);
            // 
            // lciCopy
            // 
            lciCopy.Control = sbCopy;
            lciCopy.Location = new Point(548, 546);
            lciCopy.Name = "lciCopy";
            lciCopy.Size = new Size(114, 34);
            lciCopy.TextVisible = false;
            // 
            // lciClose
            // 
            lciClose.Control = sbClose;
            lciClose.Location = new Point(662, 546);
            lciClose.Name = "lciClose";
            lciClose.Size = new Size(118, 34);
            lciClose.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.Location = new Point(0, 546);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new Size(548, 34);
            // 
            // LogDetailForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = sbClose;
            ClientSize = new Size(800, 600);
            Controls.Add(layoutControl1);
            MinimizeBox = false;
            Name = "LogDetailForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalhe da log";
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)meMessage.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)meException.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)mePayload.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciHeader).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciMessage).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciException).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciPayload).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciCopy).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciClose).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        private DevExpress.XtraEditors.MemoEdit meMessage;
        private DevExpress.XtraEditors.MemoEdit meException;
        private DevExpress.XtraEditors.MemoEdit mePayload;
        private DevExpress.XtraEditors.SimpleButton sbCopy;
        private DevExpress.XtraEditors.SimpleButton sbClose;
        private DevExpress.XtraLayout.LayoutControlItem lciHeader;
        private DevExpress.XtraLayout.LayoutControlItem lciMessage;
        private DevExpress.XtraLayout.LayoutControlItem lciException;
        private DevExpress.XtraLayout.LayoutControlItem lciPayload;
        private DevExpress.XtraLayout.LayoutControlItem lciCopy;
        private DevExpress.XtraLayout.LayoutControlItem lciClose;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
