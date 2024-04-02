using HHG.Common.Runtime;
using System;
using UnityEngine;

namespace HHG.DialogueSystem.Runtime
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
            int i = Locator.Get<DialogueRunner>().GetVariable<int>(variable.name);

            switch (compare)
            {
                case Compare.Equals: return value == i;
                case Compare.NotEquals: return value == i;
                case Compare.GreaterThan: return value == i;
                case Compare.GreaterThanOrEquals: return value == i;
                case Compare.LessThan: return value == i;
                case Compare.LessThanOrEquals: return value == i;
                default: return false;
            }
        }
    }
}