using System;
using System.Collections;
using UnityEngine;

namespace HHG.DialogueSystem.Runtime
{
    [Serializable]
    public abstract class DialogueEntryBase
    {
        public string Id => id;

        // Prevents guid from showing in the inspector
        [SerializeField, HideInInspector] private string _ = string.Empty;
        [SerializeField, HideInInspector] private string id = Guid.NewGuid().ToString();

        public abstract IEnumerator Run(DialogueRunner runner);
    }
}
