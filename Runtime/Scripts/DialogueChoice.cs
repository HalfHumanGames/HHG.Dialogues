using HHG.Common.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HHG.Dialogues.Runtime
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
        [SerializeReference, SubclassSelector] private List<IRequirement> requirements = new List<IRequirement>();
        [SerializeField, Unfold] private ActionEvent actions;

        private string interpolated;

        public bool IsRequirementMet(MonoBehaviour invoker) => requirements.All(r => r.IsRequirementMet(invoker));

        public void Interpolate(IReadOnlyDictionary<string, object> vars)
        {
            interpolated = TextInterpolator.Interpolate(text, vars);
        }
    }
}