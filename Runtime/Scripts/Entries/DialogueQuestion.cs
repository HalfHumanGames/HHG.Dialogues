using System;
using System.Collections.Generic;
using UnityEngine;

namespace HHG.DialogueSystem.Runtime
{
    [Serializable]
    public class DialogueQuestion : DialogueTextBase
    {
        public DialogueChoice[] Choices => choices;

        [SerializeField] private DialogueChoice[] choices;

        protected override void Interpolate(IReadOnlyDictionary<string, object> vars)
        {
            base.Interpolate(vars);

            foreach (DialogueChoice choice in choices)
            {
                choice.Interpolate(vars);
            }
        }
    }
}