using HHG.Common.Runtime;
using UnityEngine;

namespace HHG.DialogueSystem.Runtime
{
    public class ActionSetFloat : IAction
    {
        [SerializeField] private DialogueFloatAsset variable;
        [SerializeField] private float value;
        [SerializeField] private bool relative;

        public void Invoke(MonoBehaviour invoker)
        {
            if (relative)
            {
                float f = Locator.Get<DialogueRunner>().GetVariable<float>(variable.name);
                Locator.Get<DialogueRunner>()?.SetVariable(variable.name, f + value);
            }
            else
            {
                Locator.Get<DialogueRunner>()?.SetVariable(variable.name, value);
            }
        }
    }
}