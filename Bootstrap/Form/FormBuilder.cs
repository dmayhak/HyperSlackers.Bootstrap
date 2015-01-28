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
	public class FormBuilder<TModel> : DisposableHtmlElement<TModel, Form>
	{
        private bool disposed = false;

		internal FormBuilder(HtmlHelper<TModel> html, Form form, bool doNotRender = false)
            : base(html, form)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(form != null, "form");

            this.doNotRender = doNotRender;
            if (!this.doNotRender)
            {
                html.ViewContext.HttpContext.Items[ContextItemKey.HS_Bootstrap_Current_Form.ToString()] = this.element;

                if (this.element.id.IsNullOrWhiteSpace())
                {
                    this.element.id = "mainForm"; // TODO: should we require id or no?
                }

                if (!this.element.section.IsNullOrWhiteSpace())
                {
                    this.textWriter.Write("<section id=\"{0}Section\">".FormatWith(this.element.id));
                }

                if (this.element.formType != FormType.Default)
                {
                    this.element.htmlAttributes.AddClass(Helpers.GetCssClass(this.element.formType));
                }

                this.element.htmlAttributes.AddIfNotExist("role", "form"); // TODO: add role to other stuff: http://getbootstrap.com/javascript/   search for role... (aria text reader stuff...)

                if (!this.element.encType.IsNullOrWhiteSpace())
                {
                    this.element.htmlAttributes.AddIfNotExist("enctype", this.element.encType);
                }

                switch (this.element.actionTypePassed)
                {
                    case ActionType.HtmlRegular:
                        {
                            if (this.element.routeValues.Count == 0)
                            {
                                this.element.routeValues = HttpContext.Current.Request.QueryString.ToRouteValues();
                            }
                            html.BeginForm(this.element.action, this.element.controller, this.element.routeValues, this.element.formMethod, this.element.htmlAttributes);
                            return;
                        }
                    case ActionType.HtmlActionResult:
                        {
                            html.BeginForm(this.element.result, this.element.formMethod, this.element.htmlAttributes);
                            return;
                        }
                    case ActionType.HtmlTaskResult:
                        {
                            html.BeginForm(this.element.taskResult, this.element.formMethod, this.element.htmlAttributes);
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
            Contract.Ensures(Contract.Result<FormGroup<TModel>>() != null);

            return new FormGroup<TModel>(this.html, this.element);
        }

        public FieldSetBuilder<TModel> BeginFieldSet()
        {
            Contract.Ensures(Contract.Result<FieldSetBuilder<TModel>>() != null);

            return new FieldSetBuilder<TModel>(this.html, new FieldSet());
        }

        public FieldSetBuilder<TModel> BeginFieldSet(string legend)
        {
            Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(legend));
            Contract.Ensures(Contract.Result<FieldSetBuilder<TModel>>() != null);

            return new FieldSetBuilder<TModel>(this.html, new FieldSet().Legend(legend));
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

                        if (!this.element.section.IsNullOrWhiteSpace())
                        {
                            this.textWriter.Write("</section>");
                        }

                        if (this.html != null)
                        {
                            this.html.ViewContext.HttpContext.Items[ContextItemKey.HS_Bootstrap_Current_Form.ToString()] = null;
                        }
                    }

                    this.disposed = true;
                }
            }

            base.Dispose(true);
        }
	}
}