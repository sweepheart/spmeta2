﻿using System;
using System.Collections.Generic;
using SPMeta2.Containers.Services.Base;
using SPMeta2.Definitions;
using SPMeta2.Definitions.Base;
using SPMeta2.Enumerations;
using SPMeta2.BuiltInDefinitions;

namespace SPMeta2.Containers.DefinitionGenerators
{
    public class SP2013WorkflowSubscriptionDefinitionGenerator : TypedDefinitionGeneratorServiceBase<SP2013WorkflowSubscriptionDefinition>
    {
        #region constructors

        public SP2013WorkflowSubscriptionDefinitionGenerator()
        {
            WorkflowName = Rnd.String();

            HistoryList = new ListDefinition
            {
                Title = Rnd.String(),
                TemplateType = BuiltInListTemplateTypeId.WorkflowHistory,
#pragma warning disable 618
                Url = Rnd.String()
#pragma warning restore 618
            };

            TaskList = new ListDefinition
            {
                Title = Rnd.String(),
                TemplateType = BuiltInListTemplateTypeId.Tasks,
#pragma warning disable 618
                Url = Rnd.String()
#pragma warning restore 618
            };
        }

        #endregion

        #region properties

        public string WorkflowName { get; set; }

        public ListDefinition HistoryList { get; set; }
        public ListDefinition TaskList { get; set; }

        #endregion

        #region methods

        public override DefinitionBase GenerateRandomDefinition(Action<DefinitionBase> action)
        {
            return WithEmptyDefinition(def =>
            {
                def.Name = Rnd.String();
                def.WorkflowDisplayName = WorkflowName;

                def.EventTypes = new System.Collections.ObjectModel.Collection<string>
                {
                    BuiltInSP2013WorkflowEventTypes.ItemAdded
                };

                // a big TODO as these list don't exist yet


#pragma warning disable 618
                def.HistoryListUrl = "/lists/" + HistoryList.Url;
#pragma warning restore 618
#pragma warning disable 618
                def.TaskListUrl = "/lists/" + TaskList.Url;
#pragma warning restore 618
            });
        }

        public override IEnumerable<DefinitionBase> GetAdditionalArtifacts()
        {
            var workflowDefinitionGenerator = new SP2013WorkflowDefinitionGenerator();
            var workflowDefinition = workflowDefinitionGenerator.GenerateRandomDefinition() as SP2013WorkflowDefinition;

            workflowDefinition.DisplayName = WorkflowName;

            return new[] { workflowDefinition, 
                        TaskList as DefinitionBase,
                        HistoryList as DefinitionBase
            };
        }

        #endregion
    }
}
