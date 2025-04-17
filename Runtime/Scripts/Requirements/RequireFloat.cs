using HHG.Common.Runtime;
using System;
using UnityEngine;

namespace HHG.Dialogues.Runtime
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
            float f = 0f;

            if (Locator.TryGet(out DialogueRunner runner))
            {
                f = runner.GetVariable<float>(variable.name);
            }

            return compare switch
            {
                Compare.Equals => value == f,
                Compare.NotEquals => value != f,
                Compare.GreaterThan => value > f,
                Compare.GreaterThanOrEquals => value >= f,
                Compare.LessThan => value < f,
                Compare.LessThanOrEquals => value <= f,
                _ => true,
            };
        }
    }
}