﻿using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SPMeta2.SSOM.ModelHosts
{
    public class ListModelHost : SSOMModelHostBase
    {
        #region properties

        public SPList HostList { get; set; }

        #endregion
    }
}
