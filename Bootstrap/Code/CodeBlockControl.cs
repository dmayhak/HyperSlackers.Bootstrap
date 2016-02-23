using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
	public class CodeBlockControl<TModel> : ControlBase<CodeBlockControl<TModel>, TModel> // TODO: should this be a formgroup control?
	{
        internal string code;
        internal int? startAt;

        internal CodeBlockControl(HtmlHelper<TModel> html, string code)
            : base(html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(code != null, "code");
            Contract.Requires<ArgumentException>(!code.IsNullOrWhiteSpace());

			this.code = code;

            controlHtmlAttributes.AddIfNotExistsCssClass("prettyprint");
		}

        public CodeBlockControl<TModel> LineNumbers(int startAt = 1)
		{
            Contract.Ensures(Contract.Result<CodeBlockControl<TModel>>() != null);

			this.startAt = startAt;

			return this;
		}

		protected override string Render()
		{
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            IDictionary<string, object> attributes = controlHtmlAttributes.FormatHtmlAttributes();

			TagBuilder tagBuilder = new TagBuilder("pre");

            if (startAt.HasValue)
            {
                if (startAt == 1)
                {
                    tagBuilder.AddCssClass("linenums");
                    controlHtmlAttributes.AddIfNotExistsCssClass("linenums");
                }
                else
                {
                    tagBuilder.AddCssClass("linenums:{0}".FormatWith(startAt));
                    controlHtmlAttributes.AddIfNotExistsCssClass("linenums:{0}".FormatWith(startAt));
                }
            }

			tagBuilder.MergeHtmlAttributes(attributes);

            tagBuilder.InnerHtml = code;

			return tagBuilder.ToString(TagRenderMode.Normal);
		}
	}
}