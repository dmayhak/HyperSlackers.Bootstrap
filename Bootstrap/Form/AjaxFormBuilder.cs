using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using HyperSlackers.Bootstrap;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.BootstrapMethods;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
	public class AjaxFormBuilder<TModel> : DisposableHtmlElement<TModel, AjaxForm>
	{
        private bool disposed = false;

        internal AjaxFormBuilder(AjaxHelper<TModel> ajax, AjaxForm form, bool doNotRender = false) 
            : base(ajax, form)
		{
            Contract.Requires<ArgumentNullException>(ajax != null, "ajax");
            Contract.Requires<ArgumentNullException>(form != null, "form");

            //this.element.AjaxOnComplete("BindModalElements();" + this.element.ajaxOptions.OnComplete ?? string.Empty);

            this.doNotRender = doNotRender;
            if (!this.doNotRender)
            {
                ajax.ViewContext.HttpContext.Items[ContextItemKey.HS_Bootstrap_Current_Form.ToString()] = element;

                if (element.renderSection && (ajax.ViewContext.RequestContext.HttpContext.Request.RequestType.ToLowerInvariant() != "post"))
                {
                    textWriter.Write("<section id=\"{0}\">".FormatWith(element.section));
                }

                if (element.formType != FormType.Default)
                {
                    element.htmlAttributes.AddIfNotExistsCssClass(Helpers.GetCssClass(element.formType));
                }

                switch (element.actionTypePassed)
                {
                    case ActionType.HtmlRegular:
                        {
                            if (element.routeValues.Count == 0)
                            {
                                element.routeValues = HttpContext.Current.Request.QueryString.ToRouteValues();
                            }
                            ajax.BeginForm(element.action, element.controller, element.routeValues, element.ajaxOptions, element.htmlAttributes);
                            return;
                        }
                    case ActionType.HtmlActionResult:
                        {
                            ajax.BeginForm(element.result, element.ajaxOptions, element.htmlAttributes);
                            return;
                        }
                    case ActionType.HtmlTaskResult:
                        {
                            ajax.BeginForm(element.taskResult, element.ajaxOptions, element.htmlAttributes);
                            break;
                        }
                    default:
                        {
                            return;
                        }
                }
            }
		}

        public FormGroup<TModel> FormGroup()
        {
            return new FormGroup<TModel>(ajax, element);
        }

        public FieldSetBuilder<TModel> BeginFieldSet()
        {
            Contract.Ensures(Contract.Result<FieldSetBuilder<TModel>>() != null);

            return new FieldSetBuilder<TModel>(ajax, new FieldSet());
        }

        public FieldSetBuilder<TModel> BeginFieldSet(string legend)
        {
            Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(legend));
            Contract.Ensures(Contract.Result<FieldSetBuilder<TModel>>() != null);

            return new FieldSetBuilder<TModel>(ajax, new FieldSet().Legend(legend));
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (!doNotRender)
                    {
                        textWriter.Write("</form>");

                        if (element.renderSection && (ajax.ViewContext.RequestContext.HttpContext.Request.RequestType.ToLowerInvariant() != "post"))
                        {
                            // don't re-render section tag on postback, it's still there
                            textWriter.Write("</section>");
                        }

                        if (ajax != null)
                        {
                            ajax.ViewContext.HttpContext.Items[ContextItemKey.HS_Bootstrap_Current_Form.ToString()] = null;
                        }
                    }

                    disposed = true;
                }
            }

            base.Dispose(true);
        }
	}
}