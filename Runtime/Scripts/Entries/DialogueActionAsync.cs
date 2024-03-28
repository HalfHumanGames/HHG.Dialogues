using HHG.Common.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HHG.DialogueSystem.Runtime
{
    [Serializable]
    public class DialogueActionAsync : DialogueEntryBase
    {
        [SerializeReference, SerializeReferenceDropdown] private List<IActionAsync> actions = new List<IActionAsync>();

        public override IEnumerator Run(DialogueRunner runner)
        {
            foreach (IActionAsync action in actions)
            {
                yield return runner.StartCoroutine(action?.DoAction(runner));
            }
        }
    }
}