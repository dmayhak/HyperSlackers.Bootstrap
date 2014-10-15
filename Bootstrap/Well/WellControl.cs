using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    /// <summary>
    /// Creates a Bootstrap Well object. 
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class WellControl<TModel> : ControlBase<WellControl<TModel>, TModel>
    {
        internal string wellHtml;
        internal WellSize size = WellSize.Default;

        /// <summary>
        /// Initializes a new instance of the <see cref="WellControl{TModel}"/> class.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="wellHtml">The well HTML.</param>
        internal WellControl(HtmlHelper<TModel> html, string wellHtml)
            : base(html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentException>(!wellHtml.IsNullOrWhiteSpace());

            this.wellHtml = wellHtml;

            this.controlHtmlAttributes.AddClass("well");
		}

        /// <summary>
        /// Sets the Well's size.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public WellControl<TModel> Size(WellSize size)
        {
            Contract.Ensures(Contract.Result<WellControl<TModel>>() != null);

            this.size = size;

            return this;
        }

        protected override string Render()
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            IDictionary<string, object> attributes = this.controlHtmlAttributes.FormatHtmlAttributes();

            switch (size)
            {
                case WellSize.Large:
                    attributes.AddClass("well-lg");
                    break;
                case WellSize.Small:
                    attributes.AddClass("well-sm");
                    break;
                case WellSize.Default:
                default:
                    break;
            }

            TagBuilder tagBuilder = new TagBuilder("div");

            tagBuilder.MergeHtmlAttributes(attributes);

            tagBuilder.InnerHtml = this.wellHtml;

            return tagBuilder.ToString(TagRenderMode.Normal);
        }
    }
}
