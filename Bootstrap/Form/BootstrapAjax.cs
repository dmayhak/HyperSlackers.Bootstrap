using System;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using HyperSlackers.Bootstrap;
using HyperSlackers.Bootstrap.BootstrapMethods;
using HyperSlackers.Bootstrap.Controls;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.BootstrapMethods
{
    public partial class BootstrapAjax<TModel>
    {
        public AjaxFormBuilder<TModel> BeginForm(AjaxForm form, AjaxOptions ajaxOptions)
        {
            Contract.Requires<ArgumentNullException>(form != null, "form");
            Contract.Requires<ArgumentNullException>(ajaxOptions != null, "ajaxOptions");

            form.ajaxOptions = ajaxOptions;

            return new AjaxFormBuilder<TModel>(this.ajax, form);
        }

        public AjaxFormBuilder<TModel> BeginForm(AjaxForm form)
        {
            Contract.Requires<ArgumentNullException>(form != null, "form");

            return new AjaxFormBuilder<TModel>(this.ajax, form);
        }

        public AjaxFormBuilder<TModel> BeginUpdateInPlaceForm(AjaxForm form)
        {
            Contract.Requires<ArgumentNullException>(form != null, "form");

            if (form.section.IsNullOrWhiteSpace() && form.ajaxOptions.UpdateTargetId.IsNullOrWhiteSpace())
            {
                form.renderSection = true;
                form.section = form.id + "Section";
                form.ajaxOptions.UpdateTargetId = form.section;
            }

            form.ajaxOptions.InsertionMode = InsertionMode.Replace;

            return new AjaxFormBuilder<TModel>(this.ajax, form);
        }
    }
}