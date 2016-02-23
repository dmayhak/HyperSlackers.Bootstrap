using System;
using System.ComponentModel;
using System.IO;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap;
using System.Diagnostics.Contracts;
using System.Text;
using HyperSlackers.Bootstrap.Core;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    /// <summary>
    /// Constructs a Bootstrap Carousel.
    /// </summary>
    /// <typeparam name="TModel">The model.</typeparam>
    public class CarouselBuilder<TModel> : DisposableHtmlElement<TModel, Carousel>
	{
		internal readonly UrlHelper urlHelper;
		internal bool isFirstItem = true;
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarouselBuilder{TModel}"/> class.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="carousel">The carousel.</param>
		internal CarouselBuilder(HtmlHelper<TModel> html, Carousel carousel) 
            : base(html, carousel)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Requires<ArgumentNullException>(carousel != null, "carousel");

            urlHelper = new UrlHelper(html.ViewContext.RequestContext);

            textWriter.Write(element.StartTag);

            RenderIndicators(carousel.indicators);

            textWriter.Write("<div class=\"carousel-inner\">");
		}

        /// <summary>
        /// Adds an image panel to the <see cref="Carousel"/>.
        /// </summary>
        /// <param name="imageUrl">The image URL.</param>
        /// <param name="altText">The image alt text.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public IHtmlString Image(string imageUrl, string altText, object htmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!imageUrl.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(altText != null, "altText");
            Contract.Ensures(Contract.Result<IHtmlString>() != null);

            return MvcHtmlString.Create(GetPanelHtml(imageUrl, altText, string.Empty, string.Empty, string.Empty, htmlAttributes));
        }

        /// <summary>
        /// Adds an image panel (with caption) to the <see cref="Carousel" />.
        /// </summary>
        /// <param name="imageUrl">The image URL.</param>
        /// <param name="altText">The image alt text.</param>
        /// <param name="captionHeader">The caption header.</param>
        /// <param name="captionBody">The caption body.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public IHtmlString Image(string imageUrl, string altText, string captionHeader, string captionBody, object htmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!imageUrl.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(altText != null, "altText");
            Contract.Ensures(Contract.Result<IHtmlString>() != null);

            return MvcHtmlString.Create(GetPanelHtml(imageUrl, altText, captionHeader, captionBody, string.Empty, htmlAttributes));
        }

        /// <summary>
        /// Adds an image panel (with click-able caption) to the <see cref="Carousel" />.
        /// </summary>
        /// <param name="imageUrl">The image URL.</param>
        /// <param name="altText">The image alt text.</param>
        /// <param name="captionHeader">The caption header.</param>
        /// <param name="captionBody">The caption body.</param>
        /// <param name="captionUrl">The URL to navigate to.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public IHtmlString Image(string imageUrl, string altText, string captionHeader, string captionBody, string captionUrl, object htmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!imageUrl.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(altText != null, "altText");
            Contract.Ensures(Contract.Result<IHtmlString>() != null);

            return MvcHtmlString.Create(GetPanelHtml(imageUrl, altText, captionHeader, captionBody, captionUrl, htmlAttributes));
        }

        /// <summary>
        /// Creates a panel to accept custom HTML.
        /// </summary>
        /// <returns></returns>
        public CarouselCustomItem BeginCustomPanel()
        {
            bool isFirstItem = this.isFirstItem;
            this.isFirstItem = false;

            return new CarouselCustomItem(textWriter, urlHelper, isFirstItem);
        }

        /// <summary>
        /// Creates an image panel to accept custom caption HTML.
        /// </summary>
        /// <param name="imageUrl">The image URL.</param>
        /// <param name="altText">The alt text.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public CarouselCaptionPanel BeginImagePanelWithCaption(string imageUrl, string altText, object htmlAttributes = null)
        {
            Contract.Requires<ArgumentException>(!imageUrl.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(altText != null, "imageAltText");


            textWriter.Write(GetPanelHtml(imageUrl, altText, string.Empty, string.Empty, string.Empty, htmlAttributes, true));

            return new CarouselCaptionPanel(textWriter);
        }

        /// <summary>
        /// Renders the indicators, if specified.
        /// </summary>
        /// <param name="indicators">The indicator count.</param>
        private void RenderIndicators(uint indicators)
        {
            if (indicators == 0)
            {
                return;
            }

            textWriter.Write("<ol class=\"carousel-indicators\">");

            for (int i = 0; i < indicators; i++)
            {
                textWriter.Write("<li data-target=\"#{0}\" data-slide-to=\"{1}\"".FormatWith(element.id, i));
                if (i == 0)
                {
                    textWriter.Write(" class=\"active\"");
                }
                textWriter.Write("></li> ");
            }

            textWriter.Write("</ol>");
        }

        /// <summary>
        /// Generates th HTML markup for the panel.
        /// </summary>
        /// <param name="imageUrl">The image URL.</param>
        /// <param name="altText">The alt text.</param>
        /// <param name="captionHeader">The caption header.</param>
        /// <param name="captionBody">The caption body.</param>
        /// <param name="captionUrl">The caption URL.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="isDisposable">if set to <c>true</c> [is disposable].</param>
        /// <returns></returns>
        private string GetPanelHtml(string imageUrl, string altText, string captionHeader, string captionBody, string captionUrl, object htmlAttributes, bool isDisposable = false)
        {
            Contract.Requires<ArgumentException>(!imageUrl.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(altText != null, "altText");
            //x Contract.Requires<ArgumentNullException>(captionHeader != null, "captionHeader");
            //x Contract.Requires<ArgumentNullException>(captionBody != null, "captionBody");
            //x Contract.Requires<ArgumentNullException>(captionUrl != null, "captionUrl");
            //x Contract.Requires<ArgumentNullException>(htmlAttributes != null, "htmlAttributes");
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            TagBuilder divTagBuilder = new TagBuilder("div");
            divTagBuilder.AddCssClass("item");
            if (isFirstItem)
            {
                divTagBuilder.AddCssClass("active");
                isFirstItem = false;
            }

            string imageHtml = GetImageHtml(imageUrl, altText, htmlAttributes);
            string captionHtml = GetCaptionHtml(captionHeader, captionBody, captionUrl);

            string htmlWithoutEndTag;
            if (!captionUrl.IsNullOrWhiteSpace())
            {
                htmlWithoutEndTag = divTagBuilder.ToString(TagRenderMode.StartTag) + "<a href=\"" + captionUrl + "\">" + imageHtml + captionHtml + "</a>";
            }
            else
            {
                htmlWithoutEndTag = divTagBuilder.ToString(TagRenderMode.StartTag) + imageHtml + captionHtml;
            }

            return htmlWithoutEndTag + (isDisposable ? string.Empty : divTagBuilder.ToString(TagRenderMode.EndTag));
        }

        /// <summary>
        /// Gets the HTML tag for the panel image.
        /// </summary>
        /// <param name="imageUrl">The image URL.</param>
        /// <param name="altText">The alt text.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        private string GetImageHtml(string imageUrl, string altText, object htmlAttributes)
        {
            Contract.Requires<ArgumentException>(!imageUrl.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentNullException>(altText != null, "altText");
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            TagBuilder tagBuilder = new TagBuilder("img");
            tagBuilder.MergeHtmlAttributes(htmlAttributes.ToDictionary().FormatHtmlAttributes());
            tagBuilder.MergeAttribute("src", urlHelper.Content(imageUrl));
            tagBuilder.MergeAttribute("alt", altText);

            return tagBuilder.ToString(TagRenderMode.SelfClosing);
        }

        /// <summary>
        /// Gets the caption HTML.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <param name="body">The body.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        private string GetCaptionHtml(string header, string body, string url)
        {
            Contract.Ensures(!Contract.Result<string>().IsNullOrWhiteSpace());

            StringBuilder html = new StringBuilder();

            string headerHtml = header.IsNullOrWhiteSpace() ? string.Empty : "<h3>" + header + "</h3>";
            string bodyHtml = body.IsNullOrWhiteSpace() ? string.Empty : "<p>" + body + "</p>";

            string captionHtml = headerHtml + bodyHtml;

            if (!url.IsNullOrWhiteSpace())
            {
                captionHtml = "<a href=\"" + url + "\">" + captionHtml + "</a>";
            }

            return "<div class=\"carousel-caption\">" + captionHtml + "</div>";
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// REnders any closing HTML necessary.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
		{
            if (!disposed)
            {
                if (disposing)
                {
                    textWriter.Write("</div>");
                    textWriter.Write("<a class=\"left carousel-control\" data-slide=\"prev\" href=\"#{0}\">{1}</a>".FormatWith(element.id, element.prevIcon.ToString()));
                    textWriter.Write("<a class=\"right carousel-control\" data-slide=\"next\" href=\"#{0}\">{1}</a>".FormatWith(element.id, element.nextIcon.ToString()));
                    textWriter.Write(element.EndTag);

                    if (element.withJs)
                    {
                        textWriter.Write("<script type=\"text/javascript\">\r\n    $(document).ready(function(){{\r\n        $('#{0}').carousel({{\r\n            interval: {1}\r\n        }})\r\n    }});\r\n</script>".FormatWith(element.id, element.interval));
                    }

                    disposed = true;
                }
            }

            // closing tag handled above, do not call base class
            //x base.Dispose(disposing);
		}
	}
}