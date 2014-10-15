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
        public GlyphIcon Icon(GlyphIconType icon)
        {
            Contract.Ensures(Contract.Result<GlyphIcon>() != null);

            return new GlyphIcon(icon);
        }

        public FontAwesomeIcon Icon(FontAwesomeIconType icon)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIcon>() != null);

            return new FontAwesomeIcon(icon);
        }

        public GlyphIcon Icon(string iconCssClass)
        {
            Contract.Requires<ArgumentException>(!iconCssClass.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<GlyphIcon>() != null);

            return new GlyphIcon(iconCssClass);
        }

        public FontAwesomeIconStack IconStack(FontAwesomeIconType topIcon, FontAwesomeIconType bottomIcon, bool topIconIsLarger = false)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIconStack>() != null);

            return new FontAwesomeIconStack(topIcon, bottomIcon, topIconIsLarger);
        }

        public FontAwesomeIconStack IconStack(FontAwesomeIcon topIcon, FontAwesomeIcon bottomIcon, bool topIconIsLarger = false)
        {
            Contract.Ensures(Contract.Result<FontAwesomeIconStack>() != null);

            return new FontAwesomeIconStack(topIcon, bottomIcon, topIconIsLarger);
        }
    }
}