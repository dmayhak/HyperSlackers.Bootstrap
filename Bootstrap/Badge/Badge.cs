using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class Badge : HtmlElement<Badge>
    {
        internal string text;

        public Badge(string text)
            : base("span")
        {
            this.text = text;
            AddClass("badge");
        }

        internal override string ToHtmlString()
        {
            return base.ToHtmlString(text);
        }
    }
}
