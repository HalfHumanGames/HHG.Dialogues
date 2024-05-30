using HHG.Common.Runtime;
using System;
using System.Collections;
using UnityEngine;

namespace HHG.DialogueSystem.Runtime
{
    [Serializable]
    public class DialogueAction : DialogueEntryBase
    {
        [SerializeField] private ActionEvent action = new ActionEvent();

        public override IEnumerator Run(DialogueRunner runner)
        {
            return action.InvokeRoutine(runner);
        }
    }
}