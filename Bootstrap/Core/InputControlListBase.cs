using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap;
using System.Diagnostics.Contracts;
using System.Text;
using HyperSlackers.Bootstrap.Controls;
using System.Diagnostics;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Core
{
    /// <summary>
    /// Base class for lists of input controls.
    /// </summary>
    /// <typeparam name="TControl">The type of the control.</typeparam>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="SValue">The type of the value.</typeparam>
    /// <typeparam name="SText">The type of the text.</typeparam>
    public class InputControlListBase<TControl, TModel, TSource, SValue, SText> : ControlListBase<TControl, TModel> where TControl : InputControlListBase<TControl, TModel, TSource, SValue, SText>
    {
        internal List<TSource> sourceData;
        internal Expression<Func<TSource, SValue>> valueExpression;
        internal Expression<Func<TSource, SText>> textExpression;
        internal Expression<Func<TSource, object>> controlHtmlAttributesExpression;
        internal Expression<Func<TSource, object>> labelHtmlAttributesExpression;
        internal Expression<Func<TSource, bool>> checkedValueExpression;
        internal Expression<Func<TSource, bool>> disabledValueExpression;
        internal bool displayInlineBlock;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputControlListBase{TControl, TModel, TSource, SValue, SText}"/> class.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="htmlFieldName">Name of the HTML field.</param>
        /// <param name="metadata">The metadata.</param>
        /// <param name="sourceDataExpression">The source data expression.</param>
        /// <param name="valueExpression">The value expression.</param>
        /// <param name="textExpression">The text expression.</param>
        /// <exception cref="System.ArgumentException">The data source cannot be null</exception>
        public InputControlListBase(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata, Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
            : base(html, htmlFieldName, metadata)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
            Contract.Requires<ArgumentNullException>(sourceDataExpression != null, "sourceDataExpression");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");

            try
            {
                this.sourceData = sourceDataExpression.Compile()((TModel)html.ViewData.Model).ToList<TSource>();
            }
            catch (ArgumentNullException argumentNullException)  // TODO: redo this?
            {
                Debug.WriteLine(argumentNullException.Message);
                throw new ArgumentException("The data source cannot be null");
            }

            this.valueExpression = valueExpression;
            this.textExpression = textExpression;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputControlListBase{TControl, TModel, TSource, SValue, SText}"/> class.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="htmlFieldName">Name of the HTML field.</param>
        /// <param name="metadata">The metadata.</param>
        /// <param name="sourceData">The source data.</param>
        /// <param name="valueExpression">The value expression.</param>
        /// <param name="textExpression">The text expression.</param>
        public InputControlListBase(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata, IEnumerable<TSource> sourceData, Expression<Func<TSource, SValue>> valueExpression, Expression<Func<TSource, SText>> textExpression)
            : base(html, htmlFieldName, metadata)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
            Contract.Requires<ArgumentNullException>(sourceData != null, "sourceData");
            Contract.Requires<ArgumentNullException>(valueExpression != null, "valueExpression");
            Contract.Requires<ArgumentNullException>(textExpression != null, "textExpression");

            this.sourceData = sourceData.ToList<TSource>();
            this.valueExpression = valueExpression;
            this.textExpression = textExpression;
        }

        /// <summary>
        /// Sets the "disabled" values for the list.
        /// </summary>
        /// <param name="disabledValueExpression">The disabled value expression.</param>
        /// <returns></returns>
        public TControl DisabledValues(Expression<Func<TSource, bool>> disabledValueExpression)
        {
            Contract.Requires<ArgumentNullException>(disabledValueExpression != null, "disabledValueExpression");
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.disabledValueExpression = disabledValueExpression;

            return (TControl)this;
        }

        /// <summary>
        /// Displays the list in columns.
        /// </summary>
        /// <param name="numberOfColumns">The number of columns.</param>
        /// <param name="columnPixelWidth">Width of the column pixel.</param>
        /// <returns></returns>
        public TControl DisplayInColumns(int numberOfColumns, int columnPixelWidth)
        {
            Contract.Requires<ArgumentOutOfRangeException>(numberOfColumns > 0);
            Contract.Requires<ArgumentOutOfRangeException>(columnPixelWidth > 0);
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.numberOfColumns = new int?(numberOfColumns);
            this.columnPixelWidth = columnPixelWidth;

            return (TControl)this;
        }

        /// <summary>
        /// Displays the list in columns.
        /// </summary>
        /// <param name="numberOfColumns">The number of columns.</param>
        /// <param name="columnPixelWidth">Width of the column pixel.</param>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <returns></returns>
        public TControl DisplayInColumns(int numberOfColumns, int columnPixelWidth, bool condition)
        {
            Contract.Requires<ArgumentOutOfRangeException>(numberOfColumns > 0);
            Contract.Requires<ArgumentOutOfRangeException>(columnPixelWidth > 0);
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.numberOfColumns = new int?(numberOfColumns);
            this.columnPixelWidth = columnPixelWidth;
            this.displayInColumnsCondition = condition;

            return (TControl)this;
        }

        /// <summary>
        /// Displays the list inline block.
        /// </summary>
        /// <returns></returns>
        public TControl DisplayInlineBlock()
        {
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.displayInlineBlock = true;

            return (TControl)this;
        }

        /// <summary>
        /// Sets additional HTML attributes on the control.
        /// </summary>
        /// <param name="htmlAttributesExpression">The HTML attributes expression.</param>
        /// <returns></returns>
        public TControl ControlHtmlAttributes(Expression<Func<TSource, object>> htmlAttributesExpression)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributesExpression != null, "htmlAttributesExpression");
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.controlHtmlAttributesExpression = htmlAttributesExpression;

            return (TControl)this;
        }

        /// <summary>
        /// Sets additional HTML attributes on the label.
        /// </summary>
        /// <param name="htmlAttributesExpression">The HTML attributes expression.</param>
        /// <returns></returns>
        public TControl LabelHtmlAttributes(Expression<Func<TSource, object>> htmlAttributesExpression)
        {
            Contract.Requires<ArgumentNullException>(htmlAttributesExpression != null, "htmlAttributesExpression");
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.labelHtmlAttributesExpression = htmlAttributesExpression;

            return (TControl)this;
        }

        /// <summary>
        /// Sets the "selected" values for the list.
        /// </summary>
        /// <param name="selectedValueExpression">The selected value expression.</param>
        /// <returns></returns>
        public TControl SelectedValues(Expression<Func<TSource, bool>> selectedValueExpression)
        {
            Contract.Requires<ArgumentNullException>(selectedValueExpression != null, "selectedValueExpression");
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.checkedValueExpression = selectedValueExpression;

            return (TControl)this;
        }

        /// <summary>
        /// Renders the control.
        /// </summary>
        /// <returns></returns>
        protected override string RenderControl()
        {
            Contract.Ensures(!String.IsNullOrEmpty(Contract.Result<string>()));

            if (this.sourceData == null)
            {
                return string.Empty;
            }

            if (this.html.ViewData.Model == null)
            {
                return string.Empty;
            }

            Func<TSource, SValue> valueFunc = this.valueExpression.Compile();

            Func<TSource, SText> textFunc = this.textExpression.Compile();

            Func<TSource, object> inputAttributesFunc = null;
            if (this.controlHtmlAttributesExpression != null)
            {
                inputAttributesFunc = this.controlHtmlAttributesExpression.Compile();
            }

            Func<TSource, object> labelHtmlAttributesFunc = null;
            if (this.labelHtmlAttributesExpression != null)
            {
                labelHtmlAttributesFunc = this.labelHtmlAttributesExpression.Compile();
            }

            Func<TSource, bool> checkedValueFunc = null;
            if (this.checkedValueExpression != null)
            {
                checkedValueFunc = this.checkedValueExpression.Compile();
            }

            Func<TSource, bool> disabledValueFunc = null;
            if (this.disabledValueExpression != null)
            {
                disabledValueFunc = this.disabledValueExpression.Compile();
            }

            Func<TSource, object> inputAttributesFunc2 = inputAttributesFunc;
            Func<TSource, object> labelHtmlAttributesFunc2 = labelHtmlAttributesFunc;
            Func<TSource, bool> checkedValueFunc2 = checkedValueFunc;
            Func<TSource, bool> disabledValueFunc2 = disabledValueFunc;

            List<string> inputs = new List<string>();
            int inputCount = 0;
            foreach (TSource item in this.sourceData)
            {
                string itemValue = valueFunc(item).ToString();
                string itemText = textFunc(item).ToString();
                object itemInputAttributes = (inputAttributesFunc2 != null ? inputAttributesFunc2(item) : null);
                object itemLabelAttributes = (labelHtmlAttributesFunc2 != null ? labelHtmlAttributesFunc2(item) : null);
                bool itemIsChecked = (checkedValueFunc2 == null ? false : checkedValueFunc2(item));
                bool itemIsDisabled = (disabledValueFunc2 == null ? false : disabledValueFunc2(item));

                inputs.Add(RenderControlListItem(inputCount, itemValue, itemText, itemInputAttributes.ToDictionary(), itemLabelAttributes.ToDictionary(), itemIsChecked, itemIsDisabled));

                inputCount++;
            }

            return RenderControlListContainer(inputs);
        }
    }
}