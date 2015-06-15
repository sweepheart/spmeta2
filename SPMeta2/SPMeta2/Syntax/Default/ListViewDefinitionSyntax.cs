﻿using System;
using System.Collections.Generic;
using SPMeta2.Definitions;
using SPMeta2.Models;
using SPMeta2.Syntax.Default.Extensions;

namespace SPMeta2.Syntax.Default
{
    public static class ListViewDefinitionSyntax
    {
        #region methods


        #endregion

        #region methods

        public static ModelNode AddListView(this ModelNode model, ListViewDefinition definition)
        {
            return AddListView(model, definition, null);
        }

        public static ModelNode AddListView(this ModelNode model, ListViewDefinition definition, Action<ModelNode> action)
        {
            return model.AddDefinitionNode(definition, action);
        }

        #endregion

        #region array overload

        public static ModelNode AddListViews(this ModelNode model, IEnumerable<ListViewDefinition> definitions)
        {
            foreach (var definition in definitions)
                model.AddDefinitionNode(definition);

            return model;
        }

        #endregion

        #region host override

      

        #endregion
    }
}
