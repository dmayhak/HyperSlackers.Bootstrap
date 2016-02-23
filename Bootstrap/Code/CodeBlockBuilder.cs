using System;
using System.IO;
using System.Web.Mvc;
using HyperSlackers.Bootstrap;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class CodeBlockBuilder<TModel> : DisposableHtmlElement<TModel, CodeBlock>
	{
        internal CodeBlockBuilder(HtmlHelper<TModel> html, CodeBlock codeBlock) 
            : base(html, codeBlock)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(codeBlock != null, "codeBlock");

            textWriter.Write(element.StartTag); 
		}
	}
}