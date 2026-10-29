namespace Integrador.UI
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(SplashScreen1), true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            aceHome = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aceLogs = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aceScheduler = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aceConfigs = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            bbiTheme = new DevExpress.XtraBars.BarButtonItem();
            svgImages = new DevExpress.Utils.SvgImageCollection(components);
            ((System.ComponentModel.ISupportInitialize)accordionControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)svgImages).BeginInit();
            SuspendLayout();
            //
            // splashScreenManager1
            //
            splashScreenManager1.ClosingDelay = 500;
            //
            // fluentDesignFormContainer1
            //
            fluentDesignFormContainer1.Dock = DockStyle.Fill;
            fluentDesignFormContainer1.Location = new Point(240, 39);
            fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            fluentDesignFormContainer1.Padding = new Padding(0);
            fluentDesignFormContainer1.Size = new Size(1128, 720);
            fluentDesignFormContainer1.TabIndex = 0;
            //
            // accordionControl1
            //
            accordionControl1.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            accordionControl1.AllowItemSelection = true;
            accordionControl1.Dock = DockStyle.Left;
            accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { aceHome, aceLogs, aceScheduler, aceConfigs });
            accordionControl1.ItemHeight = 40;
            accordionControl1.Location = new Point(0, 39);
            accordionControl1.Name = "accordionControl1";
            accordionControl1.OptionsHamburgerMenu.DisplayMode = DevExpress.XtraBars.Navigation.AccordionControlDisplayMode.Inline;
            accordionControl1.OptionsMinimizing.NormalWidth = 240;
            accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            accordionControl1.Size = new Size(240, 720);
            accordionControl1.TabIndex = 1;
            accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            //
            // aceHome
            //
            aceHome.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aceHome.ImageOptions.SvgImage");
            aceHome.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            aceHome.ImageOptions.SvgImageSize = new Size(20, 20);
            aceHome.Name = "aceHome";
            aceHome.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aceHome.Text = "Início";
            aceHome.Click += aceHome_Click;
            //
            // aceLogs
            //
            aceLogs.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aceLogs.ImageOptions.SvgImage");
            aceLogs.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            aceLogs.ImageOptions.SvgImageSize = new Size(20, 20);
            aceLogs.Name = "aceLogs";
            aceLogs.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aceLogs.Text = "Logs";
            aceLogs.Click += aceLogs_Click;
            //
            // aceScheduler
            //
            aceScheduler.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aceScheduler.ImageOptions.SvgImage");
            aceScheduler.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            aceScheduler.ImageOptions.SvgImageSize = new Size(20, 20);
            aceScheduler.Name = "aceScheduler";
            aceScheduler.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aceScheduler.Text = "Agendamento";
            aceScheduler.Click += aceScheduler_Click;
            //
            // aceConfigs
            //
            aceConfigs.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("aceConfigs.ImageOptions.SvgImage");
            aceConfigs.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            aceConfigs.ImageOptions.SvgImageSize = new Size(20, 20);
            aceConfigs.Name = "aceConfigs";
            aceConfigs.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aceConfigs.Text = "Configurações";
            aceConfigs.Click += aceConfigs_Click;
            //
            // fluentDesignFormControl1
            //
            fluentDesignFormControl1.FluentDesignForm = this;
            fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { bbiTheme });
            fluentDesignFormControl1.Location = new Point(0, 0);
            fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            fluentDesignFormControl1.Size = new Size(1368, 39);
            fluentDesignFormControl1.TabIndex = 2;
            fluentDesignFormControl1.TabStop = false;
            fluentDesignFormControl1.TitleItemLinks.Add(bbiTheme);
            //
            // bbiTheme
            //
            bbiTheme.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            bbiTheme.Caption = "Tema";
            bbiTheme.Hint = "Alternar tema claro/escuro";
            bbiTheme.Id = 0;
            bbiTheme.ImageOptions.SvgImageSize = new Size(16, 16);
            bbiTheme.Name = "bbiTheme";
            bbiTheme.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            bbiTheme.ItemClick += bbiTheme_ItemClick;
            //
            // svgImages
            //
            svgImages.Add("dark", "image://svgimages/icon builder/weather_moon.svg");
            svgImages.Add("light", "image://svgimages/icon builder/weather_sunny.svg");
            //
            // MainForm
            //
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1368, 759);
            ControlContainer = fluentDesignFormContainer1;
            Controls.Add(fluentDesignFormContainer1);
            Controls.Add(accordionControl1);
            Controls.Add(fluentDesignFormControl1);
            FluentDesignFormControl = fluentDesignFormControl1;
            IconOptions.Icon = (Icon)resources.GetObject("MainForm.IconOptions.Icon");
            MinimumSize = new Size(1000, 640);
            Name = "MainForm";
            NavigationControl = accordionControl1;
            StartPosition = FormStartPosition.CenterScreen;
            SurfaceMaterial = DevExpress.XtraEditors.SurfaceMaterial.None;
            Text = "Integrador";
            FormClosing += MainForm_FormClosing;
            Shown += MainForm_Shown;
            ((System.ComponentModel.ISupportInitialize)accordionControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)svgImages).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceHome;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceLogs;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceScheduler;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceConfigs;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.BarButtonItem bbiTheme;
        private DevExpress.Utils.SvgImageCollection svgImages;
    }
}
