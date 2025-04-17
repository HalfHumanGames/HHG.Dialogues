using HHG.Common.Runtime;
using UnityEngine;

namespace HHG.Dialogues.Runtime
{
    public class ActionSetFloat : IAction
    {
        [SerializeField] private DialogueFloatAsset variable;
        [SerializeField] private float value;
        [SerializeField] private bool relative;

        public void Invoke(MonoBehaviour invoker)
        {
            if (Locator.TryGet(out DialogueRunner runner))
            {
                float newValue = relative ? runner.GetVariable<float>(variable.name) + value : value;
                runner.SetVariable(variable.name, newValue);
            }
        }
    }
}