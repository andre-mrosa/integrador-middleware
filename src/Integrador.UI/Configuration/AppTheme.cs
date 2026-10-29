using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace Integrador.UI.Configuration
{
    /// <summary>
    /// Aspeto global da aplicação. Skin WXI fixo com tema claro/escuro e cor de destaque própria (AppInfo.AccentColor).
    /// </summary>
    internal static class AppTheme
    {
        private const string LightPalette = "Freshness";
        private const string DarkPalette = "Darkness";

        public static bool IsDark => UserLookAndFeel.Default.ActiveSvgPaletteName == DarkPalette;

        /// <summary>Chamar antes de criar qualquer form.</summary>
        public static void Initialize()
        {
            WindowsFormsSettings.DefaultFont = new Font("Segoe UI", 9.75F);
            WindowsFormsSettings.DefaultMenuFont = new Font("Segoe UI", 9.75F);
            WindowsFormsSettings.ScrollUIMode = ScrollUIMode.Fluent;
            WindowsFormsSettings.AllowRoundedWindowCorners = DefaultBoolean.True;
            WindowsFormsSettings.SetAccentColor(AppInfo.AccentColor);

            bool dark = SkinSettings.GetSkinSettings().PaletteName == DarkPalette;
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.WXI, dark ? DarkPalette : LightPalette);
        }

        public static void ToggleDark()
        {
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.WXI, IsDark ? LightPalette : DarkPalette);
            WindowsFormsSettings.SetAccentColor(AppInfo.AccentColor);
            SkinSettings.SaveSkin(new SkinSettings { SkinName = SkinStyle.WXI.ToString(), PaletteName = UserLookAndFeel.Default.ActiveSvgPaletteName });
        }

        /// <summary>
        /// Grelhas só de leitura com aspeto de lista: sem linhas verticais, linhas mais altas, sem célula focada.
        /// Centralizado para todas as grelhas ficarem iguais.
        /// </summary>
        public static void ApplyListStyle(GridView view)
        {
            view.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            view.OptionsView.ShowVerticalLines = DefaultBoolean.False;
            view.OptionsView.ShowIndicator = false;
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsView.EnableAppearanceEvenRow = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DrawFocusRectStyle.None;
            view.RowHeight = 34;
            view.ColumnPanelRowHeight = 32;
            view.Appearance.HeaderPanel.ForeColor = DXSkinColors.ForeColors.DisabledText;
            view.Appearance.HeaderPanel.Options.UseForeColor = true;
        }
    }
}
