using HHG.Common.Runtime;
using UnityEngine;

namespace HHG.DialogueSystem.Runtime
{
    public class ActionSetInt : IAction
    {
        [SerializeField] private DialogueIntAsset variable;
        [SerializeField] private int value;
        [SerializeField] private bool relative;

        public void DoAction(MonoBehaviour invoker)
        {
            if (relative)
            {
                int i = Locator.Get<DialogueRunner>().GetVariable<int>(variable.name);
                Locator.Get<DialogueRunner>()?.SetVariable(variable.name, i + value);
            }
            else
            {
                Locator.Get<DialogueRunner>()?.SetVariable(variable.name, value);
            }
        }
    }
}