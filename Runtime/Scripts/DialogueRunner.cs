using HHG.Common.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HHG.Dialogues.Runtime
{
    public class DialogueRunner : MonoBehaviour
    {
        public UIDialogue UI => ui;
        public IReadOnlyDictionary<string, DialogueAsset> Dialogues => dialogues;
        public IReadOnlyDictionary<string, object> Variables => variables;

        [SerializeField] private UIDialogue ui;

        private Dictionary<string, DialogueAsset> dialogues = new Dictionary<string, DialogueAsset>();
        private Dictionary<string, object> variables = new Dictionary<string, object>();

        private void Awake()
        {
            Locator.Register(this);
        }

        private void Start()
        {
            dialogues = Resources.LoadAll<DialogueAsset>(string.Empty).ToDictionary(d => d.name, d => d);

            LoadVariables<DialogueBoolAsset>();
            LoadVariables<DialogueFloatAsset>();
            LoadVariables<DialogueIntAsset>();
            LoadVariables<DialogueStringAsset>();
        }

        public void SetVariable(string key, object value)
        {
            variables[key] = value;
        }

        public T GetVariable<T>(string key)
        {
            return (T)GetVariable(key);
        }

        public object GetVariable(string key)
        {
            return variables.TryGetValue(key, out var value) ? value : null;
        }

        public void RunDialogue(string name)
        {
            if (dialogues.ContainsKey(name))
            {
                RunDialogue(dialogues[name]);
            }
        }

        public void RunDialogue(DialogueAsset dialogue)
        {
            StopDialogue();
            StartCoroutine(RunDialogueInternal(dialogue));
        }

        public void StopDialogue()
        {
            StopAllCoroutines();
        }

        private IEnumerator RunDialogueInternal(DialogueAsset dialogue)
        {
            foreach (DialogueEntryBase entry in dialogue.Entries)
            {
                yield return StartCoroutine(entry.Run(this));
            }
        }

        private void LoadVariables<T>() where T : VariableAssetBase
        {
            T[] assets = Resources.LoadAll<T>(string.Empty);

            foreach (T asset in assets)
            {
                variables[asset.name] = asset.WeakValue;
            }
        }

        private void OnDestroy()
        {
            Locator.Unregister(this);
        }
    }
}