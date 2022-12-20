﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation.Actions
{
    public abstract class BaseAction
    {
        internal abstract string TypeName();
        public string Type { get { return TypeName(); } }
    }
}
