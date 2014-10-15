using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
	public class LabelControl<TModel> : ControlBase<LabelControl<TModel>, TModel>
	{
        internal string htmlFieldName;
        internal string labelText;
        internal bool? showRequiredStar;
        internal ModelMetadata metadata;

		internal LabelControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata)
            : base(html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace()); 
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");

			this.htmlFieldName = htmlFieldName;
			this.metadata = metadata;
		}

        public LabelControl<TModel> LabelHtml(params IHtmlString[] label)
		{
            Contract.Requires<ArgumentNullException>(label != null, "label");
            Contract.Ensures(Contract.Result<LabelControl<TModel>>() != null);

            foreach (var item in label)
            {
                this.labelText += item.ToHtmlString();
            }

            return this;
		}

        public LabelControl<TModel> LabelText(string labelText)
		{
            Contract.Requires<ArgumentException>(!labelText.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<LabelControl<TModel>>() != null);

			this.labelText = labelText;
			
            return this;
		}

        public LabelControl<TModel> ShowRequiredStar(bool showRequiredStar)
		{
            Contract.Ensures(Contract.Result<LabelControl<TModel>>() != null);

			this.showRequiredStar = new bool?(showRequiredStar);
			
            return this;
		}

        protected override string Render()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            TagBuilder labelTagBuilder = GetLabelTagBuilder();

            SetLabelText();
            if (this.labelText.IsNullOrWhiteSpace())
            {
                labelTagBuilder.InnerHtml = this.labelText;
            }
            else
            {
                labelTagBuilder.InnerHtml = this.labelText + GetRequiredStarTagBuilder().ToString();
            }
            
            return MvcHtmlString.Create("{0}".FormatWith(labelTagBuilder.ToString(TagRenderMode.Normal))).ToHtmlString();
		}

        protected string GetFullHtmlFieldName()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            return html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(this.htmlFieldName);
        }

        protected void SetLabelText()
        {
            if (!this.labelText.IsNullOrWhiteSpace())
            {
                return;
            }

            string displayName = this.metadata.DisplayName;

            if (displayName == null)
            {
                if (this.metadata.PropertyName != null)
                {
                    displayName = this.metadata.PropertyName.SpaceOnUpperCase();
                }
                else
                {
                    displayName = null;
                }

                if (displayName == null)
                {
                    char[] chrArray = new char[] { '.' };
                    displayName = GetFullHtmlFieldName().Split(chrArray).Last().SpaceOnUpperCase();
                }
            }

            this.labelText = displayName;
        }

        protected TagBuilder GetLabelTagBuilder()
        {
            Contract.Ensures(Contract.Result<TagBuilder>() != null);

            TagBuilder labelTagBuilder = new TagBuilder("label");

            labelTagBuilder.Attributes.Add("for", string.Concat(GetFullHtmlFieldName().FormatForMvcInputId(), (this.index.HasValue ? string.Concat("_", this.index.Value) : string.Empty)));
            labelTagBuilder.MergeHtmlAttributes(this.controlHtmlAttributes.FormatHtmlAttributes());

            return labelTagBuilder;
        }

        protected TagBuilder GetRequiredStarTagBuilder()
        {
            Contract.Ensures(Contract.Result<TagBuilder>() != null);

            TagBuilder requiredStarTagBuilder = new TagBuilder("span");

            requiredStarTagBuilder.AddCssClass("required");
            requiredStarTagBuilder.SetInnerText("*");

            bool showRequiredStar;
            if (this.showRequiredStar.HasValue)
            {
                showRequiredStar = this.showRequiredStar.GetValueOrDefault();
            }
            else if (html.BootstrapDefaults().DefaultShowRequiredStar.HasValue)
            {
                showRequiredStar = (this.labelText.IsNullOrWhiteSpace() ? false : html.BootstrapDefaults().DefaultShowRequiredStar.Value);
            }
            else
            {
                showRequiredStar = (this.labelText.IsNullOrWhiteSpace() || this.metadata == null ? false : this.metadata.IsRequired);
            }

            if (!showRequiredStar)
            {
                requiredStarTagBuilder.AddCssStyle("visibility", "hidden");
            }

            return requiredStarTagBuilder;
        }
	}
}