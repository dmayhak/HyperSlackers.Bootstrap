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

            this.html.ViewData[showRequiredStar] = show;

            return this;
		}

        internal bool? DefaultShowRequiredStar
        {
            get
            {
                if (this.html.ViewData[showRequiredStar] == null)
                {
                    return null;
                }

                return (bool?)this.html.ViewData[showRequiredStar];
            }
        }

        public Defaults ShowTooltip(bool show)
        {
            Contract.Ensures(Contract.Result<Defaults>() != null);

            this.html.ViewData[showTooltip] = show;

            return this;
        }

        internal bool DefaultShowTooltip
        {
            get
            {
                if (this.html.ViewData[showTooltip] == null)
                {
                    return true;
                }

                return (bool)this.html.ViewData[showTooltip];
            }
        }

        public Defaults ShowPlaceholder(bool? show)
		{
            Contract.Ensures(Contract.Result<Defaults>() != null);

            this.html.ViewData[showPlaceholder] = show;

            return this;
		}

        internal bool? DefaultShowPlaceholder
        {
            get
            {
                if (this.html.ViewData[showPlaceholder] == null)
                {
                    return null;
                }

                return (bool?)this.html.ViewData[showPlaceholder];
            }
        }

        public Defaults ShowHelpText(bool show)
        {
            Contract.Ensures(Contract.Result<Defaults>() != null);

            this.html.ViewData[showHelpText] = show;

            return this;
        }

        internal bool DefaultShowHelpText
        {
            get
            {
                if (this.html.ViewData[showHelpText] == null)
                {
                    return true;
                }

                return (bool)this.html.ViewData[showHelpText];
            }
        }

        public Defaults ButtonStyle(ButtonStyle style)
        {
            Contract.Ensures(Contract.Result<Defaults>() != null);

            this.html.ViewData[buttonStyle] = style;

            return this;
        }

        internal ButtonStyle DefaultButtonStyle
        {
            get
            {
                if (this.html.ViewData[buttonStyle] == null)
                {
                    return Bootstrap.ButtonStyle.Default;
                }

                return (ButtonStyle)this.html.ViewData[buttonStyle];
            }
        }

        public Defaults InputSize(InputSize size)
        {
            Contract.Ensures(Contract.Result<Defaults>() != null);

            this.html.ViewData[inputSize] = size;

            return this;
        }

        internal InputSize DefaultInputSize
        {
            get
            {
                if (this.html.ViewData[inputSize] == null)
                {
                    return Bootstrap.InputSize.Default;
                }

                return (InputSize)this.html.ViewData[inputSize];
            }
        }

        public Defaults ShowValidationMessageBeforeInput(bool? validationBeforeInput = true)
		{
            Contract.Ensures(Contract.Result<Defaults>() != null);

            this.html.ViewData[showValidationMessageBeforeInput] = validationBeforeInput;

            return this;
		}

        internal bool? DefaultShowValidationMessageBeforeInput
        {
            get
            {
                if (this.html.ViewData[showValidationMessageBeforeInput] == null)
                {
                    return null;
                }

                return (bool?)this.html.ViewData[showValidationMessageBeforeInput];
            }
        }

        public Defaults ShowValidationMessageInline(bool? validationInline = true)
		{
            Contract.Ensures(Contract.Result<Defaults>() != null);

            this.html.ViewData[showValidationMessageInline] = validationInline;

            return this;
		}

        internal bool? DefaultShowValidationMessageInline
        {
            get
            {
                if (this.html.ViewData[showValidationMessageInline] == null)
                {
                    return null;
                }

                return (bool?)this.html.ViewData[showValidationMessageInline];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return this.ToString();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			return this.Equals(obj);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return this.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Type GetType()
		{
			return this.GetType();
		}
	}
}