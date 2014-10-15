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
        public CodeBlockControl<TModel> CodeBlock(string code)
        {
            Contract.Requires<ArgumentNullException>(code != null, "code");
            Contract.Requires<ArgumentException>(!code.IsNullOrWhiteSpace());
            Contract.Ensures(Contract.Result<CodeBlockControl<TModel>>() != null);

            return new CodeBlockControl<TModel>(this.html, code);
        }

        public CodeBlockBuilder<TModel> BeginCodeBlock()
        {
            Contract.Ensures(Contract.Result<CodeBlockBuilder<TModel>>() != null);

            return new CodeBlockBuilder<TModel>(this.html, new CodeBlock());
        }

        public CodeBlockBuilder<TModel> BeginCodeBlock(CodeBlock codeBlock)
        {
            Contract.Requires<ArgumentNullException>(codeBlock != null, "codeBlock");
            Contract.Ensures(Contract.Result<CodeBlockBuilder<TModel>>() != null);

            return new CodeBlockBuilder<TModel>(this.html, codeBlock);
        }
    }
}