using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HyperSlackers.Bootstrap.Extensions
{
    internal static class ModelMetadataExtensions
    {
        public static IEnumerable<SelectListItem> SelectListItemsFromEnumMetadata(this ModelMetadata metadata)
        {
            Contract.Requires<ArgumentNullException>(metadata != null, "metadata");
            Contract.Ensures(Contract.Result<IEnumerable<SelectListItem>>() != null);

            Type modelType = metadata.ModelType;

            if (modelType.IsNullableEnum() || modelType.IsGenericEnumerable())
            {
                modelType = modelType.GetGenericArguments().First<Type>();
            }

            if (modelType.IsArray)
            {
                modelType = modelType.GetElementType();
            }

            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (Enum @enum in Enum.GetValues(modelType).OfType<Enum>())
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Value = Enum.Parse(modelType, @enum.ToString()).ToString();
                selectListItem.Text = @enum.GetEnumDescription();
                selectListItem.Selected = @enum.Equals(metadata.Model);
                selectListItems.Add(selectListItem);
            }

            return selectListItems;
        }
    }
}
