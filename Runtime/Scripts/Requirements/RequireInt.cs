using HHG.Common.Runtime;
using System;
using UnityEngine;

namespace HHG.Dialogues.Runtime
{
    [Serializable]
    public class RequireInt : IRequirement
    {
        [SerializeField] private DialogueIntAsset variable;
        [SerializeField] private int value;
        [SerializeField] private Compare compare;

        public enum Compare
        {
            Equals,
            NotEquals,
            GreaterThan,
            GreaterThanOrEquals,
            LessThan,
            LessThanOrEquals
        }

        public bool IsRequirementMet(MonoBehaviour invoker)
        {
            int i = 0;

            if (Locator.TryGet(out DialogueRunner runner))
            {
                i = runner.GetVariable<int>(variable.name);
            }

            return compare switch
            {
                Compare.Equals => value == i,
                Compare.NotEquals => value != i,
                Compare.GreaterThan => value > i,
                Compare.GreaterThanOrEquals => value >= i,
                Compare.LessThan => value < i,
                Compare.LessThanOrEquals => value <= i,
                _ => true,
            };
        }
    }
}