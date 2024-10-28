using HHG.Common.Runtime;
using System;
using UnityEngine;

namespace HHG.DialogueSystem.Runtime
{
    [Serializable]
    public class RequireBool : IRequirement
    {
        [SerializeField] private DialogueBoolAsset variable;
        [SerializeField] private bool value;
        [SerializeField] private Compare compare;

        private enum Compare
        {
            Equals,
            NotEquals,
        }

        public bool IsRequirementMet(MonoBehaviour invoker)
        {
            bool b = false;

            if (Locator.TryGet(out DialogueRunner runner))
            {
                b = runner.GetVariable<bool>(variable.name);
            }

            return compare == Compare.Equals ? value == b : value != b;
        }
    }
}