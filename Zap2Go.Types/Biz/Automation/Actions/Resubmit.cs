﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zap2Go.Types.Biz.Automation.Actions
{
    public class Resubmit
    {
        public int IntervalMinutes { get; set; }
        public bool CancelOnNewMessage { get; set; }
        public string ResubmitToken { get; set; }
    }
}
