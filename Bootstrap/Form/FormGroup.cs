using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Controls;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
	public class FormGroup<TModel>
	{
		internal readonly HtmlHelper<TModel> html;
        internal FormType formType = FormType.Default;
        internal readonly IDictionary<string, object> labelHtmlAttributes = new Dictionary<string, object>();
        internal readonly IDictionary<string, object> controlHtmlAttributes = new Dictionary<string, object>();
        internal readonly IDictionary<string, object> formGroupHtmlAttributes = new Dictionary<string, object>();
        internal int? labelWidthLg;
        internal int? labelWidthMd;
        internal int? labelWidthSm;
        internal int? labelWidthXs;
        internal int? controlWidthLg;
        internal int? controlWidthMd;
        internal int? controlWidthSm;
        internal int? controlWidthXs;
        internal FormGroupValidationState validationState = FormGroupValidationState.Default;
        internal Icon feedbackIcon;
        internal bool useDefaultFeedbackIcon;
        internal InputSize size = InputSize.Default;

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(labelHtmlAttributes != null);
            Contract.Invariant(controlHtmlAttributes != null);
            Contract.Invariant(formGroupHtmlAttributes != null);
        }

		internal FormGroup(HtmlHelper<TModel> html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");

			this.html = html;
        }

		internal FormGroup(HtmlHelper<TModel> html, Form form)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(form != null, "form");

            this.html = html;
            formType = form.formType;

            labelWidthXs = form.labelWidthXs;
            labelWidthSm = form.labelWidthSm;
            labelWidthMd = form.labelWidthMd;
            labelWidthLg = form.labelWidthLg;
            controlWidthXs = form.controlWidthXs;
            controlWidthSm = form.controlWidthSm;
            controlWidthMd = form.controlWidthMd;
            controlWidthLg = form.controlWidthLg;

            LabelHtmlAttributes(form.labelHtmlAttributes);
            ControlHtmlAttributes(form.controlHtmlAttributes);
        }

        internal FormGroup(AjaxHelper<TModel> ajax, AjaxForm form)
        {
            Contract.Requires<ArgumentNullException>(ajax != null, "ajax");
            Contract.Requires<ArgumentNullException>(form != null, "form");

            html = new HtmlHelper<TModel>(ajax.ViewContext, ajax.ViewDataContainer, ajax.RouteCollection);
            formType = form.formType;

            labelWidthXs = form.labelWidthXs;
            labelWidthSm = form.labelWidthSm;
            labelWidthMd = form.labelWidthMd;
            labelWidthLg = form.labelWidthLg;
            controlWidthXs = form.controlWidthXs;
            controlWidthSm = form.controlWidthSm;
            controlWidthMd = form.controlWidthMd;
            controlWidthLg = form.controlWidthLg;

            LabelHtmlAttributes(form.labelHtmlAttributes);
            ControlHtmlAttributes(form.controlHtmlAttributes);
        }

        internal FormGroup(HtmlHelper<TModel> html, NavBarForm form)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(form != null, "form");

            this.html = html;
            formType = form.formType;

            labelWidthXs = form.labelWidthXs;
            labelWidthSm = form.labelWidthSm;
            labelWidthMd = form.labelWidthMd;
            labelWidthLg = form.labelWidthLg;
            controlWidthXs = form.controlWidthXs;
            controlWidthSm = form.controlWidthSm;
            controlWidthMd = form.controlWidthMd;
            controlWidthLg = form.controlWidthLg;

            LabelHtmlAttributes(form.labelHtmlAttributes);
            ControlHtmlAttributes(form.controlHtmlAttributes);
        }

        public FormGroup<TModel> ValidationState(FormGroupValidationState state)
        {
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            validationState = state;
            SetDefaultFeedbackIcon();

            return (FormGroup<TModel>)this;
        }

        public FormGroup<TModel> FeedbackIcon(bool useDefault = true)
        {
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            useDefaultFeedbackIcon = useDefault;
            SetDefaultFeedbackIcon();

            return (FormGroup<TModel>)this;
        }

        public FormGroup<TModel> FeedbackIcon(GlyphIcon icon)
        {
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            feedbackIcon = icon.Class("form-control-feedback");

            return (FormGroup<TModel>)this;
        }

        public FormGroup<TModel> FeedbackIcon(FontAwesomeIcon icon)
        {
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            feedbackIcon = icon.Class("form-control-feedback");

            return (FormGroup<TModel>)this;
        }

        public FormGroup<TModel> FeedbackIcon(GlyphIconType icon)
        {
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            feedbackIcon = new GlyphIcon(icon).Class("form-control-feedback");

            return (FormGroup<TModel>)this;
        }

        public FormGroup<TModel> FeedbackIcon(FontAwesomeIconType icon)
        {
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            feedbackIcon = new FontAwesomeIcon(icon).Class("form-control-feedback");

            return (FormGroup<TModel>)this;
        }

        public FormGroup<TModel> Size(InputSize inputSize)
        {
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            size = inputSize;

            return this;
        }

        public FormGroup<TModel> Type(FormType type)
        {
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            formType = type;

            return (FormGroup<TModel>)this;
        }

        public FormGroup<TModel> FormGroupClass(string cssClass)
		{
            Contract.Requires<ArgumentException>(!cssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            formGroupHtmlAttributes.AddIfNotExistsCssClass(cssClass);

			return this;
		}

        public FormGroup<TModel> FormGroupDataAttributes(object htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            formGroupHtmlAttributes.AddOrReplaceHtmlAttributes(htmlAttributes.ToHtmlDataAttributes());

            return this;
        }

        public FormGroup<TModel> FormGroupHtmlAttributes(object htmlAttributes)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            formGroupHtmlAttributes.AddOrReplaceHtmlAttributes(htmlAttributes.ToDictionary());

            return this;
        }

        public FormGroup<TModel> FormGroupHtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            //x Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            formGroupHtmlAttributes.AddOrReplaceHtmlAttributes(htmlAttributes);

            return (FormGroup<TModel>)this;
        }

        public FormGroup<TModel> LabelHtmlAttributes(object htmlAttributes) // TODO: add overrides for controls and labels attributes/cssclass/etc  ALSO add to form so multiple formgroups can share attrs
		{
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            labelHtmlAttributes.AddOrReplaceHtmlAttributes(htmlAttributes.ToDictionary());

			return this;
		}

        public FormGroup<TModel> LabelHtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            //x Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            labelHtmlAttributes.AddOrReplaceHtmlAttributes(htmlAttributes);

            return this;
        }

        public FormGroup<TModel> ControlHtmlAttributes(object htmlAttributes) // TODO: add overrides for controls and labels attributes/cssclass/etc  ALSO add to form so multiple formgroups can share attrs
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            controlHtmlAttributes.AddOrReplaceHtmlAttributes(htmlAttributes.ToDictionary());

            return this;
        }

        public FormGroup<TModel> ControlHtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            //x Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            controlHtmlAttributes.AddOrReplaceHtmlAttributes(htmlAttributes);

            return this;
        }

        public FormGroup<TModel> ControlWidthLg(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            controlWidthLg = width;

            return this;
        }

        public FormGroup<TModel> ControlWidthMd(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            controlWidthMd = width;

            return this;
        }

        public FormGroup<TModel> ControlWidthSm(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            controlWidthSm = width;

            return this;
        }

        public FormGroup<TModel> ControlWidthXs(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            controlWidthXs = width;

            return this;
        }

        public FormGroup<TModel> ControlWidth(int? widthLg, int? widthMd, int? widthSm, int? widthXs)
        {
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            controlWidthLg = widthLg;
            controlWidthMd = widthMd;
            controlWidthSm = widthSm;
            controlWidthXs = widthXs;

            return this;
        }

        public FormGroup<TModel> LabelWidthLg(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            labelWidthLg = width;
            formType = FormType.Horizontal;

            return this;
        }

        public FormGroup<TModel> LabelWidthMd(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            labelWidthMd = width;
            formType = FormType.Horizontal;

            return this;
        }

        public FormGroup<TModel> LabelWidthSm(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            labelWidthSm = width;
            formType = FormType.Horizontal;

            return this;
        }

        public FormGroup<TModel> LabelWidthXs(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            labelWidthXs = width;
            formType = FormType.Horizontal;

            return this;
        }

        public FormGroup<TModel> LabelWidth(int? widthLg, int? widthMd, int? widthSm, int? widthXs)
        {
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            labelWidthLg = widthLg;
            labelWidthMd = widthMd;
            labelWidthSm = widthSm;
            labelWidthXs = widthXs;

            return this;
        }

        public CheckBoxControl<TModel> CheckBox(string htmlFieldName)
		{
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<CheckBoxControl<TModel>>() != null);

			return new CheckBoxControl<TModel>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData)).FormGroup(this);
		}

        public CheckBoxControl<TModel> CheckBoxFor<TValue>(Expression<Func<TModel, TValue>> expression)
		{
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<CheckBoxControl<TModel>>() != null);

            return new CheckBoxControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData)).FormGroup(this);
		}

        public CheckBoxListFromEnumControl<TModel, TValue> CheckBoxesFromEnum<TValue>(string htmlFieldName)
            where TValue : struct, IConvertible
        {
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<CheckBoxListFromEnumControl<TModel, TValue>>() != null);

            return new CheckBoxListFromEnumControl<TModel, TValue>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData)).FormGroup(this);
		}

        public CheckBoxListFromEnumControl<TModel, TValue> CheckBoxesFromEnumFor<TValue>(Expression<Func<TModel, TValue>> expression)
            where TValue : struct, IConvertible
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<CheckBoxListFromEnumControl<TModel, TValue>>() != null);

            return new CheckBoxListFromEnumControl<TModel, TValue>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData)).FormGroup(this);
		}

        public CheckBoxListControl<TModel, TSource, SValue, SText> CheckBoxList<TSource, SValue, SText>(string htmlFieldName, Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
		{
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(sourceDataExpression != null, "sourceDataExpression");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
            Contract.Ensures(Contract.Result<CheckBoxListControl<TModel, TSource, SValue, SText>>() != null);

            return new CheckBoxListControl<TModel, TSource, SValue, SText>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData), sourceDataExpression, valueExpression, textExpression).FormGroup(this);
		}

        public CheckBoxListControl<TModel, TSource, SValue, SText> CheckBoxList<TSource, SValue, SText>(string htmlFieldName, IEnumerable<TSource> sourceData, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
		{
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(sourceData != null, "sourceData");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
            Contract.Ensures(Contract.Result<CheckBoxListControl<TModel, TSource, SValue, SText>>() != null);

            return new CheckBoxListControl<TModel, TSource, SValue, SText>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData), sourceData, valueExpression, textExpression).FormGroup(this);
		}

        public CheckBoxListControl<TModel, TSource, SValue, SText> CheckBoxListFor<TValue, TSource, SValue, SText>(Expression<Func<TModel, TValue>> expression, Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
		{
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Requires<ArgumentNullException>(sourceDataExpression != null, "sourceDataExpression");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
            Contract.Ensures(Contract.Result<CheckBoxListControl<TModel, TSource, SValue, SText>>() != null);

            return new CheckBoxListControl<TModel, TSource, SValue, SText>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData), sourceDataExpression, valueExpression, textExpression).FormGroup(this);
		}

        public CheckBoxListControl<TModel, TSource, SValue, SText> CheckBoxListFor<TValue, TSource, SValue, SText>(Expression<Func<TModel, TValue>> expression, IEnumerable<TSource> sourceData, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
		{
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Requires<ArgumentNullException>(sourceData != null, "sourceData");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
            Contract.Ensures(Contract.Result<CheckBoxListControl<TModel, TSource, SValue, SText>>() != null);

            return new CheckBoxListControl<TModel, TSource, SValue, SText>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData), sourceData, valueExpression, textExpression).FormGroup(this);
		}

        public ControlGroupControl<TModel> CustomControls(string controls)
        {
            Contract.Requires<ArgumentException>(!controls.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ControlGroupControl<TModel>>() != null);

            IHtmlString[] htmlStrings = new IHtmlString[] { MvcHtmlString.Create(controls) };

            return CustomControls(htmlStrings);
        }

        public ControlGroupControl<TModel> CustomControls(params IHtmlString[] controls)
        {
            Contract.Requires<ArgumentNullException>(controls != null, "controls");
            Contract.Ensures(Contract.Result<ControlGroupControl<TModel>>() != null);

            List<IHtmlString> controlList = new List<IHtmlString>();
            foreach (var item in controls)
            {
                controlList.Add(item);
            }

            return new ControlGroupControl<TModel>(html, controlList).FormGroup(this);
        }

		public DisplayControl<TModel> Display(string expression)
		{
            Contract.Requires<ArgumentException>(!expression.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DisplayControl<TModel>>() != null);

            return new DisplayControl<TModel>(html, expression, ModelMetadata.FromStringExpression(expression, html.ViewData)).FormGroup(this);
		}

        public DisplayControl<TModel> DisplayFor<TValue>(Expression<Func<TModel, TValue>> expression)
		{
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<DisplayControl<TModel>>() != null);

            return new DisplayControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData)).FormGroup(this);
		}

        public ControlGroupControl<TModel> StaticText(string html)
        {
            Contract.Requires<ArgumentException>(!html.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<ControlGroupControl<TModel>>() != null);

            var p = new TagBuilder("p");
            p.AddCssClass("form-control-static");
            p.InnerHtml = html;

            return CustomControls(p.ToString());
        }

        public DisplayTextControl<TModel> DisplayText(string htmlFieldName)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DisplayTextControl<TModel>>() != null);

            return new DisplayTextControl<TModel>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData)).FormGroup(this);
		}

        public DisplayTextControl<TModel> DisplayTextFor<TValue>(Expression<Func<TModel, TValue>> expression)
		{
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<DisplayTextControl<TModel>>() != null);

            return new DisplayTextControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData)).FormGroup(this);
		}

        public DropDownListControl<TModel> DropDownList(string htmlFieldName, IEnumerable<SelectListItem> selectList)
		{
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(selectList != null, "selectList");
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            return new DropDownListControl<TModel>(html, htmlFieldName, selectList, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData)).FormGroup(this);
		}

        public DropDownListControl<TModel> DropDownList(string htmlFieldName, string optionLabel)
		{
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(optionLabel != null, "optionLabel");
            Contract.Requires<ArgumentException>(!optionLabel.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            return new DropDownListControl<TModel>(html, htmlFieldName, optionLabel, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData)).FormGroup(this);
		}

        public DropDownListControl<TModel> DropDownListFor<TValue>(Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectList)
		{
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Requires<ArgumentNullException>(selectList != null, "selectList");
            Contract.Ensures(Contract.Result<DropDownListControl<TModel>>() != null);

            return new DropDownListControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), selectList, ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData)).FormGroup(this);
		}

		public DropDownListFromEnumControl<TModel, TValue> DropDownListFromEnum<TValue>(string htmlFieldName)
        where TValue : struct, IConvertible
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            return new DropDownListFromEnumControl<TModel, TValue>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData)).FormGroup(this);
		}

        public DropDownListFromEnumControl<TModel, TValue> DropDownListFromEnumFor<TValue>(Expression<Func<TModel, TValue>> expression)
        where TValue : struct, IConvertible
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<DropDownListFromEnumControl<TModel, TValue>>() != null);

            return new DropDownListFromEnumControl<TModel, TValue>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData)).FormGroup(this);
		}

		public EditorControl<TModel> Editor(string expression)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Requires<ArgumentException>(!expression.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<EditorControl<TModel>>() != null);

            return new EditorControl<TModel>(html, expression, ModelMetadata.FromStringExpression(expression, html.ViewData)).FormGroup(this);
		}

        public EditorControl<TModel> EditorFor<TValue>(Expression<Func<TModel, TValue>> expression)
		{
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<EditorControl<TModel>>() != null);

            return new EditorControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData)).FormGroup(this);
		}

		public FileControl<TModel> File(string htmlFieldName)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<FileControl<TModel>>() != null);

            return new FileControl<TModel>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData)).FormGroup(this);
		}

        public FileControl<TModel> FileFor<TValue>(Expression<Func<TModel, TValue>> expression)
		{
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<FileControl<TModel>>() != null);

            return new FileControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData)).FormGroup(this);
		}

		public ListBoxControl<TModel> ListBox(string htmlFieldName, IEnumerable<SelectListItem> selectList)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(selectList != null, "selectList");
            Contract.Ensures(Contract.Result<ListBoxControl<TModel>>() != null);

            return new ListBoxControl<TModel>(html, htmlFieldName, selectList, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData)).FormGroup(this);
		}

        public ListBoxControl<TModel> ListBoxFor<TValue>(Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectList)
		{
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Requires<ArgumentNullException>(selectList != null, "selectList");

            return new ListBoxControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), selectList, ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData)).FormGroup(this);
		}

		public PasswordControl<TModel> Password(string htmlFieldName)
		{
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            return new PasswordControl<TModel>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData)).FormGroup(this);
		}

        public PasswordControl<TModel> PasswordFor<TValue>(Expression<Func<TModel, TValue>> expression)
		{
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<PasswordControl<TModel>>() != null);

            return new PasswordControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData)).FormGroup(this);
		}

		public RadioButtonControl<TModel> RadioButton(string htmlFieldName, object value)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<RadioButtonControl<TModel>>() != null);

            return new RadioButtonControl<TModel>(html, htmlFieldName, value, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData)).FormGroup(this);
		}

        public RadioButtonControl<TModel> RadioButtonFor<TValue>(Expression<Func<TModel, TValue>> expression, object value)
		{
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<RadioButtonControl<TModel>>() != null);

            return new RadioButtonControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), value, ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData)).FormGroup(this);
		}

		public RadioButtonListControl<TModel, TSource, SValue, SText> RadioButtonList<TSource, SValue, SText>(string htmlFieldName, Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
		{
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(sourceDataExpression != null, "sourceDataExpression");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
            Contract.Ensures(Contract.Result<RadioButtonListControl<TModel, TSource, SValue, SText>>() != null);

            return new RadioButtonListControl<TModel, TSource, SValue, SText>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData), sourceDataExpression, valueExpression, textExpression).FormGroup(this);
		}

        public RadioButtonListControl<TModel, TSource, SValue, SText> RadioButtonList<TSource, SValue, SText>(string htmlFieldName, IEnumerable<TSource> sourceData, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
		{
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(sourceData != null, "sourceData");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
            Contract.Ensures(Contract.Result<RadioButtonListControl<TModel, TSource, SValue, SText>>() != null);

            return new RadioButtonListControl<TModel, TSource, SValue, SText>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData), sourceData, valueExpression, textExpression).FormGroup(this);
		}

        public RadioButtonListControl<TModel, TSource, SValue, SText> RadioButtonListFor<TValue, TSource, SValue, SText>(Expression<Func<TModel, TValue>> expression, Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
		{
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Requires<ArgumentNullException>(sourceDataExpression != null, "sourceDataExpression");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
            Contract.Ensures(Contract.Result<RadioButtonListControl<TModel, TSource, SValue, SText>>() != null);

            return new RadioButtonListControl<TModel, TSource, SValue, SText>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData), sourceDataExpression, valueExpression, textExpression).FormGroup(this);
		}

        public RadioButtonListControl<TModel, TSource, SValue, SText> RadioButtonListFor<TValue, TSource, SValue, SText>(Expression<Func<TModel, TValue>> expression, IEnumerable<TSource> sourceData, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
		{
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Requires<ArgumentNullException>(sourceData != null, "sourceData");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");
            Contract.Ensures(Contract.Result<RadioButtonListControl<TModel, TSource, SValue, SText>>() != null);

            return new RadioButtonListControl<TModel, TSource, SValue, SText>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData), sourceData, valueExpression, textExpression).FormGroup(this);
		}

        public RadioButtonListFromEnumControl<TModel> RadioButtonsFromEnum<TValue>(string htmlFieldName)
		{
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Ensures(Contract.Result<RadioButtonListFromEnumControl<TModel>>() != null);

            return new RadioButtonListFromEnumControl<TModel>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData)).FormGroup(this);
		}

        public RadioButtonListFromEnumControl<TModel> RadioButtonsFromEnumFor<TValue>(Expression<Func<TModel, TValue>> expression)
		{
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<RadioButtonListFromEnumControl<TModel>>() != null);

            return new RadioButtonListFromEnumControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData)).FormGroup(this);
		}

		public RadioButtonTrueFalseControl<TModel> RadioButtonTrueFalse(string htmlFieldName)
		{
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            return new RadioButtonTrueFalseControl<TModel>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData)).FormGroup(this);
		}

        public RadioButtonTrueFalseControl<TModel> RadioButtonTrueFalseFor<TValue>(Expression<Func<TModel, TValue>> expression)
		{
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<RadioButtonTrueFalseControl<TModel>>() != null);

            return new RadioButtonTrueFalseControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData)).FormGroup(this);
        }

        //public StaticTextControl<TModel> Static(string text)
        //{
        //    //x Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(text));
        //    Contract.Ensures(Contract.Result<TextAreaControl<TModel>>() != null);

        //    return new StaticTextControl<TModel>(this.html, text).FormGroup(this);
        //}

        public TextAreaControl<TModel> TextArea(string htmlFieldName)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TextAreaControl<TModel>>() != null);

            return new TextAreaControl<TModel>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData)).FormGroup(this);
		}

        public TextAreaControl<TModel> TextAreaFor<TValue>(Expression<Func<TModel, TValue>> expression)
		{
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<TextAreaControl<TModel>>() != null);

            return new TextAreaControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData)).FormGroup(this);
		}

		public TextBoxControl<TModel> TextBox(string htmlFieldName)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

            return new TextBoxControl<TModel>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData)).FormGroup(this);
		}

        public TextBoxControl<TModel> TextBoxFor<TValue>(Expression<Func<TModel, TValue>> expression)
		{
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<TextBoxControl<TModel>>() != null);

            return new TextBoxControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData)).FormGroup(this);
		}

        public DatePickerControl<TModel> DatePicker(string htmlFieldName)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            return new DatePickerControl<TModel>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData)).FormGroup(this);
        }

        public DatePickerControl<TModel> DatePickerFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<DatePickerControl<TModel>>() != null);

            return new DatePickerControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData)).FormGroup(this);
        }

        public CkEditorControl<TModel> CkEditor(string htmlFieldName)
        {
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<CkEditorControl<TModel>>() != null);

            return new CkEditorControl<TModel>(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData)).FormGroup(this);
        }

        public CkEditorControl<TModel> CkEditorFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            Contract.Requires<ArgumentNullException>(expression != null, "expression");
            Contract.Ensures(Contract.Result<CkEditorControl<TModel>>() != null);

            return new CkEditorControl<TModel>(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData)).FormGroup(this);
        }

        private void SetDefaultFeedbackIcon()
        {
            if (useDefaultFeedbackIcon)
            {
                switch (validationState)
                {
                    case FormGroupValidationState.Success:
                        FeedbackIcon(GlyphIconType.Ok);
                        break;
                    case FormGroupValidationState.Warning:
                        FeedbackIcon(GlyphIconType.WarningSign);
                        break;
                    case FormGroupValidationState.Error:
                        FeedbackIcon(GlyphIconType.Remove);
                        break;
                    default:
                        feedbackIcon = null;
                        break;
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Type GetType()
		{
			return base.GetType();
		}
	}
}