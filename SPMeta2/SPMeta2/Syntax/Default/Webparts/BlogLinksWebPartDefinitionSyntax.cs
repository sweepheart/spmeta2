using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using SPMeta2.Definitions.Webparts;
using SPMeta2.Models;

namespace SPMeta2.Syntax.Default
{

    [Serializable]
    [DataContract]
    public class BlogLinksWebPartModelNode : WebPartModelNode
    {

    }

    public static class BlogLinksWebPartDefinitionSyntax
    {
        #region methods

        public static TModelNode AddBlogLinksWebPart<TModelNode>(this TModelNode model, BlogLinksWebPartDefinition definition)
            where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            return AddBlogLinksWebPart(model, definition, null);
        }

        public static TModelNode AddBlogLinksWebPart<TModelNode>(this TModelNode model, BlogLinksWebPartDefinition definition,
            Action<BlogLinksWebPartModelNode> action)
            where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            return model.AddTypedDefinitionNode(definition, action);
        }

        #endregion

        #region array overload

        public static TModelNode AddBlogLinksWebParts<TModelNode>(this TModelNode model, IEnumerable<BlogLinksWebPartDefinition> definitions)
           where TModelNode : ModelNode, IWebpartHostModelNode, new()
        {
            foreach (var definition in definitions)
                model.AddDefinitionNode(definition);

            return model;
        }

        #endregion
    }
}
