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
        private const string DarkPalette = "Darkness";

        /// <summary>Paleta por defeito do WXI (Freshness). Tem de ser pedida por este nome, senão o skin mantém a paleta atual.</summary>
        private const string LightPalette = "DefaultSkinPalette";

        public static bool IsDark => UiPreferences.Current.DarkTheme;

        /// <summary>Chamar antes de criar qualquer form.</summary>
        public static void Initialize()
        {
            WindowsFormsSettings.DefaultFont = new Font("Segoe UI", 9.75F);
            WindowsFormsSettings.DefaultMenuFont = new Font("Segoe UI", 9.75F);
            WindowsFormsSettings.ScrollUIMode = ScrollUIMode.Fluent;
            WindowsFormsSettings.AllowRoundedWindowCorners = DefaultBoolean.True;

            ApplyPalette();
        }

        public static void ToggleDark()
        {
            UiPreferences.Current.DarkTheme = !UiPreferences.Current.DarkTheme;
            ApplyPalette();
            UiPreferences.Save();
        }

        private static void ApplyPalette()
        {
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.WXI, IsDark ? DarkPalette : LightPalette);

            // A troca de paleta repõe a cor de destaque do skin
            WindowsFormsSettings.SetAccentColor(AppInfo.AccentColor);
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
