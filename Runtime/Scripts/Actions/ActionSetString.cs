using HHG.Common.Runtime;
using UnityEngine;

namespace HHG.DialogueSystem.Runtime
{
    public class ActionSetString : IAction
    {
        [SerializeField] private DialogueStringAsset variable;
        [SerializeField] private string value;
        [SerializeField] private bool append;

        public void DoAction(MonoBehaviour invoker)
        {
            if (append)
            {
                string s = Locator.Get<DialogueRunner>().GetVariable<string>(variable.name);
                Locator.Get<DialogueRunner>()?.SetVariable(variable.name, s + value);
            }
            else
            {
                Locator.Get<DialogueRunner>()?.SetVariable(variable.name, value);
            }
        }
    }
}