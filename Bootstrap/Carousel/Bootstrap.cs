using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HyperSlackers.Bootstrap;
using HyperSlackers.Bootstrap.Controls;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.BootstrapMethods
{
    public partial class Bootstrap<TModel> 
    {
        /// <summary>
        /// Creates a Bootstrap Carousel (slideshow).
        /// </summary>
        /// <param name="carousel">The <see cref="Carousel"/>.</param>
        /// <returns>A new <see cref="CarouselBuilder"/>.</returns>
        public CarouselBuilder<TModel> BeginCarousel(Carousel carousel)
        {
            Contract.Requires<ArgumentNullException>(carousel != null, "carousel");
            Contract.Ensures(Contract.Result<CarouselBuilder<TModel>>() != null);

            return new CarouselBuilder<TModel>(html, carousel);
        }
    }
}