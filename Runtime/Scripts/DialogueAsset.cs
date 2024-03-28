using System.Collections.Generic;
using UnityEngine;

namespace HHG.DialogueSystem.Runtime
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "HHG/Dialogue System/Dialogue")]
    public class DialogueAsset : ScriptableObject
    {
        public IReadOnlyList<DialogueEntryBase> Entries => entries;

        [SerializeReference, SerializeReferenceDropdown] private List<DialogueEntryBase> entries = new List<DialogueEntryBase>();
    }
}