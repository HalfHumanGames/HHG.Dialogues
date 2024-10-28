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
            if (Locator.TryGet(out DialogueRunner runner))
            {
                runner.SetVariable(variable.name, value); 
            }
        }
    }
}