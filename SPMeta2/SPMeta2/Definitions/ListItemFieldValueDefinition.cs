﻿using SPMeta2.Attributes;
using SPMeta2.Attributes.Regression;
using SPMeta2.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPMeta2.Definitions
{
    /// <summary>
    /// Allows to define and deploy field value on the target list item.
    /// </summary>
    /// 

    [SPObjectTypeAttribute(SPObjectModelType.SSOM, "Microsoft.SharePoint.SPListItem", "Microsoft.SharePoint")]
    [SPObjectTypeAttribute(SPObjectModelType.CSOM, "Microsoft.SharePoint.Client.ListItem", "Microsoft.SharePoint.Client")]

    [RootHostAttribute(typeof(WebDefinition))]
    [ParentHostAttribute(typeof(ListItemDefinition))]

    [Serializable]

    public class ListItemFieldValueDefinition : DefinitionBase
    {
        #region properties

        /// <summary>
        /// Field name of the target field value.
        /// FieldId property can be used to set field by ID.
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Field id.
        /// </summary>
        public Guid? FieldId { get; set; }

        /// <summary>
        /// Target field value.
        /// </summary>
        public object Value { get; set; }

        #endregion
    }
}