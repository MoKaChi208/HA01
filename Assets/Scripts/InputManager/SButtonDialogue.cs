using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SButtonDialogue : Button
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if (DialogueManager.GetInstance().playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            DialogueManager.GetInstance().EnterDialogueMode(DialogueManager.GetInstance().inkJSON);
        }
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        if (DialogueManager.GetInstance().canContinuToNextLine && DialogueManager.GetInstance().currentStory.currentChoices.Count == 0)
        {
            DialogueManager.GetInstance().ContinueStory();
        }
    }

    // Button is released
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        Debug.Log("OnPointerUp");
    }
}
