using HHG.Common.Runtime;
using System;
using UnityEngine;

namespace HHG.DialogueSystem.Runtime
{
    [Serializable]
    public class RequireString : IRequirement
    {
        [SerializeField] private DialogueStringAsset variable;
        [SerializeField] private string value;
        [SerializeField] private Compare compare;

        private enum Compare
        {
            Equals,
            NotEquals,
            Contains,
            NotContains
        }

        public bool IsRequirementMet(MonoBehaviour invokerv)
        {
            string s = Locator.Get<DialogueRunner>().GetVariable<string>(variable.name);

            switch (compare)
            {
                case Compare.Equals: return value == s;
                case Compare.NotEquals: return value != s;
                case Compare.Contains: return value.Contains(s);
                case Compare.NotContains: return value.Contains(s);
                default: return false;
            }
        }
    }
}