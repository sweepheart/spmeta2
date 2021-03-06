using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SPMeta2.Definitions.Webparts;
using SPMeta2.Models;

namespace SPMeta2.Syntax.Default
{

    [Serializable]
    [DataContract]
    public class XmlWebPartModelNode : WebPartModelNode
    {

    }

    public static class XmlWebPartDefinitionSyntax
    {
        #region methods

        public static TModelNode AddXmlWebPart<TModelNode>(this TModelNode model, XmlWebPartDefinition definition)
            where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            return AddXmlWebPart(model, definition, null);
        }

        public static TModelNode AddXmlWebPart<TModelNode>(this TModelNode model, XmlWebPartDefinition definition,
            Action<XmlWebPartModelNode> action)
            where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            return model.AddTypedDefinitionNode(definition, action);
        }

        #endregion

        #region array overload

        public static TModelNode AddXmlWebParts<TModelNode>(this TModelNode model, IEnumerable<XmlWebPartDefinition> definitions)
           where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            foreach (var definition in definitions)
                model.AddDefinitionNode(definition);

            return model;
        }

        #endregion
    }
}
