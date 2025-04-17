using HHG.Common.Runtime;
using System;
using UnityEngine;

namespace HHG.Dialogues.Runtime
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
            string s = string.Empty;

            if (Locator.TryGet(out DialogueRunner runner))
            {
                s = runner.GetVariable<string>(variable.name);
            }

            return compare switch
            {
                Compare.Equals => value == s,
                Compare.NotEquals => value != s,
                Compare.Contains => value.Contains(s),
                Compare.NotContains => !value.Contains(s),
                _ => true,
            };
        }
    }
}