using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SPMeta2.Definitions.Webparts;
using SPMeta2.Models;

namespace SPMeta2.Syntax.Default
{

    [Serializable]
    [DataContract]
    public class UserDocsWebPartModelNode : WebPartModelNode
    {

    }

    public static class UserDocsWebPartDefinitionSyntax
    {
        #region methods

        public static TModelNode AddUserDocsWebPart<TModelNode>(this TModelNode model, UserDocsWebPartDefinition definition)
            where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            return AddUserDocsWebPart(model, definition, null);
        }

        public static TModelNode AddUserDocsWebPart<TModelNode>(this TModelNode model, UserDocsWebPartDefinition definition,
            Action<UserDocsWebPartModelNode> action)
            where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            return model.AddTypedDefinitionNode(definition, action);
        }

        #endregion

        #region array overload

        public static TModelNode AddUserDocsWebParts<TModelNode>(this TModelNode model, IEnumerable<UserDocsWebPartDefinition> definitions)
           where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            foreach (var definition in definitions)
                model.AddDefinitionNode(definition);

            return model;
        }

        #endregion
    }
}
