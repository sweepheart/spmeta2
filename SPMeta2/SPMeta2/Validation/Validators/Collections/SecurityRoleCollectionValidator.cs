﻿using System.Collections.Generic;
using SPMeta2.Definitions;
using SPMeta2.Validation.Common;

namespace SPMeta2.Validation.Validators.Collections
{
    public class SecurityRoleDefinitionValidator : CollectionValidatorBase
    {
        public override void Validate(IEnumerable<DefinitionBase> models, List<ValidationResult> result)
        {
            Validate<SecurityRoleDefinition>(models, model =>
            {
                CheckIfUnique(model, m => m.Name, result);
            });
        }
    }
}
