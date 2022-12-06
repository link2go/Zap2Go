using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zap2Go.Types.Http.Api.Automation;

namespace Zap2Go.Types.Biz.Automation
{
    public abstract class BaseAction
    {
        internal abstract string TypeName();
        public string Type { get { return TypeName(); } }

    }
}
