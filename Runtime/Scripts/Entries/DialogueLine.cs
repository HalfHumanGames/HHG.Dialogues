using HHG.Common.Runtime;
using System;
using UnityEngine;

namespace HHG.Dialogues.Runtime
{
    [Serializable]
    public class DialogueLine : DialogueTextBase
    {
        [SerializeField, Unfold] private ActionEvent actions;
    }
}