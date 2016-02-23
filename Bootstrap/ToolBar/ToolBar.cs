using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
	public class ToolBar : HtmlElement<ToolBar>
	{
		public ToolBar() 
            : base("div")
		{
            AddClass("btn-toolbar");
		}
    }
}