﻿using SPMeta2.Attributes;
using SPMeta2.Attributes.Regression;
using System;
namespace SPMeta2.Definitions
{
    /// <summary>
    /// Allows too define and deploy SharePoint web site.
    /// </summary>
    /// 

    [SPObjectTypeAttribute(SPObjectModelType.SSOM, "Microsoft.SharePoint.SPWeb", "Microsoft.SharePoint")]
    [SPObjectTypeAttribute(SPObjectModelType.CSOM, "Microsoft.SharePoint.Client.Web", "Microsoft.SharePoint.Client")]


    [RootHostAttribute(typeof(SiteDefinition))]
    [ParentHostAttribute(typeof(SiteDefinition))]

    [Serializable]
    public class WebDefinition : DefinitionBase
    {
        #region constructors

        public WebDefinition()
        {
            Url = "/";
        }

        #endregion

        #region properties

        /// <summary>
        /// Title of the target web.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description of the target web.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// LCID of the target web.
        /// </summary>
        public uint LCID { get; set; }

        /// <summary>
        /// Should unique permissions be used for the new web.
        /// </summary>
        public bool UseUniquePermission { get; set; }

        /// <summary>
        /// Convert to the new web template if web if there.
        /// </summary>
        public bool ConvertIfThere { get; set; }

        /// <summary>
        /// URL of the target. 
        /// Should be relative to the current web. 
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// WebTemplate of the target web.
        /// 
        /// BuiltInWebTemplates class can be used to utilize out of the box SharePoint web templates.
        /// </summary>
        public string WebTemplate { get; set; }

        /// <summary>
        /// Custom web template name of the target web.
        /// </summary>
        public string CustomWebTemplate { get; set; }

        #endregion
    }
}