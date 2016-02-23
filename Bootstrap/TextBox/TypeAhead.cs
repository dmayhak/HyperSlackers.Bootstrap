using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Diagnostics.Contracts;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap
{
	public class TypeAhead
	{
		internal ActionResult result;
		internal Task<ActionResult> taskResult;
		internal string actionName;
		internal string controllerName;
		internal string source;
		internal int? items;
		internal int? minLength;
		internal string matcher;
		internal string sorter;
		internal string updater;
		internal string highlighter;

		public TypeAhead()
		{
		}

		public TypeAhead Action(string action)
		{
            Contract.Requires<ArgumentException>(!action.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TypeAhead>() != null);

            actionName = action;

            return this;
		}

		public TypeAhead ActionResult(ActionResult result)
		{
            Contract.Requires<ArgumentNullException>(result != null, "result");
            Contract.Ensures(Contract.Result<TypeAhead>() != null);

			this.result = result;
			
            return this;
		}

		public TypeAhead Controller(string controller)
		{
            Contract.Requires<ArgumentException>(!controller.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TypeAhead>() != null);

            controllerName = controller;
			
            return this;
		}

		public TypeAhead Highlighter(string highlighter)
		{
            Contract.Requires<ArgumentException>(!highlighter.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TypeAhead>() != null);

			this.highlighter = highlighter;
			
            return this;
		}

		public TypeAhead Items(int items)
		{
            Contract.Requires<ArgumentOutOfRangeException>(items >= 0);
            Contract.Ensures(Contract.Result<TypeAhead>() != null);

			this.items = new int?(items);
			
            return this;
		}

		public TypeAhead Matcher(string matcher)
		{
            Contract.Requires<ArgumentException>(!matcher.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TypeAhead>() != null);

			this.matcher = matcher;
			
            return this;
		}

		public TypeAhead MinLength(int minLength)
		{
            Contract.Requires<ArgumentOutOfRangeException>(minLength > 0);
            Contract.Ensures(Contract.Result<TypeAhead>() != null);

			this.minLength = new int?(minLength);
			
            return this;
		}

		public TypeAhead Sorter(string sorter)
		{
            Contract.Requires<ArgumentException>(!sorter.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TypeAhead>() != null);

			this.sorter = sorter;

            return this;
		}

		public TypeAhead Source(string source)
		{
            Contract.Requires<ArgumentException>(!source.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TypeAhead>() != null);

			this.source = source;
			
            return this;
		}

		public TypeAhead TaskResult(Task<ActionResult> taskResult)
		{
            Contract.Requires<ArgumentNullException>(taskResult != null, "taskResult");
            Contract.Ensures(Contract.Result<TypeAhead>() != null);

			this.taskResult = taskResult;
			
            return this;
		}

        public TypeAhead Updater(string updater)
        {
            Contract.Requires<ArgumentException>(!updater.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<TypeAhead>() != null);

            this.updater = updater;
            
            return this;
        }

        internal virtual IDictionary<string, object> ToDictionary(HtmlHelper html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");
            Contract.Ensures(Contract.Result<IDictionary<string, object>>() != null);

			UrlHelper urlHelper = new UrlHelper(html.ViewContext.RequestContext);
			Dictionary<string, object> attributes = new Dictionary<string, object>();

			attributes.AddIfNotExist("data-provide", "typeahead");
			attributes.AddIfNotExist("autocomplete", "off");

			if (result != null)
			{
				attributes.AddIfNotExist("data-url", urlHelper.Action(result));
			}

			if (taskResult != null)
			{
				attributes.AddIfNotExist("data-url", urlHelper.Action(taskResult));
			}

            if (!actionName.IsNullOrWhiteSpace() || !controllerName.IsNullOrWhiteSpace())
			{
				attributes.AddIfNotExist("data-url", urlHelper.Action(actionName, controllerName));
			}
			
            if (items.HasValue)
			{
				int value = items.Value;
				attributes.AddIfNotExist("data-items", value.ToString());
			}
			
            if (minLength.HasValue)
			{
				int num = minLength.Value;
				attributes.AddIfNotExist("data-minLength", num.ToString());
			}

            if (!source.IsNullOrWhiteSpace())
			{
				attributes.AddIfNotExist("data-source", source);
			}

            if (!matcher.IsNullOrWhiteSpace())
			{
				attributes.AddIfNotExist("data-matcher", matcher);
			}

            if (!sorter.IsNullOrWhiteSpace())
			{
				attributes.AddIfNotExist("data-sorter", sorter);
			}

            if (!updater.IsNullOrWhiteSpace())
			{
				attributes.AddIfNotExist("data-updater", updater);
			}

            if (!highlighter.IsNullOrWhiteSpace())
			{
				attributes.AddIfNotExist("data-highlighter", highlighter);
			}
			
            return attributes;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Type GetType()
		{
			return base.GetType();
		}
	}
}