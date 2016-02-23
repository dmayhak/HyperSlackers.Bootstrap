using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Web.Mvc;
using HyperSlackers.Bootstrap.Extensions;

namespace HyperSlackers.Bootstrap.Controls
{
	public class Defaults
	{
        readonly internal HtmlHelper html;
        private const string showRequiredStar = "HyperSlackers.Defaults.ShowRequiredStar";
        private const string showPlaceholder = "HyperSlackers.Defaults.AlwaysIncludePlaceholder";
        private const string showTooltip = "HyperSlackers.Defaults.ShowTooltip";
        private const string showHelpText = "HyperSlackers.Defaults.ShowHelpText";
        private const string buttonStyle = "HyperSlackers.Defaults.ButtonStyle";
        private const string inputSize = "HyperSlackers.Defaults.InputSize";
        private const string showValidationMessageBeforeInput = "HyperSlackers.Defaults.SetValidationMessageBeforeInput";
        private const string showValidationMessageInline = "HyperSlackers.Defaults.SetValidationMessageInline";

        public Defaults(HtmlHelper html)
		{
            Contract.Requires<ArgumentNullException>(html != null, "html");

			this.html = html;
		}

        public Defaults ShowRequiredStar(bool? show)
		{
            Contract.Ensures(Contract.Result<Defaults>() != null);

            html.ViewData[showRequiredStar] = show;

            return this;
		}

        internal bool? DefaultShowRequiredStar
        {
            get
            {
                if (html.ViewData[showRequiredStar] == null)
                {
                    return null;
                }

                return (bool?)html.ViewData[showRequiredStar];
            }
        }

        public Defaults ShowTooltip(bool show)
        {
            Contract.Ensures(Contract.Result<Defaults>() != null);

            html.ViewData[showTooltip] = show;

            return this;
        }

        internal bool DefaultShowTooltip
        {
            get
            {
                if (html.ViewData[showTooltip] == null)
                {
                    return true;
                }

                return (bool)html.ViewData[showTooltip];
            }
        }

        public Defaults ShowPlaceholder(bool? show)
		{
            Contract.Ensures(Contract.Result<Defaults>() != null);

            html.ViewData[showPlaceholder] = show;

            return this;
		}

        internal bool? DefaultShowPlaceholder
        {
            get
            {
                if (html.ViewData[showPlaceholder] == null)
                {
                    return null;
                }

                return (bool?)html.ViewData[showPlaceholder];
            }
        }

        public Defaults ShowHelpText(bool show)
        {
            Contract.Ensures(Contract.Result<Defaults>() != null);

            html.ViewData[showHelpText] = show;

            return this;
        }

        internal bool DefaultShowHelpText
        {
            get
            {
                if (html.ViewData[showHelpText] == null)
                {
                    return true;
                }

                return (bool)html.ViewData[showHelpText];
            }
        }

        public Defaults ButtonStyle(ButtonStyle style)
        {
            Contract.Ensures(Contract.Result<Defaults>() != null);

            html.ViewData[buttonStyle] = style;

            return this;
        }

        internal ButtonStyle DefaultButtonStyle
        {
            get
            {
                if (html.ViewData[buttonStyle] == null)
                {
                    return Bootstrap.ButtonStyle.Default;
                }

                return (ButtonStyle)html.ViewData[buttonStyle];
            }
        }

        public Defaults InputSize(InputSize size)
        {
            Contract.Ensures(Contract.Result<Defaults>() != null);

            html.ViewData[inputSize] = size;

            return this;
        }

        internal InputSize DefaultInputSize
        {
            get
            {
                if (html.ViewData[inputSize] == null)
                {
                    return Bootstrap.InputSize.Default;
                }

                return (InputSize)html.ViewData[inputSize];
            }
        }

        public Defaults ShowValidationMessageBeforeInput(bool? validationBeforeInput = true)
		{
            Contract.Ensures(Contract.Result<Defaults>() != null);

            html.ViewData[showValidationMessageBeforeInput] = validationBeforeInput;

            return this;
		}

        internal bool? DefaultShowValidationMessageBeforeInput
        {
            get
            {
                if (html.ViewData[showValidationMessageBeforeInput] == null)
                {
                    return null;
                }

                return (bool?)html.ViewData[showValidationMessageBeforeInput];
            }
        }

        public Defaults ShowValidationMessageInline(bool? validationInline = true)
		{
            Contract.Ensures(Contract.Result<Defaults>() != null);

            html.ViewData[showValidationMessageInline] = validationInline;

            return this;
		}

        internal bool? DefaultShowValidationMessageInline
        {
            get
            {
                if (html.ViewData[showValidationMessageInline] == null)
                {
                    return null;
                }

                return (bool?)html.ViewData[showValidationMessageInline];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return ToString();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			return Equals(obj);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Type GetType()
		{
			return GetType();
		}
	}
}