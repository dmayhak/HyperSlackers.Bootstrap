using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
    public class DropDownMenuBuilder<TModel> : IList<DropDownMenuItemControl<TModel>>, ICollection<DropDownMenuItemControl<TModel>>, IEnumerable<DropDownMenuItemControl<TModel>>, IEnumerable
	{
        internal readonly HtmlHelper<TModel> html;
        internal readonly List<DropDownMenuItemControl<TModel>> menuItems = new List<DropDownMenuItemControl<TModel>>();

        internal DropDownMenuBuilder(HtmlHelper<TModel> html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");

            this.html = html;
		}

		public int Count
		{
			get
			{
                Contract.Ensures(Contract.Result<int>() >= 0);

                return menuItems.Count<DropDownMenuItemControl<TModel>>();
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

        public DropDownMenuItemControl<TModel> this[int index]
		{
			get
			{
                Contract.Ensures(Contract.Result<DropDownMenuItemControl<TModel>>() != null);

				return menuItems[index];
			}
			set
			{
                menuItems[index] = value;
			}
		}

        public void Add(DropDownMenuItemControl<TModel> item)
		{
            menuItems.Add(item);
		}

		public void Clear()
		{
            menuItems.Clear();
		}

        public bool Contains(DropDownMenuItemControl<TModel> item)
		{
            return menuItems.Contains(item);
		}

        public void CopyTo(DropDownMenuItemControl<TModel>[] array, int arrayIndex)
		{
            menuItems.CopyTo(array, arrayIndex);
		}

        public DropDownMenuItemControl<TModel> Divider()
		{
            Contract.Ensures(Contract.Result<DropDownMenuItemControl<TModel>>() != null);

            DropDownMenuItemControl<TModel> bootstrapDropDownMenuItem = new DropDownMenuItemControl<TModel>(html, true);
            Add(bootstrapDropDownMenuItem);
			
            return bootstrapDropDownMenuItem;
		}

        public IEnumerator<DropDownMenuItemControl<TModel>> GetEnumerator()
		{
            Contract.Ensures(Contract.Result<IEnumerator<DropDownMenuItemControl<TModel>>>() != null);

			return menuItems.GetEnumerator();
		}

        public int IndexOf(DropDownMenuItemControl<TModel> item)
		{
            Contract.Ensures(Contract.Result<int>() >= 0);  // TODO: can this be -1 or???

			return menuItems.IndexOf(item);
		}

        public void Insert(int index, DropDownMenuItemControl<TModel> item)
		{
            menuItems.Insert(index, item);
		}

        public DropDownMenuItemControl<TModel> MenuItem(MvcHtmlString actionLink)
		{
            Contract.Requires<ArgumentNullException>(actionLink != null, "actionLink");
            Contract.Ensures(Contract.Result<DropDownMenuItemControl<TModel>>() != null);

            DropDownMenuItemControl<TModel> bootstrapDropDownMenuItem = new DropDownMenuItemControl<TModel>(html, actionLink);
            Add(bootstrapDropDownMenuItem);
			
            return bootstrapDropDownMenuItem;
		}

        public DropDownMenuItemControl<TModel> MenuItem(string link)
		{
            Contract.Requires<ArgumentException>(!link.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<DropDownMenuItemControl<TModel>>() != null);

            DropDownMenuItemControl<TModel> bootstrapDropDownMenuItem = new DropDownMenuItemControl<TModel>(html, link);
            Add(bootstrapDropDownMenuItem);
			
            return bootstrapDropDownMenuItem;
		}

        public bool Remove(DropDownMenuItemControl<TModel> item)
		{
            return menuItems.Remove(item);
		}

		public void RemoveAt(int index)
		{
            menuItems.RemoveAt(index);
		}

		IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
            Contract.Ensures(Contract.Result<IEnumerator>() != null);

			return GetEnumerator();
		}
	}
}