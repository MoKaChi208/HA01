using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SButtonInteract : MonoBehaviourCore
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    public UnityAction<TextAsset> EnterDialogue;
    public Button dialogButton;
    void Start()
    {
        EnterDialogue = DialogueManager.GetInstance().EnterDialogueMode;
        dialogButton.onClick.AddListener(DialogueManager.GetInstance().OnClickContinueStory);
    }
    public void OnClickButtonAttack()
    {
        GameInstance.buttonAttackController.OnClickAttackButton();
    }
    public void OnClickDialogue()
    {
        EnterDialogue?.Invoke(inkJSON);
    }

}
