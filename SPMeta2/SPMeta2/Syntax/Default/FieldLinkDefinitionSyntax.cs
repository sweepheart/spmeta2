﻿using System;
using System.Collections.Generic;
using SPMeta2.Definitions;
using SPMeta2.Models;
using SPMeta2.Syntax.Default.Extensions;

namespace SPMeta2.Syntax.Default
{
    public static class FieldLinkDefinitionSyntax
    {
        #region methods

        public static ContentTypeModelNode AddContentTypeFieldLinks(this ContentTypeModelNode model, IEnumerable<Guid> fieldIds)
        {
            foreach (var fieldId in fieldIds)
                AddContentTypeFieldLink(model, fieldId);

            return model;
        }



        public static ContentTypeModelNode AddContentTypeFieldLink(this ContentTypeModelNode model, Guid fieldId)
        {
            return AddContentTypeFieldLink(model, fieldId, null);
        }

        public static ContentTypeModelNode AddContentTypeFieldLink(this ContentTypeModelNode model, Guid fieldId, Action<ModelNode> action)
        {
            return model.AddContentTypeFieldLink(new ContentTypeFieldLinkDefinition
            {
                FieldId = fieldId
            }, action);
        }

        public static ContentTypeModelNode AddContentTypeFieldLinks(this ContentTypeModelNode model, IEnumerable<FieldDefinition> definitions)
        {
            foreach (var definition in definitions)
                AddContentTypeFieldLink(model, definition);

            return model;
        }

        public static ContentTypeModelNode AddContentTypeFieldLink(this ContentTypeModelNode model, FieldDefinition definition)
        {
            return AddContentTypeFieldLink(model, definition, null);
        }

        public static ContentTypeModelNode AddContentTypeFieldLink(this ContentTypeModelNode model, FieldDefinition definition, Action<ModelNode> action)
        {
            if (definition.Id != default(Guid))
            {
                return model.AddContentTypeFieldLink(new ContentTypeFieldLinkDefinition
                {
                    FieldId = definition.Id
                }, action);
            }

            return model.AddContentTypeFieldLink(new ContentTypeFieldLinkDefinition
            {
                FieldInternalName = definition.InternalName
            }, action);
        }

        //public static ModelNode AddContentTypeFieldLink(this ModelNode model, ContentTypeFieldLinkDefinition definition)
        //{
        //    return model.AddDefinitionNode(definition, null);
        //}

        //public static ModelNode AddContentTypeFieldLink(this ModelNode model, ContentTypeFieldLinkDefinition definition, Action<ModelNode> action)
        //{
        //    return model.AddDefinitionNode(definition, action);
        //}

        #endregion

        #region array overload

        public static ModelNode AddContentTypeFieldLinks(this ModelNode model, IEnumerable<ContentTypeFieldLinkDefinition> definitions)
        {
            foreach (var definition in definitions)
                model.AddDefinitionNode(definition);

            return model;
        }

        #endregion

    }
}