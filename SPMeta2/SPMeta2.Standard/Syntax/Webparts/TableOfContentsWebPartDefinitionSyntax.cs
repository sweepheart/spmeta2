using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SPMeta2.Definitions.Webparts;
using SPMeta2.Models;
using SPMeta2.Standard.Definitions.Webparts;
using SPMeta2.Syntax.Default;

namespace SPMeta2.Standard.Syntax
{

    [Serializable]
    [DataContract]
    public class TableOfContentsWebPartModelNode : WebPartModelNode
    {

    }

    public static class TableOfContentsWebPartDefinitionSyntax
    {
        #region methods

        public static TModelNode AddTableOfContentsWebPart<TModelNode>(this TModelNode model, TableOfContentsWebPartDefinition definition)
            where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            return AddTableOfContentsWebPart(model, definition, null);
        }

        public static TModelNode AddTableOfContentsWebPart<TModelNode>(this TModelNode model, TableOfContentsWebPartDefinition definition,
            Action<TableOfContentsWebPartModelNode> action)
            where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            return model.AddTypedDefinitionNode(definition, action);
        }

        #endregion

        #region array overload

        public static TModelNode AddTableOfContentsWebParts<TModelNode>(this TModelNode model, IEnumerable<TableOfContentsWebPartDefinition> definitions)
           where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            foreach (var definition in definitions)
                model.AddDefinitionNode(definition);

            return model;
        }

        #endregion
    }
}
