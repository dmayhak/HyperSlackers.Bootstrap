using System;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using System.Web;
using HyperSlackers.Bootstrap.Core;
using System.Collections.Generic;
using System.Web.Mvc.Html;
using System.Text;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class DatePickerControl<TModel> : InputControlBase<DatePickerControl<TModel>, TModel>
    {
        internal string placeholder;
        //internal List<Tuple<IHtmlString, object>> prependHtml = new List<Tuple<IHtmlString, object>>();
        //internal List<Tuple<IHtmlString, object>> appendHtml = new List<Tuple<IHtmlString, object>>();
        internal InputSize size = InputSize.Default;
        internal DayOfWeek weekStart = DayOfWeek.Sunday;
        internal bool clearButton = false;
        internal DayOfWeek[] daysOfWeekDisabled = new DayOfWeek[] { };
        internal DateTime? startDate;
        internal DateTime? endDate;
        internal bool autoClose;
        internal DatePickerViewMode minViewMode = DatePickerViewMode.Days;
        internal DatePickerOrientation orientation = DatePickerOrientation.Auto;
        internal DatePickerStartMode startView = DatePickerStartMode.Months;
        internal DatePickerTodayButtonMode todayButton = DatePickerTodayButtonMode.False;
        internal bool todayHighlight;
        internal bool component;

        // TODO: multidate
        // TODO: language

        internal DatePickerControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata)
            : base(html, htmlFieldName, metadata)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
        }

        public DatePickerControl<TModel> HelpText()
        {
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(html, GetHelpTextText());

            return this;
        }

        public DatePickerControl<TModel> HelpText(string text)
        {
            Contract.Requires<ArgumentNullException>(text != null, "text");
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(html, text);

            return this;
        }

        public DatePickerControl<TModel> HelpText(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            helpText = new HelpTextControl<TModel>(this.html, html.ToHtmlString());

            return this;
        }

        public DatePickerControl<TModel> Size(InputSize inputSize)
        {
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            size = inputSize;

            return this;
        }

        //public DatePickerControl<TModel> Append(string htmlString, object containerHtmlAttributes = null)
        //{
        //    Contract.Requires<ArgumentException>(!htmlString.IsNullOrWhiteSpace());
        //    Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

        //    this.appendHtml.Add(new Tuple<IHtmlString, object>(MvcHtmlString.Create(htmlString), containerHtmlAttributes));

        //    return this;
        //}

        //public DatePickerControl<TModel> Append(IHtmlString htmlString, object containerHtmlAttributes = null)
        //{
        //    Contract.Requires<ArgumentNullException>(htmlString != null, "htmlString");
        //    Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

        //    this.appendHtml.Add(new Tuple<IHtmlString, object>(htmlString, containerHtmlAttributes));

        //    return this;
        //}

        //public DatePickerControl<TModel> AppendIcon(Icon icon, object containerHtmlAttributes = null)
        //{
        //    Contract.Requires<ArgumentNullException>(icon != null, "icon");
        //    Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

        //    this.appendHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

        //    return this;
        //}

        //public DatePickerControl<TModel> AppendIcon(GlyphIcon icon, object containerHtmlAttributes = null)
        //{
        //    Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

        //    this.appendHtml.Add(new Tuple<IHtmlString, object>(new Icon(icon), containerHtmlAttributes));

        //    return this;
        //}

        //public DatePickerControl<TModel> AppendIcon(FontAwesomeIcon icon, object containerHtmlAttributes = null)
        //{
        //    Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

        //    this.appendHtml.Add(new Tuple<IHtmlString, object>(new Icon(icon), containerHtmlAttributes));

        //    return this;
        //}

        //public DatePickerControl<TModel> AppendIcon(string cssClass, object containerHtmlAttributes = null)
        //{
        //    Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
        //    Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

        //    this.appendHtml.Add(new Tuple<IHtmlString, object>(new Icon(cssClass), containerHtmlAttributes));

        //    return this;
        //}

        public DatePickerControl<TModel> Format(string format)
        {
            Contract.Requires<ArgumentException>(!format.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            this.format = format;

            return this;
        }

        public DatePickerControl<TModel> Placeholder()
        {
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            placeholder = GetPlaceholderText();

            return this;
        }

        public DatePickerControl<TModel> Placeholder(string placeHolder)
        {
            Contract.Requires<ArgumentException>(!placeHolder.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            placeholder = placeHolder;

            return this;
        }

        //public DatePickerControl<TModel> Prepend(string htmlString, object containerHtmlAttributes = null)
        //{
        //    Contract.Requires<ArgumentException>(!htmlString.IsNullOrWhiteSpace());
        //    Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

        //    this.prependHtml.Add(new Tuple<IHtmlString, object>(MvcHtmlString.Create(htmlString), containerHtmlAttributes));

        //    return this;
        //}

        //public DatePickerControl<TModel> Prepend(IHtmlString htmlString, object containerHtmlAttributes = null)
        //{
        //    Contract.Requires<ArgumentNullException>(htmlString != null, "htmlString");
        //    Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

        //    this.prependHtml.Add(new Tuple<IHtmlString, object>(htmlString, containerHtmlAttributes));

        //    return this;
        //}

        //public DatePickerControl<TModel> PrependIcon(Icon icon, object containerHtmlAttributes = null)
        //{
        //    Contract.Requires<ArgumentNullException>(icon != null, "icon");
        //    Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

        //    this.prependHtml.Add(new Tuple<IHtmlString, object>(icon, containerHtmlAttributes));

        //    return this;
        //}

        //public DatePickerControl<TModel> PrependIcon(GlyphIcon icon, object containerHtmlAttributes = null)
        //{
        //    Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

        //    this.prependHtml.Add(new Tuple<IHtmlString, object>(new Icon(icon), containerHtmlAttributes));

        //    return this;
        //}

        //public DatePickerControl<TModel> PrependIcon(FontAwesomeIcon icon, object containerHtmlAttributes = null)
        //{
        //    Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

        //    this.prependHtml.Add(new Tuple<IHtmlString, object>(new Icon(icon), containerHtmlAttributes));

        //    return this;
        //}

        //public DatePickerControl<TModel> PrependIcon(string cssClass, object containerHtmlAttributes = null)
        //{
        //    Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
        //    Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

        //    this.prependHtml.Add(new Tuple<IHtmlString, object>(new Icon(cssClass), containerHtmlAttributes));

        //    return this;
        //}

        public DatePickerControl<TModel> WeekStart(DayOfWeek day)
        {
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            weekStart = day;

            return this;
        }

        public DatePickerControl<TModel> ClearButton(bool clearButton = true)
        {
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            this.clearButton = clearButton;

            return this;
        }

        public DatePickerControl<TModel> Component(bool component = true)
        {
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            this.component = component;

            return this;
        }

        public DatePickerControl<TModel> DaysOfWeekDisabled(params DayOfWeek[] days)
        {
            Contract.Requires<ArgumentNullException>(days != null, "days");
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            List<DayOfWeek> disabledDays = new List<DayOfWeek>();
            foreach (var item in days)
            {
                if (!disabledDays.Contains(item))
                {
                    disabledDays.Add(item);
                }
            }

            daysOfWeekDisabled = disabledDays.ToArray();

            return this;
        }

        public DatePickerControl<TModel> StartDate(DateTime? startDate)
        {
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            this.startDate = startDate;

            return this;
        }

        public DatePickerControl<TModel> EndDate(DateTime? endDate)
        {
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            this.endDate = endDate;

            return this;
        }

        public DatePickerControl<TModel> AutoClose(bool autoClose = true)
        {
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            this.autoClose = autoClose;

            return this;
        }

        public DatePickerControl<TModel> MinViewMode(DatePickerViewMode viewMode)
        {
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            minViewMode = viewMode;

            return this;
        }

        public DatePickerControl<TModel> Orientation(DatePickerOrientation orientation)
        {
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            this.orientation = orientation;

            return this;
        }

        public DatePickerControl<TModel> StartView(DatePickerStartMode startView)
        {
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            this.startView = startView;

            return this;
        }

        public DatePickerControl<TModel> TodayButton(DatePickerTodayButtonMode mode)
        {
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            todayButton = mode;

            return this;
        }

        public DatePickerControl<TModel> TodayHighlight(bool highlight = true)
        {
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            todayHighlight = highlight;

            return this;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            bool showValidationMessageInline = html.BootstrapDefaults().DefaultShowValidationMessageInline ?? false;
            bool showValidationMessageBeforeInput = html.BootstrapDefaults().DefaultShowValidationMessageBeforeInput ?? false;
            string formatString = showValidationMessageBeforeInput ? "{2}{0}{1}" : "{0}{1}{2}";

            if (component)
            {
                // icon was class=icon-th
                formatString = "<div class=\"input-group date\">" + formatString + "<span class=\"input-group-addon\"><i class=\"glyphicon glyphicon-calendar\"></i></span></div>";
            }

            controlHtmlAttributes.AddOrReplaceHtmlAttributes(html.GetUnobtrusiveValidationAttributes(htmlFieldName, metadata));

            if (!id.IsNullOrWhiteSpace())
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("id", id);
            }

            SetDefaultTooltip();
            if (tooltip != null)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttributes(tooltip.ToDictionary());
            }

            bool alwaysShowPlaceholder = html.BootstrapDefaults().DefaultShowPlaceholder ?? false;

            if (!placeholder.IsNullOrWhiteSpace())
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("placeholder", placeholder);
            }
            else if (alwaysShowPlaceholder)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("placeholder", GetPlaceholderText());
            }

            controlHtmlAttributes.AddIfNotExistsCssClass("form-control");

            controlHtmlAttributes.AddIfNotExistsCssClass((string)Helpers.GetCssClass(html, size));

            controlHtmlAttributes.AddIfNotExistsCssClass("datepicker");

            if (weekStart != DayOfWeek.Sunday)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("data-date-week-start", ((int)weekStart).ToString());
            }

            if (clearButton)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("data-date-clear-btn", "true");
            }

            if (daysOfWeekDisabled.Length > 0)
            {
                StringBuilder disabledDays = new StringBuilder();
                foreach (var item in daysOfWeekDisabled)
                {
                    if (disabledDays.Length > 0)
                    {
                        disabledDays.Append(",");
                    }

                    disabledDays.Append(((int)item).ToString());
                }

                controlHtmlAttributes.AddOrReplaceHtmlAttribute("data-date-days-of-week-disabled", "[" + disabledDays.ToString() + "]");
            }

            if (startDate.HasValue)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("data-date-start-date", startDate.Value.ToShortDateString());
            }

            if (endDate.HasValue)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("data-date-end-date", endDate.Value.ToShortDateString());
            }

            if (autoClose)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("data-date-autoclose", "true");
            }

            if (minViewMode != DatePickerViewMode.Days)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("data-date-min-view-mode", minViewMode.ToString().ToLowerInvariant());
            }

            if (orientation != DatePickerOrientation.Auto)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("data-date-orientation", orientation.ToString().SpaceOnUpperCase().ToLowerInvariant());
            }

            if (startView != DatePickerStartMode.Months)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("data-date-start-view", startView.ToString().ToLowerInvariant());
            }

            if (todayButton != DatePickerTodayButtonMode.False)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("data-date-today-btn", todayButton.ToString().ToLowerInvariant());
            }

            if (todayHighlight)
            {
                controlHtmlAttributes.AddOrReplaceHtmlAttribute("data-date-today-highlight", "true");
            }

            SetFormatText();

            string controlHtml = html.TextBox(htmlFieldName, selectedValue, format, controlHtmlAttributes.FormatHtmlAttributes()).ToHtmlString();

            //formatString = AddPrependAppend(formatString, this.prependHtml, this.appendHtml);
            string helpHtml = helpText != null ? helpText.ToHtmlString() : string.Empty;
            string validationHtml = showValidationMessageInline ? string.Empty : RenderValidationMessage();

            return MvcHtmlString.Create(formatString.FormatWith(controlHtml, helpHtml, validationHtml)).ToString();
        }
    }
}