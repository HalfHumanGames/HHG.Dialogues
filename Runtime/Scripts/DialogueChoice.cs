using HHG.Common.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HHG.DialogueSystem.Runtime
{
    [Serializable]
    public class DialogueChoice
    {
        public string Id => id;
        public string Text => interpolated;
        public DialogueAsset Destination => destination;

        [SerializeField, HideInInspector] private string id = Guid.NewGuid().ToString();
        [SerializeField, TextArea] private string text;
        [SerializeField] private DialogueAsset destination;
        [SerializeReference, SerializeReferenceDropdown] private List<IRequirement> requirements = new List<IRequirement>();
        [SerializeReference, SerializeReferenceDropdown] private List<IActionAsync> actions = new List<IActionAsync>();

        private string interpolated;

        public bool IsRequirementMet(MonoBehaviour invoker) => requirements.All(r => r.IsRequirementMet(invoker));

        public void Interpolate(IReadOnlyDictionary<string, object> vars)
        {
            interpolated = TextInterpolator.Interpolate(text, vars);
        }
    }
}