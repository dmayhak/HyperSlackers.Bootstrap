using HyperSlackers.Bootstrap.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;
using System.Web;
using System.Web.Mvc.Html;

namespace HyperSlackers.Bootstrap.Controls
{
    public class NavBarFormBuilder<TModel> : DisposableHtmlElement<TModel, NavBarForm>
    {
        private bool disposed = false;

        internal NavBarFormBuilder(HtmlHelper<TModel> html, NavBarForm form, bool doNotRender = false)
            : base(html, form)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(form != null, "form");

            this.doNotRender = doNotRender;
            if (!this.doNotRender)
            {
                html.ViewContext.HttpContext.Items[ContextItemKey.HS_Bootstrap_Current_Form.ToString()] = element;

                if (element.id.IsNullOrWhiteSpace())
                {
                    element.id = "mainForm"; // TODO: should we require id or no?
                }

                //if (!element.section.IsNullOrWhiteSpace())
                //{
                //    textWriter.Write("<section id=\"{0}Section\">".FormatWith(element.id));
                //}

                //if (element.formType != FormType.Default)
                //{
                //    element.htmlAttributes.AddIfNotExistsCssClass(Helpers.GetCssClass(element.formType));
                //}
                element.htmlAttributes.AddIfNotExistsCssClass("navbar-form navbar-left"); // TODO what about right?

                // TODO: what about search, etc...
                element.htmlAttributes.AddIfNotExist("role", "form"); // TODO: add role to other stuff: http://getbootstrap.com/javascript/   search for role... (aria text reader stuff...)

                if (!element.encType.IsNullOrWhiteSpace())
                {
                    element.htmlAttributes.AddIfNotExist("enctype", element.encType);
                }

                switch (element.actionTypePassed)
                {
                    case ActionType.HtmlRegular:
                        {
                            if (element.routeValues.Count == 0)
                            {
                                element.routeValues = HttpContext.Current.Request.QueryString.ToRouteValues();
                            }
                            html.BeginForm(element.action, element.controller, element.routeValues, element.formMethod, element.htmlAttributes);
                            return;
                        }
                    case ActionType.HtmlActionResult:
                        {
                            html.BeginForm(element.result, element.formMethod, element.htmlAttributes);
                            return;
                        }
                    case ActionType.HtmlTaskResult:
                        {
                            html.BeginForm(element.taskResult, element.formMethod, element.htmlAttributes);
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

            return new FormGroup<TModel>(html, element);
        }

        public FieldSetBuilder<TModel> BeginFieldSet()
        {
            Contract.Ensures(Contract.Result<FieldSetBuilder<TModel>>() != null);

            return new FieldSetBuilder<TModel>(html, new FieldSet());
        }

        public FieldSetBuilder<TModel> BeginFieldSet(string legend)
        {
            Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(legend));
            Contract.Ensures(Contract.Result<FieldSetBuilder<TModel>>() != null);

            return new FieldSetBuilder<TModel>(html, new FieldSet().Legend(legend));
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

                        if (!element.section.IsNullOrWhiteSpace())
                        {
                            textWriter.Write("</section>");
                        }

                        if (html != null)
                        {
                            html.ViewContext.HttpContext.Items[ContextItemKey.HS_Bootstrap_Current_Form.ToString()] = null;
                        }
                    }

                    disposed = true;
                }
            }

            base.Dispose(true);
        }
    }
}