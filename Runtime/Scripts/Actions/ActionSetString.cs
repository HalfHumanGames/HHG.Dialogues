using HHG.Common.Runtime;
using UnityEngine;

namespace HHG.DialogueSystem.Runtime
{
    public class ActionSetString : IAction
    {
        [SerializeField] private DialogueStringAsset variable;
        [SerializeField] private string value;
        [SerializeField] private bool append;

        public void Invoke(MonoBehaviour invoker)
        {
            if (Locator.TryGet(out DialogueRunner runner))
            {
                string newValue = append ? runner.GetVariable<string>(variable.name) + value : value;
                runner.SetVariable(variable.name, newValue);
            }
        }
    }
}