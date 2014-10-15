// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
#pragma warning disable 1591, 3008, 3009
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace HyperSlackers.Bootstrap.Demo.Controllers
{
    public partial class HomeController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public HomeController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected HomeController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }


        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public HomeController Actions { get { return MVC.Home; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Home";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Home";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string About = "About";
            public readonly string Contact = "Contact";
            public readonly string Accordions = "Accordions";
            public readonly string Alerts = "Alerts";
            public readonly string ButtonsAndLinks = "ButtonsAndLinks";
            public readonly string ButtonsAndLinksAsync = "ButtonsAndLinksAsync";
            public readonly string Carousels = "Carousels";
            public readonly string CheckBoxes = "CheckBoxes";
            public readonly string CkEditor = "CkEditor";
            public readonly string CodeBlock = "CodeBlock";
            public readonly string DatePicker = "DatePicker";
            public readonly string Display = "Display";
            public readonly string Tables = "Tables";
            public readonly string Wells = "Wells";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string About = "About";
            public const string Contact = "Contact";
            public const string Accordions = "Accordions";
            public const string Alerts = "Alerts";
            public const string ButtonsAndLinks = "ButtonsAndLinks";
            public const string ButtonsAndLinksAsync = "ButtonsAndLinksAsync";
            public const string Carousels = "Carousels";
            public const string CheckBoxes = "CheckBoxes";
            public const string CkEditor = "CkEditor";
            public const string CodeBlock = "CodeBlock";
            public const string DatePicker = "DatePicker";
            public const string Display = "Display";
            public const string Tables = "Tables";
            public const string Wells = "Wells";
        }


        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string About = "About";
                public readonly string Accordions = "Accordions";
                public readonly string Alerts = "Alerts";
                public readonly string ButtonsAndLinks = "ButtonsAndLinks";
                public readonly string Carousels = "Carousels";
                public readonly string CheckBoxes = "CheckBoxes";
                public readonly string CkEditor = "CkEditor";
                public readonly string CodeBlock = "CodeBlock";
                public readonly string Contact = "Contact";
                public readonly string DatePicker = "DatePicker";
                public readonly string Display = "Display";
                public readonly string Index = "Index";
                public readonly string Tables = "Tables";
                public readonly string Wells = "Wells";
            }
            public readonly string About = "~/Views/Home/About.cshtml";
            public readonly string Accordions = "~/Views/Home/Accordions.cshtml";
            public readonly string Alerts = "~/Views/Home/Alerts.cshtml";
            public readonly string ButtonsAndLinks = "~/Views/Home/ButtonsAndLinks.cshtml";
            public readonly string Carousels = "~/Views/Home/Carousels.cshtml";
            public readonly string CheckBoxes = "~/Views/Home/CheckBoxes.cshtml";
            public readonly string CkEditor = "~/Views/Home/CkEditor.cshtml";
            public readonly string CodeBlock = "~/Views/Home/CodeBlock.cshtml";
            public readonly string Contact = "~/Views/Home/Contact.cshtml";
            public readonly string DatePicker = "~/Views/Home/DatePicker.cshtml";
            public readonly string Display = "~/Views/Home/Display.cshtml";
            public readonly string Index = "~/Views/Home/Index.cshtml";
            public readonly string Tables = "~/Views/Home/Tables.cshtml";
            public readonly string Wells = "~/Views/Home/Wells.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_HomeController : HyperSlackers.Bootstrap.Demo.Controllers.HomeController
    {
        public T4MVC_HomeController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void AboutOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult About()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.About);
            AboutOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ContactOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Contact()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Contact);
            ContactOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void AccordionsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Accordions()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Accordions);
            AccordionsOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void AlertsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Alerts()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Alerts);
            AlertsOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ButtonsAndLinksOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ButtonsAndLinks()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ButtonsAndLinks);
            ButtonsAndLinksOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ButtonsAndLinksAsyncOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ButtonsAndLinksAsync()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ButtonsAndLinksAsync);
            ButtonsAndLinksAsyncOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as ActionResult);
        }

        [NonAction]
        partial void CarouselsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Carousels()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Carousels);
            CarouselsOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CheckBoxesOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult CheckBoxes()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CheckBoxes);
            CheckBoxesOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CkEditorOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult CkEditor()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CkEditor);
            CkEditorOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CodeBlockOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult CodeBlock()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CodeBlock);
            CodeBlockOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void DatePickerOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult DatePicker()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DatePicker);
            DatePickerOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void DisplayOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Display()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Display);
            DisplayOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void TablesOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Tables()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Tables);
            TablesOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void WellsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Wells()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Wells);
            WellsOverride(callInfo);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009
