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
	public class AjaxForm : FormBase<AjaxForm>
	{
        internal bool renderSection = false; // if section is specified by user, don't render our own

		public AjaxForm(string id) 
            : base(id, string.Empty)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
		}

		public AjaxForm(string id, string action)
            : base(id, action)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!action.IsNullOrWhiteSpace());
		}

		public AjaxForm(string id, string action, string controller)
            : base(id, action, controller)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!action.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controller.IsNullOrWhiteSpace());
		}

        public AjaxForm(string id, ActionResult result)
            : base(id, result)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");
		}

        public AjaxForm(string id, Task<ActionResult> taskResult)
            : base(id, taskResult)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");
		}

        //internal AjaxForm AjaxOptions(AjaxOptions ajaxOptions)
        //{
        //    Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");
        //    Contract.Ensures(Contract.Result<AjaxForm>() != null);

        //    return this;
        //}

        //public AjaxForm AjaxAllowCache(bool allowCache = true)
        //{
        //    this.ajaxOptions.AllowCache = allowCache;

        //    return this;
        //}

        public AjaxForm AjaxConfirm(string message)
        {
            Contract.Requires<ArgumentException>(!message.IsNullOrWhiteSpace());

            ajaxOptions.Confirm = message;

            return this;
        }

        public AjaxForm AjaxInsertionMode(InsertionMode mode)
        {
            ajaxOptions.InsertionMode = mode;

            return this;
        }

        public AjaxForm AjaxLoadingElementDuration(int duration)
        {
            Contract.Requires<ArgumentOutOfRangeException>(duration >= 0);

            ajaxOptions.LoadingElementDuration = duration;

            return this;
        }

        public AjaxForm AjaxLoadingElementId(string id)
        {
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());

            ajaxOptions.LoadingElementId = id;

            return this;
        }

        public AjaxForm AjaxOnBegin(string jsFunctionName)
        {
            Contract.Requires<ArgumentException>(!jsFunctionName.IsNullOrWhiteSpace());

            ajaxOptions.OnBegin = jsFunctionName;

            return this;
        }

        public AjaxForm AjaxOnComplete(string jsFunctionName)
        {
            Contract.Requires<ArgumentException>(!jsFunctionName.IsNullOrWhiteSpace());

            ajaxOptions.OnComplete = jsFunctionName;

            return this;
        }

        public AjaxForm AjaxOnFailure(string jsFunctionName)
        {
            Contract.Requires<ArgumentException>(!jsFunctionName.IsNullOrWhiteSpace());

            ajaxOptions.OnFailure = jsFunctionName;

            return this;
        }

        public AjaxForm AjaxOnSuccess(string jsFunctionName)
        {
            Contract.Requires<ArgumentException>(!jsFunctionName.IsNullOrWhiteSpace());

            ajaxOptions.OnSuccess = jsFunctionName;

            return this;
        }

        public AjaxForm AjaxUpdateTargetId(string id)
        {
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());

            ajaxOptions.UpdateTargetId = id;

            return this;
        }

        public AjaxForm AjaxUrl(string url)
        {
            Contract.Requires<ArgumentException>(!url.IsNullOrWhiteSpace());

            ajaxOptions.Url = url;

            return this;
        }
	}
}