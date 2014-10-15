using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
	public class Form : FormBase<Form>
	{
        public Form(string id) 
            : base(id)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
		}

		public Form(string id, string action)
            : base(id, action)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace()); 
            Contract.Requires<ArgumentException>(!action.IsNullOrWhiteSpace());
		}

		public Form(string id, string action, string controller)
            : base(id, action, controller)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace()); 
            Contract.Requires<ArgumentException>(!action.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controller.IsNullOrWhiteSpace());
		}

        public Form(string id, ActionResult result)
            : base(id, result)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace()); 
            Contract.Requires<ArgumentNullException>(result != null, "result");
		}

        public Form(string id, Task<ActionResult> taskResult)
            : base(id, taskResult)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace()); 
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");
		}
	}
}