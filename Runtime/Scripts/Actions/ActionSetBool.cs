using HHG.Common.Runtime;
using UnityEngine;

namespace HHG.DialogueSystem.Runtime
{
    public class ActionSetBool : IAction
    {
        [SerializeField] private DialogueBoolAsset variable;
        [SerializeField] private bool value;

        public void Invoke(MonoBehaviour invoker)
        {
            Locator.Get<DialogueRunner>()?.SetVariable(variable.name, value);
        }
    }
}