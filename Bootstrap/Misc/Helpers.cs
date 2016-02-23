using HyperSlackers.Bootstrap.BootstrapMethods;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    internal static class Helpers
    {
        public static string GetCssClass(AlertStyle style)
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            return "alert-" + style.ToString().ToLowerInvariant();
        }

        public static string GetCssClass(PanelStyle style)
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            return "panel-" + style.ToString().ToLowerInvariant();
        }

        public static string GetCssClass(CursorType cursor)
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            return cursor.ToString().ToLowerInvariant().Replace("_", "-");
        }

        public static string GetCssClass(ButtonSize buttonSize)
        {
            Contract.Ensures(Contract.Result<string>() != null);

            switch (buttonSize)
            {
                case ButtonSize.Large:
                    return "btn-lg";
                case ButtonSize.Small:
                    return "btn-sm";
                case ButtonSize.ExtraSmall:
                    return "btn-xs";
                case ButtonSize.Default:
                default:
                    return string.Empty;
            }
        }

        public static string GetCssClass(TextColor color)
        {
            Contract.Ensures(Contract.Result<string>() != null);

            switch (color)
            {
                case TextColor.Danger:
                case TextColor.Info:
                case TextColor.Primary:
                case TextColor.Success:
                case TextColor.Warning:
                    return "text-" + color.ToString().ToLowerInvariant();
                default:
                    return string.Empty;
            }
        }

        public static string GetCssClass(HtmlHelper html, ButtonStyle style)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<string>() != null);

            // use specified value or any set default
            ButtonStyle buttonStyle = style != ButtonStyle.None ? style : html.BootstrapDefaults().DefaultButtonStyle;

            if (buttonStyle == ButtonStyle.None)
            {
                return string.Empty;
            }

            return "btn-" + buttonStyle.ToString().ToLowerInvariant();
        }

        public static string GetCssClass(FormType type)
        {
            Contract.Ensures(Contract.Result<string>() != null);

            if (type == FormType.Default)
            {
                return string.Empty;
            }

            return "form-" + type.ToString().ToLowerInvariant();
        }

        public static string GetCssClass(DropDownAlignment alignment)
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            return "dropdown-menu-" + alignment.ToString().ToLowerInvariant();
        }

        public static string GetCssClass(HtmlHelper html, InputSize size)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<string>() != null);

            InputSize inputSize = size != InputSize.Default ? size : html.BootstrapDefaults().DefaultInputSize;

            switch (inputSize)
	        {
                case InputSize.Small:
                    return "input-sm";
                case InputSize.Large:
                    return "input-lg";
                case InputSize.Default:
                default:
                    return string.Empty;
	        }
        }

        public static string GetCssClass(NavBarAlignment alignment)
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            return "navbar-" + alignment.ToString().SpaceOnUpperCase().ToLowerInvariant().Replace(" ", "-");
        }

        public static string GetCssClass(NavType type)
        {
            Contract.Ensures(!String.IsNullOrEmpty(Contract.Result<string>()));

            return "nav-" + type.ToString().ToLowerInvariant();
        }

        public static string GetCssClass(TableColor style)
        {
            Contract.Ensures(Contract.Result<string>() != null);

            if (style == TableColor.None)
            {
                return string.Empty;
            }

            return style.ToString().ToLowerInvariant();
        }

        public static string GetCssClass(TableCellWidth width)
        {
            Contract.Ensures(Contract.Result<string>() != null);

            if (width == TableCellWidth.None)
            {
                return string.Empty;
            }

            return "width-" + width.ToString().ToLowerInvariant();
        }

        public static string GetCssClass(Placement placement)
        {
            Contract.Ensures(Contract.Result<string>() != null);

            return placement.ToString().ToLowerInvariant();
        }

        public static string CssColClassWidth(int? widthXs, int? widthSm, int? widthMd, int? widthLg)
        {
            return CssColClass(widthXs, widthSm, widthMd, widthLg, "");
        }

        public static string CssColClassOffset(int? widthXs, int? widthSm, int? widthMd, int? widthLg)
        {
            return CssColClass(widthXs, widthSm, widthMd, widthLg, "offset");
        }

        public static string CssColClassPush(int? widthXs, int? widthSm, int? widthMd, int? widthLg)
        {
            return CssColClass(widthXs, widthSm, widthMd, widthLg, "push");
        }

        public static string CssColClassPull(int? widthXs, int? widthSm, int? widthMd, int? widthLg)
        {
            return CssColClass(widthXs, widthSm, widthMd, widthLg, "pull");
        }

        private static string CssColClass(int? widthXs, int? widthSm, int? widthMd, int? widthLg, string type)
        {
            StringBuilder css = new StringBuilder();

            if (widthXs.HasValue)
            {
                css.Append("col-xs-" + (type.IsNullOrWhiteSpace() ? string.Empty : type + "-") + widthXs.Value);
            }

            if (widthSm.HasValue)
            {
                if (css.Length > 0)
                {
                    css.Append(" ");
                }
                css.Append("col-sm-" + (type.IsNullOrWhiteSpace() ? string.Empty : type + "-") + widthSm.Value);
            }

            if (widthMd.HasValue)
            {
                if (css.Length > 0)
                {
                    css.Append(" ");
                }
                css.Append("col-md-" + (type.IsNullOrWhiteSpace() ? string.Empty : type + "-") + widthMd.Value);
            }

            if (widthLg.HasValue)
            {
                if (css.Length > 0)
                {
                    css.Append(" ");
                }
                css.Append("col-lg-" + (type.IsNullOrWhiteSpace() ? string.Empty : type + "-") + widthLg.Value);
            }

            return css.ToString();
        }

        public static string CssColClassHidden(bool hiddenXs, bool hiddenSm, bool hiddenMd, bool hiddenLg)
        {
            StringBuilder css = new StringBuilder();

            if (hiddenXs)
            {
                css.Append("hidden-xs");
            }

            if (hiddenSm)
            {
                if (css.Length > 0)
                {
                    css.Append(" ");
                }
                css.Append("hidden-sm");
            }

            if (hiddenMd)
            {
                if (css.Length > 0)
                {
                    css.Append(" ");
                }
                css.Append("hidden-md");
            }

            if (hiddenLg)
            {
                if (css.Length > 0)
                {
                    css.Append(" ");
                }
                css.Append("hidden-lg");
            }

            return css.ToString();
        }

        // TODO: deprecated in Bootstrap 3.2.0
        public static string CssColClassVisible(bool visibleXs, bool visibleSm, bool visibleMd, bool visibleLg)
        {
            StringBuilder css = new StringBuilder();

            if (visibleXs)
            {
                css.Append("visible-xs");
            }

            if (visibleSm)
            {
                if (css.Length > 0)
                {
                    css.Append(" ");
                }
                css.Append("visible-sm");
            }

            if (visibleMd)
            {
                if (css.Length > 0)
                {
                    css.Append(" ");
                }
                css.Append("visible-md");
            }

            if (visibleLg)
            {
                if (css.Length > 0)
                {
                    css.Append(" ");
                }
                css.Append("visible-lg");
            }

            return css.ToString();
        }

        public static string CssColClassVisible(bool visibleXs, ColumnVisibilityType visibilityTypeXs, bool visibleSm, ColumnVisibilityType visibilityTypeSm, bool visibleMd, ColumnVisibilityType visibilityTypeMd, bool visibleLg, ColumnVisibilityType visibilityTypeLg)
        {
            StringBuilder css = new StringBuilder();

            if (visibleXs)
            {
                css.Append("visible-xs-" + GetColumnVisibilityTypeCss(visibilityTypeXs));
            }

            if (visibleSm)
            {
                if (css.Length > 0)
                {
                    css.Append(" ");
                }
                css.Append("visible-sm-" + GetColumnVisibilityTypeCss(visibilityTypeSm));
            }

            if (visibleMd)
            {
                if (css.Length > 0)
                {
                    css.Append(" ");
                }
                css.Append("visible-md-" + GetColumnVisibilityTypeCss(visibilityTypeMd));
            }

            if (visibleLg)
            {
                if (css.Length > 0)
                {
                    css.Append(" ");
                }
                css.Append("visible-lg-" + GetColumnVisibilityTypeCss(visibilityTypeLg));
            }

            return css.ToString();
        }

        private static string GetColumnVisibilityTypeCss(ColumnVisibilityType type)
        {
            switch (type)
            {
                case ColumnVisibilityType.Block:
                    return "block";
                case ColumnVisibilityType.Inline:
                    return "inline";
                case ColumnVisibilityType.InlineBlock:
                    return "inline-block";
                default:
                    return "block";
            }
        }
    }
}