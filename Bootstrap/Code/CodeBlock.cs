using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
	public class CodeBlock : HtmlElement<Alert>
	{
        public CodeBlock() 
            : base("pre")
		{
            AddClass("prettyprint");
		}

        public CodeBlock LineNumbers(int startAt = 1)
		{
            Contract.Ensures(Contract.Result<CodeBlock>() != null);

            if (startAt == 1)
            {
                AddClass("linenums");
            }
            else
            {
                AddClass("linenums:{0}".FormatWith(startAt));
            }

			return this;
		}
	}
}