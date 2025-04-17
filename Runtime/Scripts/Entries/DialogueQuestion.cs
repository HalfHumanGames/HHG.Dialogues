using System;
using System.Collections.Generic;
using UnityEngine;

namespace HHG.Dialogues.Runtime
{
    [Serializable]
    public class DialogueQuestion : DialogueTextBase
    {
        public IReadOnlyList<DialogueChoice> Choices => choices;

        [SerializeField, IgnoreParent] private List<DialogueChoice> choices = new List<DialogueChoice>();

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