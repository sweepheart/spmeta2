﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.SharePoint;
using SPMeta2.SSOM.ModelHosts;

namespace SPMeta2.SSOM.ModelHandlers.ContentTypes.Base
{
    public abstract class ContentTypeLinksModelHandlerBase : SSOMModelHandlerBase
    {
        #region methods

        protected SPFolder ExtractFolderFromHost(object modelHost)
        {
            if (modelHost is ListModelHost)
                return (modelHost as ListModelHost).HostList.RootFolder;

            if (modelHost is FolderModelHost)
                return (modelHost as FolderModelHost).CurrentLibraryFolder;

            throw new ArgumentException("modelHost needs to be ListModelHost or FolderModelHost");
        }

        protected SPList ExtractListFromHost(object modelHost)
        {
            if (modelHost is ListModelHost)
                return (modelHost as ListModelHost).HostList;

            if (modelHost is FolderModelHost)
            {
                var host = modelHost as FolderModelHost;

                return host.CurrentLibrary ?? host.CurrentList;
            }

            throw new ArgumentException("modelHost needs to be ListModelHost or FolderModelHost");
        }

        #endregion
    }
}
