using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.SharePoint.WebPartPages;
using SPMeta2.Containers.Assertion;
using SPMeta2.Definitions;
using SPMeta2.Definitions.Base;
using SPMeta2.Definitions.Webparts;
using SPMeta2.SSOM.Extensions;
using SPMeta2.SSOM.ModelHosts;
using SPMeta2.Utils;

namespace SPMeta2.Regression.SSOM.Validation.Webparts
{
    public class PictureLibrarySlideshowWebPartDefinitionValidator : WebPartDefinitionValidator
    {
        #region properties

        public override Type TargetType
        {
            get { return typeof(PictureLibrarySlideshowWebPartDefinition); }
        }

        #endregion

        #region methods

        public override void DeployModel(object modelHost, DefinitionBase model)
        {
            // base validation
            base.DeployModel(modelHost, model);

            // web specific validation
            var host = modelHost.WithAssertAndCast<WebpartPageModelHost>("modelHost", value => value.RequireNotNull());
            var definition = model.WithAssertAndCast<PictureLibrarySlideshowWebPartDefinition>("model", value => value.RequireNotNull());

            WebPartExtensions.WithExistingWebPart(host.HostFile, definition, (spWebPartManager, spObject) =>
            {
                var web = spWebPartManager.Web;
                var typedObject = spObject as PictureLibrarySlideshowWebPart;

                var assert = ServiceFactory.AssertService
                    .NewAssert(definition, typedObject)
                    .ShouldNotBeNull(typedObject);

                

            });

        }

        #endregion
    }
}
