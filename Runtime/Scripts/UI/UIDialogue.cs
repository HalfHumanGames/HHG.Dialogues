using HHG.Common.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace HHG.Dialogues.Runtime
{
    public class UIDialogue : MonoBehaviour
    {

        [SerializeField] private InputActionReference continueAction;
        [SerializeField] private Image portraitImage;
        [SerializeField] private TextMeshProUGUI characterName;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private UIDialogueChoice choiceTemplate;

        private List<UIDialogueChoice> uiChoices = new List<UIDialogueChoice>();

        private Coroutine current;

        private void Start()
        {
            //choiceTemplate.gameObject.SetActive(false);
        }

        public IEnumerator Refresh(DialogueTextBase entry)
        {
            portraitImage.sprite = entry.Character.Portrait;
            characterName.text = entry.Character.name;

            continueAction.action.Enable();

            current = StartCoroutine(Typewriter.Typewrite(dialogueText, entry.Text, continueAction));
            yield return current;

            continueAction.action.Reset();

            current = StartCoroutine(ButtonWaiter.WaitForButtonPress(continueAction));
            yield return current;

            continueAction.action.Disable();

            //if (entry is DialogueQuestion question)
            //{
            //    foreach (DialogueChoice choice in question.Choices.Where(c => c.IsRequirementMet()))
            //    {
            //        UIDialogueChoice uiChoice = Instantiate(choiceTemplate, choiceTemplate.transform.parent);

            //        yield return StartCoroutine(uiChoice.Refresh(choice));

            //        uiChoice.GetComponent<Button>().onClick.AddListener(() =>
            //        {
            //            Debug.Log(uiChoice.name);
            //        });

            //        uiChoices.Add(uiChoice);
            //    }

               
            //}

            //foreach (UIDialogueChoice choice in choices)
            //{
            //    Destroy(choice);
            //}

            //choices.Clear();
        }

        public void Continue()
        {
            if (current != null)
            {
                StopCoroutine(current);
            }
        }
    }
}