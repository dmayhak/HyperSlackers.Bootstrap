using HyperSlackers.Bootstrap.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HyperSlackers.Bootstrap.Demo.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Route("~/RowsAndColumns", Order = 0)]
        [Route("~/home/RowsAndColumns", Order = 1)] // when starting from IDE
        public virtual ActionResult RowsAndColumns()
        {
            return View();
        }

        [Route("~/accordions", Order = 0)]
        [Route("~/home/accordions", Order = 1)] // when starting from IDE
        public virtual ActionResult Accordions()
        {
            return View();
        }

        [Route("~/alerts", Order = 0)]
        [Route("~/home/alerts", Order = 1)] // when starting from IDE
        public virtual ActionResult Alerts()
        {
            return View();
        }

        [Route("~/buttonsandlinks", Order = 0)]
        [Route("~/home/buttonsandlinks", Order = 1)] // when starting from IDE
        public virtual ActionResult ButtonsAndLinks()
        {
            return View();
        }

        [Route("~/buttonsandlinksasync", Order = 0)]
        [Route("~/home/buttonsandlinksasync", Order = 1)] // when starting from IDE
        public virtual async Task<ActionResult> ButtonsAndLinksAsync()
        {
            // use some kind of await call here....

            return View(MVC.Home.Views.ViewNames.ButtonsAndLinks);
        }

        [Route("~/carousels", Order = 0)]
        [Route("~/home/carousels", Order = 1)] // when starting from IDE
        public virtual ActionResult Carousels()
        {
            return View();
        }

        [Route("~/checkboxes", Order = 0)]
        [Route("~/home/checkboxes", Order = 1)] // when starting from IDE
        public virtual ActionResult CheckBoxes()
        {
            var model = new CheckBoxModel();

            return View(model);
        }

        [Route("~/ckeditor", Order = 0)]
        [Route("~/home/ckeditor", Order = 1)] // when starting from IDE
        public virtual ActionResult CkEditor()
        {
            var model = new CkEditorModel();

            return View(model);
        }

        [Route("~/codeblock", Order = 0)]
        [Route("~/home/codeblock", Order = 1)] // when starting from IDE
        public virtual ActionResult CodeBlock()
        {
            return View();
        }

        [Route("~/datepicker", Order = 0)]
        [Route("~/home/datepicker", Order = 1)] // when starting from IDE
        public virtual ActionResult DatePicker()
        {
            var model = new DatePickerModel();

            return View(model);
        }

        [Route("~/display", Order = 0)]
        [Route("~/home/display", Order = 1)] // when starting from IDE
        public virtual ActionResult Display()
        {
            var model = new DisplayModel();

            return View(model);
        }

        [Route("~/dropdowns", Order = 0)]
        [Route("~/home/dropdowns", Order = 1)] // when starting from IDE
        public virtual ActionResult Dropdowns()
        {
            return View();
        }

        [Route("~/forms", Order = 0)]
        [Route("~/home/forms", Order = 1)] // when starting from IDE
        public virtual ActionResult Forms()
        {
            var model = new FormsModel();

            return View(model);
        }

        [Route("~/icons", Order = 0)]
        [Route("~/home/icons", Order = 1)] // when starting from IDE
        public virtual ActionResult Icons()
        {
            return View();
        }

        [Route("~/labels", Order = 0)]
        [Route("~/home/labels", Order = 1)] // when starting from IDE
        public virtual ActionResult Labels()
        {
            return View();
        }

        [Route("~/navs", Order = 0)]
        [Route("~/home/navs", Order = 1)] // when starting from IDE
        public virtual ActionResult Navs()
        {
            return View();
        }

        [Route("~/tables", Order = 0)]
        [Route("~/home/tables", Order = 1)] // when starting from IDE
        public virtual ActionResult Tables()
        {
            return View();
        }

        [Route("~/wells", Order = 0)]
        [Route("~/home/wells", Order = 1)] // when starting from IDE
        public virtual ActionResult Wells()
        {
            return View();
        }


    }
}