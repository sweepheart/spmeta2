using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using Microsoft.SharePoint.Portal.WebControls;
using Microsoft.SharePoint.Publishing.WebControls;

using Microsoft.SharePoint.WebPartPages;
using Microsoft.Office.Server.Search.WebControls;
using Microsoft.Office.Server.WebControls;

using SPMeta2.Definitions;
using SPMeta2.Definitions.Webparts;
using SPMeta2.Services;
using SPMeta2.SSOM.ModelHandlers;
using SPMeta2.SSOM.ModelHosts;
using SPMeta2.Standard.Definitions.Webparts;
using SPMeta2.Utils;
using WebPart = System.Web.UI.WebControls.WebParts.WebPart;

namespace SPMeta2.SSOM.Standard.ModelHandlers.Webparts
{
    public class SearchBoxScriptWebPartModelHandler : WebPartModelHandler
    {
        #region properties

        public override Type TargetType
        {
            get { return typeof(SearchBoxScriptWebPartDefinition); }
        }

        #endregion

        #region methods

        protected override void OnBeforeDeployModel(WebpartPageModelHost host, WebPartDefinition webpartModel)
        {
            var typedModel = webpartModel.WithAssertAndCast<SearchBoxScriptWebPartDefinition>("webpartModel", value => value.RequireNotNull());
            typedModel.WebpartType = typeof(SearchBoxScriptWebPart).AssemblyQualifiedName;
        }

        protected override void ProcessWebpartProperties(WebPart webpartInstance, WebPartDefinition webpartModel)
        {
            base.ProcessWebpartProperties(webpartInstance, webpartModel);

            var typedWebpart = webpartInstance.WithAssertAndCast<SearchBoxScriptWebPart>("webpartInstance", value => value.RequireNotNull());
            var definition = webpartModel.WithAssertAndCast<SearchBoxScriptWebPartDefinition>("webpartModel", value => value.RequireNotNull());

            // TODO, specific provision
        }

        #endregion
    }
}
