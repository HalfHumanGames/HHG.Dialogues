using HHG.Common.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HHG.Dialogues.Runtime
{
    [Serializable]
    public abstract class DialogueTextBase : DialogueEntryBase
    {
        public CharacterAsset Character => character;
        public Alignment Alignment => alignment;
        public string Text => interpolated;

        [SerializeField] private CharacterAsset character;
        [SerializeField] Alignment alignment;
        [SerializeField, TextArea] private string text;

        private string interpolated;

        protected virtual void Interpolate(IReadOnlyDictionary<string, object> vars)
        {
            interpolated = TextInterpolator.Interpolate(text, vars);
        }

        public override IEnumerator Run(DialogueRunner runner)
        {
            Interpolate(runner.Variables);

            yield return runner.StartCoroutine(runner.UI.Refresh(this));
        }
    }
}