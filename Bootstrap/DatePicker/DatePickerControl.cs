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

            this.helpText = new HelpTextControl<TModel>(this.html, GetHelpTextText());

            return this;
        }

        public DatePickerControl<TModel> HelpText(string text)
        {
            Contract.Requires<ArgumentNullException>(text != null, "text");
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            this.helpText = new HelpTextControl<TModel>(this.html, text);

            return this;
        }

        public DatePickerControl<TModel> HelpText(IHtmlString html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            this.helpText = new HelpTextControl<TModel>(this.html, html.ToHtmlString());

            return this;
        }

        public DatePickerControl<TModel> Size(InputSize inputSize)
        {
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            this.size = inputSize;

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

            this.placeholder = GetPlaceholderText();

            return this;
        }

        public DatePickerControl<TModel> Placeholder(string placeHolder)
        {
            Contract.Requires<ArgumentException>(!placeHolder.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            this.placeholder = placeHolder;

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

            this.weekStart = day;

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

            this.daysOfWeekDisabled = disabledDays.ToArray();

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

            this.minViewMode = viewMode;

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

            this.todayButton = mode;

            return this;
        }

        public DatePickerControl<TModel> TodayHighlight(bool highlight = true)
        {
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            this.todayHighlight = highlight;

            return this;
        }

        protected override string RenderControl()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            bool showValidationMessageInline = html.BootstrapDefaults().DefaultShowValidationMessageInline ?? false;
            bool showValidationMessageBeforeInput = html.BootstrapDefaults().DefaultShowValidationMessageBeforeInput ?? false;
            string formatString = showValidationMessageBeforeInput ? "{2}{0}{1}" : "{0}{1}{2}";

            if (this.component)
            {
                // icon was class=icon-th
                formatString = "<div class=\"input-group date\">" + formatString + "<span class=\"input-group-addon\"><i class=\"glyphicon glyphicon-calendar\"></i></span></div>";
            }

            this.controlHtmlAttributes.MergeHtmlAttributes(html.GetUnobtrusiveValidationAttributes(this.htmlFieldName, this.metadata));

            if (!this.id.IsNullOrWhiteSpace())
            {
                this.controlHtmlAttributes.AddOrReplace("id", this.id);
            }

            SetDefaultTooltip();
            if (this.tooltip != null)
            {
                this.controlHtmlAttributes.MergeHtmlAttributes(this.tooltip.ToDictionary());
            }

            bool alwaysShowPlaceholder = html.BootstrapDefaults().DefaultShowPlaceholder ?? false;

            if (!this.placeholder.IsNullOrWhiteSpace())
            {
                this.controlHtmlAttributes.AddOrReplace("placeholder", this.placeholder);
            }
            else if (alwaysShowPlaceholder)
            {
                this.controlHtmlAttributes.AddOrReplace("placeholder", GetPlaceholderText());
            }

            this.controlHtmlAttributes.AddClass((string)Helpers.GetCssClass(html, this.size));

            this.controlHtmlAttributes.AddClass("form-control");

            this.controlHtmlAttributes.AddClass("datepicker");

            if (weekStart != DayOfWeek.Sunday)
            {
                this.controlHtmlAttributes.AddOrReplace("data-date-week-start", ((int)this.weekStart).ToString());
            }

            if (this.clearButton)
            {
                this.controlHtmlAttributes.AddOrReplace("data-date-clear-btn", "true");
            }

            if (this.daysOfWeekDisabled.Length > 0)
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

                this.controlHtmlAttributes.AddOrReplace("data-date-days-of-week-disabled", "[" + disabledDays.ToString() + "]");
            }

            if (this.startDate.HasValue)
            {
                this.controlHtmlAttributes.AddOrReplace("data-date-start-date", this.startDate.Value.ToShortDateString());
            }

            if (this.endDate.HasValue)
            {
                this.controlHtmlAttributes.AddOrReplace("data-date-end-date", this.endDate.Value.ToShortDateString());
            }

            if (this.autoClose)
            {
                this.controlHtmlAttributes.AddOrReplace("data-date-autoclose", "true");
            }

            if (this.minViewMode != DatePickerViewMode.Days)
            {
                this.controlHtmlAttributes.AddOrReplace("data-date-min-view-mode", this.minViewMode.ToString().ToLowerInvariant());
            }

            if (this.orientation != DatePickerOrientation.Auto)
            {
                this.controlHtmlAttributes.AddOrReplace("data-date-orientation", this.orientation.ToString().SpaceOnUpperCase().ToLowerInvariant());
            }

            if (this.startView != DatePickerStartMode.Months)
            {
                this.controlHtmlAttributes.AddOrReplace("data-date-start-view", this.startView.ToString().ToLowerInvariant());
            }

            if (this.todayButton != DatePickerTodayButtonMode.False)
            {
                this.controlHtmlAttributes.AddOrReplace("data-date-today-btn", this.todayButton.ToString().ToLowerInvariant());
            }

            if (this.todayHighlight)
            {
                this.controlHtmlAttributes.AddOrReplace("data-date-today-highlight", "true");
            }

            SetFormatText();

            string controlHtml = html.TextBox(this.htmlFieldName, this.value, this.format, this.controlHtmlAttributes.FormatHtmlAttributes()).ToHtmlString();

            //formatString = AddPrependAppend(formatString, this.prependHtml, this.appendHtml);
            string helpHtml = this.helpText != null ? this.helpText.ToHtmlString() : string.Empty;
            string validationHtml = showValidationMessageInline ? string.Empty : this.RenderValidationMessage();

            return MvcHtmlString.Create(formatString.FormatWith(controlHtml, helpHtml, validationHtml)).ToString();
        }
    }
}