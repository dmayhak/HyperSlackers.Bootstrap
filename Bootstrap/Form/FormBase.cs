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
	public class FormBase<TControl> : HtmlElement<TControl> where TControl: FormBase<TControl>
	{
		internal string action;
		internal string controller;
		internal ActionResult result;
		internal Task<ActionResult> taskResult;
		internal RouteValueDictionary routeValues = new RouteValueDictionary();
		internal FormMethod formMethod;
        internal FormType formType = FormType.Default;
		internal ActionType actionTypePassed;
		internal int? labelWidthLg;
		internal int? labelWidthMd;
		internal int? labelWidthSm;
		internal int? labelWidthXs;
		internal int? controlWidthLg;
		internal int? controlWidthMd;
		internal int? controlWidthSm;
		internal int? controlWidthXs;
        internal readonly IDictionary<string, object> labelHtmlAttributes = new Dictionary<string, object>();
        internal readonly IDictionary<string, object> controlHtmlAttributes = new Dictionary<string, object>(); 
		internal AjaxOptions ajaxOptions = new AjaxOptions();
        internal string section;
        internal string encType;

		public FormBase(string id) 
            : base(string.Empty)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());

            this.Id(id);
			this.formMethod = System.Web.Mvc.FormMethod.Post;
			this.actionTypePassed = ActionType.HtmlRegular;
		}

		public FormBase(string id, string action)
            : base(string.Empty)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!action.IsNullOrWhiteSpace());

            this.Id(id);
			this.action = action;
            this.formMethod = System.Web.Mvc.FormMethod.Post;
			this.actionTypePassed = ActionType.HtmlRegular;
		}

		public FormBase(string id, string action, string controller)
            : base(string.Empty)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!action.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!controller.IsNullOrWhiteSpace());

            this.Id(id);
			this.action = action;
			this.controller = controller;
            this.formMethod = System.Web.Mvc.FormMethod.Post;
			this.actionTypePassed = ActionType.HtmlRegular;
		}

		public FormBase(string id, ActionResult result)
            : base(string.Empty)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(result != null, "result");

            this.Id(id);
            this.result = result;
			this.formMethod = System.Web.Mvc.FormMethod.Post;
			this.actionTypePassed = ActionType.HtmlActionResult;
		}

        public FormBase(string id, Task<ActionResult> taskResult)
            : base(string.Empty)
		{
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");

            this.Id(id);
            this.taskResult = taskResult;
            this.formMethod = System.Web.Mvc.FormMethod.Post;
			this.actionTypePassed = ActionType.HtmlTaskResult;
		}

		public TControl FormMethod(FormMethod formMethod)
		{
            Contract.Ensures(Contract.Result<TControl>() != null);

			this.formMethod = formMethod;

			return (TControl)this;
		}

        public TControl RouteValue(string key, string value)
        {
            Contract.Requires<ArgumentNullException>(!key.IsNullOrWhiteSpace(), "key");
            Contract.Requires<ArgumentNullException>(!value.IsNullOrWhiteSpace(), "value");
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.routeValues.AddOrReplace(key, value);

            return (TControl)this;
        }

		public TControl RouteValues(object routeValues)
		{
            Contract.Requires<ArgumentNullException>(routeValues != null, "routeValues");
            Contract.Ensures(Contract.Result<TControl>() != null);

			this.routeValues.MergeHtmlAttributes(routeValues.ToDictionary());

			return (TControl)this;
		}

		public TControl RouteValues(RouteValueDictionary routeValues)
		{
            Contract.Requires<ArgumentNullException>(routeValues != null, "routeValues");
            Contract.Ensures(Contract.Result<TControl>() != null);

			this.routeValues.MergeHtmlAttributes(routeValues);

			return (TControl)this;
		}

        public TControl LabelHtmlAttributes(object htmlAttributes) // TODO: add overrides for controls and labels attributes/cssclass/etc  ALSO add to form so multiple formgroups can share attrs
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.labelHtmlAttributes.MergeHtmlAttributes(htmlAttributes.ToDictionary());

            return (TControl)this;
        }

        public TControl LabelHtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            //x Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.labelHtmlAttributes.MergeHtmlAttributes(htmlAttributes);

            return (TControl)this;
        }

        public TControl ControlHtmlAttributes(object htmlAttributes) // TODO: add overrides for controls and labels attributes/cssclass/etc  ALSO add to form so multiple formgroups can share attrs
        {
            Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.controlHtmlAttributes.MergeHtmlAttributes(htmlAttributes.ToDictionary());

            return (TControl)this;
        }

        public TControl ControlHtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            //x Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.controlHtmlAttributes.MergeHtmlAttributes(htmlAttributes);

            return (TControl)this;
        }

        public TControl ControlWidthLg(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.controlWidthLg = width;

            return (TControl)this;
        }

        public TControl ControlWidthMd(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.controlWidthMd = width;

            return (TControl)this;
        }

        public TControl ControlWidthSm(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.controlWidthSm = width;

            return (TControl)this;
        }

        public TControl ControlWidthXs(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.controlWidthXs = width;

            return (TControl)this;
        }

        public TControl ControlWidth(int? widthLg, int? widthMd, int? widthSm, int? widthXs)
        {
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.controlWidthLg = widthLg;
            this.controlWidthMd = widthMd;
            this.controlWidthSm = widthSm;
            this.controlWidthXs = widthXs;

            return (TControl)this;
        }

        public TControl LabelWidthLg(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.labelWidthLg = width;
            this.formType = FormType.Horizontal;

            return (TControl)this;
        }

        public TControl LabelWidthMd(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.labelWidthMd = width;
            this.formType = FormType.Horizontal;

            return (TControl)this;
        }

        public TControl LabelWidthSm(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.labelWidthSm = width;
            this.formType = FormType.Horizontal;

            return (TControl)this;
        }

        public TControl LabelWidthXs(int? width)
        {
            Contract.Requires<ArgumentOutOfRangeException>(width == null || (width > 0 && width <= 12));
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.labelWidthXs = width;
            this.formType = FormType.Horizontal;

            return (TControl)this;
        }

        public TControl LabelWidth(int? widthLg, int? widthMd, int? widthSm, int? widthXs)
        {
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.labelWidthLg = widthLg;
            this.labelWidthMd = widthMd;
            this.labelWidthSm = widthSm;
            this.labelWidthXs = widthXs;

            return (TControl)this;
        }

        public TControl Type(FormType type)
        {
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.formType = type;

            return (TControl)this;
        }

        public TControl EncType(FormEncType encType)
        {
            Contract.Ensures(Contract.Result<TControl>() != null);

            switch (encType)
            {
                case FormEncType.FormData:
                    this.encType = "multipart/form-data";
                    break;
                case FormEncType.Plain:
                    this.encType = "text/plain";
                    break;
                default:
                    this.encType = string.Empty;
                    break;
            }

            return (TControl)this;
        }

        public TControl Section()
        {
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.section = this.id + "Section";

            return (TControl)this;
        }

        public TControl Section(string id)
        {
            Contract.Requires<ArgumentException>(!id.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TControl>() != null);

            this.section = id;

            return (TControl)this;
        }
	}
}