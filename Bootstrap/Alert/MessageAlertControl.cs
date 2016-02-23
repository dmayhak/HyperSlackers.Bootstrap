using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Core;
using System.Text;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class MessageAlertControl<TModel> : ControlBase<AlertControl<TModel>, TModel>
    {
        internal AlertStyle alertStyle = AlertStyle.Success;

        internal MessageAlertControl(HtmlHelper<TModel> html)
            : base(html)
        {
            Contract.Requires<ArgumentNullException>(html != null, "html");

            controlHtmlAttributes.AddIfNotExistsCssClass("alert");
        }

        public MessageAlertControl<TModel> Style(AlertStyle style)
        {
            Contract.Ensures(Contract.Result<MessageAlertControl<TModel>>() != null);

            alertStyle = style;

            return this;
        }

        public MessageAlertControl<TModel> IsLongMessage()
        {
            Contract.Ensures(Contract.Result<MessageAlertControl<TModel>>() != null);

            controlHtmlAttributes.AddIfNotExistsCssClass("alert-block");

            return this;
        }

        protected override string Render()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            StringBuilder alertHtml = new StringBuilder();

            alertHtml.Append(RenderMessage());
            alertHtml.Append(RenderDangerMessage());
            alertHtml.Append(RenderWarningMessage());
            alertHtml.Append(RenderInfoMessage());
            alertHtml.Append(RenderSuccessMessage());

            return alertHtml.ToString();
        }

        private string RenderMessage()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            string alertHtml = html.ViewBag.Message;

            if (html.ViewContext.TempData.ContainsKey("Message"))
            {
                alertHtml = html.ViewContext.TempData["Message"].ToString();
            }

            return RenderAlert(alertHtml, alertStyle);
        }

        private string RenderSuccessMessage()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            string alertHtml = html.ViewBag.Message_Success;

            if (html.ViewContext.TempData.ContainsKey("Message_Success"))
            {
                alertHtml = html.ViewContext.TempData["Message_Success"].ToString();
            }

            return RenderAlert(alertHtml, AlertStyle.Success);
        }

        private string RenderInfoMessage()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            string alertHtml = html.ViewBag.Message_Info;

            if (html.ViewContext.TempData.ContainsKey("Message_Info"))
            {
                alertHtml = html.ViewContext.TempData["Message_Info"].ToString();
            }

            return RenderAlert(alertHtml, AlertStyle.Info);
        }

        private string RenderWarningMessage()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            string alertHtml = html.ViewBag.Message_Warning;

            if (html.ViewContext.TempData.ContainsKey("Message_Warning"))
            {
                alertHtml = html.ViewContext.TempData["Message_Warning"].ToString();
            }

            return RenderAlert(alertHtml, AlertStyle.Warning);
        }
        
        private string RenderDangerMessage()
        {
            Contract.Ensures(Contract.Result<string>() != null);

            string alertHtml = html.ViewBag.Message_Danger;

            if (html.ViewContext.TempData.ContainsKey("Message_Danger"))
            {
                alertHtml = html.ViewContext.TempData["Message_Danger"].ToString();
            }

            return RenderAlert(alertHtml, AlertStyle.Danger);
        }

        private string RenderAlert(string alertHtml, AlertStyle style)
        {
            Contract.Ensures(Contract.Result<string>() != null);

            if (alertHtml.IsNullOrWhiteSpace())
            {
                return string.Empty;
            }

            IDictionary<string, object> attributes = controlHtmlAttributes.FormatHtmlAttributes();

            attributes.AddIfNotExistsCssClass(Helpers.GetCssClass(style));

            TagBuilder tagBuilder = new TagBuilder("div");

            tagBuilder.MergeHtmlAttributes(attributes);

            tagBuilder.InnerHtml = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>" + alertHtml;

            return tagBuilder.ToString(TagRenderMode.Normal);
        }
    }
}