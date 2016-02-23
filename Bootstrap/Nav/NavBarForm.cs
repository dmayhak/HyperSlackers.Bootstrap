using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
    public class NavBarForm : FormBase<NavBarForm> // TODO:  WIP
    {
        public NavBarForm(string id) 
            : base(id)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());

            Inline();
        }

        public NavBarForm(string id, string action)
            : base(id, action)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!action.IsNullOrWhiteSpace());

            Inline();
        }

        public NavBarForm(string id, string action, string controller)
            : base(id, action, controller)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!action.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controller.IsNullOrWhiteSpace());

            Inline();
        }

        public NavBarForm(string id, ActionResult result)
            : base(id, result)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");

            Inline();
        }

        public NavBarForm(string id, Task<ActionResult> taskResult)
            : base(id, taskResult)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");

            Inline();
        }
    }
}
