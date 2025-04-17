using System.Collections;
using TMPro;
using UnityEngine;

namespace HHG.Dialogues.Runtime
{
    public class UIDialogueChoice : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI choiceText;

        public IEnumerator Refresh(DialogueChoice choice)
        {
            choiceText.text = choice.Text;

            yield break;
        }
    }
}