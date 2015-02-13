﻿using Microsoft.SharePoint.Client;
using SPMeta2.CSOM.ModelHandlers;
using SPMeta2.CSOM.ModelHosts;
using SPMeta2.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SPMeta2.Definitions.Base;
using SPMeta2.Utils;

namespace SPMeta2.Regression.CSOM.Validation
{
    public class ClientMasterPageSettingsDefinitionValidator : MasterPageSettingsModelHandler
    {
        public override void DeployModel(object modelHost, DefinitionBase model)
        {
            var webModelHost = modelHost.WithAssertAndCast<WebModelHost>("modelHost", value => value.RequireNotNull());
            var definition = model.WithAssertAndCast<MasterPageSettingsDefinition>("model", value => value.RequireNotNull());

            var spObject = webModelHost.HostWeb;

            var assert = ServiceFactory.AssertService
                                      .NewAssert(model, definition, spObject)
                                            .ShouldNotBeNull(spObject);


            if (!string.IsNullOrEmpty(definition.SiteMasterPageUrl))
            {
                assert.ShouldBeEndOf(m => m.SiteMasterPageUrl, o => o.CustomMasterUrl);
            }
            else
            {
                assert.SkipProperty(m => m.SiteMasterPageUrl, "SiteMasterPageUrl is NULL or empty");
            }

            if (!string.IsNullOrEmpty(definition.SystemMasterPageUrl))
            {
                assert.ShouldBeEndOf(m => m.SystemMasterPageUrl, o => o.MasterUrl);
            }
            else
            {
                assert.SkipProperty(m => m.SystemMasterPageUrl, "SystemMasterPageUrl is NULL or empty");
            }

        }
    }
}
