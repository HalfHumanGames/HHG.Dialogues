using HHG.Common.Runtime;
using UnityEngine;

namespace HHG.DialogueSystem.Runtime
{
    public class ActionSetInt : IAction
    {
        [SerializeField] private DialogueIntAsset variable;
        [SerializeField] private int value;
        [SerializeField] private bool relative;

        public void Invoke(MonoBehaviour invoker)
        {
            if (Locator.TryGet(out DialogueRunner runner))
            {
                int newValue = relative ? runner.GetVariable<int>(variable.name) + value : value;
                runner.SetVariable(variable.name, newValue);
            }
        }
    }
}