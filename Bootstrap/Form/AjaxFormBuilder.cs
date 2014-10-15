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
                ajax.ViewContext.HttpContext.Items[ContextItemKey.HS_Bootstrap_Current_Form.ToString()] = this.element;

                if (this.element.renderSection && (ajax.ViewContext.RequestContext.HttpContext.Request.RequestType.ToLowerInvariant() != "post"))
                {
                    this.textWriter.Write("<section id=\"{0}\">".FormatWith(this.element.section));
                }

                if (this.element.formType != FormType.Default)
                {
                    this.element.htmlAttributes.AddClass(Helpers.GetCssClass(this.element.formType));
                }

                switch (this.element.actionTypePassed)
                {
                    case ActionType.HtmlRegular:
                        {
                            if (this.element.routeValues.Count == 0)
                            {
                                this.element.routeValues = HttpContext.Current.Request.QueryString.ToRouteValues();
                            }
                            ajax.BeginForm(this.element.action, this.element.controller, this.element.routeValues, this.element.ajaxOptions, this.element.htmlAttributes);
                            return;
                        }
                    case ActionType.HtmlActionResult:
                        {
                            ajax.BeginForm(this.element.result, this.element.ajaxOptions, this.element.htmlAttributes);
                            return;
                        }
                    case ActionType.HtmlTaskResult:
                        {
                            ajax.BeginForm(this.element.taskResult, this.element.ajaxOptions, this.element.htmlAttributes);
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
            return new FormGroup<TModel>(this.ajax, this.element);
        }

        public FieldSetBuilder<TModel> BeginFieldSet()
        {
            Contract.Ensures(Contract.Result<FieldSetBuilder<TModel>>() != null);

            return new FieldSetBuilder<TModel>(this.ajax, new FieldSet());
        }

        public FieldSetBuilder<TModel> BeginFieldSet(string legend)
        {
            Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(legend));
            Contract.Ensures(Contract.Result<FieldSetBuilder<TModel>>() != null);

            return new FieldSetBuilder<TModel>(this.ajax, new FieldSet().Legend(legend));
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (!this.doNotRender)
                    {
                        this.textWriter.Write("</form>");

                        if (this.element.renderSection && (ajax.ViewContext.RequestContext.HttpContext.Request.RequestType.ToLowerInvariant() != "post"))
                        {
                            // don't re-render section tag on postback, it's still there
                            this.textWriter.Write("</section>");
                        }

                        if (this.ajax != null)
                        {
                            this.ajax.ViewContext.HttpContext.Items[ContextItemKey.HS_Bootstrap_Current_Form.ToString()] = null;
                        }
                    }

                    this.disposed = true;
                }
            }

            base.Dispose(true);
        }
	}
}