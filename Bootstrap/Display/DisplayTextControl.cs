using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class DisplayTextControl<TModel> : InputControlBase<DisplayTextControl<TModel>, TModel>
    {
        internal string text;

        internal DisplayTextControl(HtmlHelper<TModel> html, string htmlFieldName, ModelMetadata metadata)
            : base(html, htmlFieldName, metadata) 
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(htmlFieldName != null, "htmlFieldName");
            Contract.Requires<ArgumentException>(!htmlFieldName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
		}

        public DisplayTextControl<TModel> Text(string text)
        {
            Contract.Requires<ArgumentNullException>(text != null, "text");
            Contract.Requires<ArgumentException>(!text.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DisplayTextControl<TModel>>() != null);

            this.text = text;

            return this;
        }

        protected override string Render()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            TagBuilder tagBuilder = new TagBuilder("div");
            
            this.controlHtmlAttributes.AddClass("form-control-static");

            tagBuilder.MergeHtmlAttributes(this.controlHtmlAttributes.FormatHtmlAttributes());

            if (this.text != null)
            {
                tagBuilder.InnerHtml = text; // use text if it was provided
            }
            else if (this.metadata.Model != null && this.metadata.Model.GetType().IsEnum)
	        {
                tagBuilder.InnerHtml = ((Enum)this.metadata.Model).GetEnumDescription(); // TODO: refactor to use localization
	        }
            else
            {
		        tagBuilder.InnerHtml = html.DisplayText(this.htmlFieldName).ToHtmlString();
            }

            return tagBuilder.ToString(TagRenderMode.Normal);
        }
    }
}
