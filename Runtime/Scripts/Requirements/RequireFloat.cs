using HHG.Common.Runtime;
using System;
using UnityEngine;

namespace HHG.DialogueSystem.Runtime
{
    [Serializable]
    public class RequireFloat : IRequirement
    {
        [SerializeField] private DialogueFloatAsset variable;
        [SerializeField] private float value;
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
            float f = Locator.Get<DialogueRunner>().GetVariable<float>(variable.name);

            switch (compare)
            {
                case Compare.Equals: return value == f;
                case Compare.NotEquals: return value == f;
                case Compare.GreaterThan: return value == f;
                case Compare.GreaterThanOrEquals: return value == f;
                case Compare.LessThan: return value == f;
                case Compare.LessThanOrEquals: return value == f;
                default: return false;
            }
        }
    }
}