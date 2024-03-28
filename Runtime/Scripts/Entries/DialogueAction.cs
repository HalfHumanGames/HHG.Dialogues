using HHG.Common.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HHG.DialogueSystem.Runtime
{
    [Serializable]
    public class DialogueAction : DialogueEntryBase
    {
        [SerializeReference, SerializeReferenceDropdown] private List<IAction> actions = new List<IAction>();

        public override IEnumerator Run(DialogueRunner runner)
        {
            foreach (IAction action in actions)
            {
                action?.DoAction(runner);
            }

            yield break;
        }
    }
}