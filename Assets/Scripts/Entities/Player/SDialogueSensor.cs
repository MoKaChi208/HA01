using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDialogueSensor : MonoBehaviourCore
{
    public bool playerInRange;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    private void Awake()
    {
        playerInRange = false;
    }

    public void Update()
    {
        if (GameInstance.buttonAttackController.isClick)
        {
            OnClickDialogue();
            GameInstance.buttonAttackController.isClick = false;
        }
    }
    public void OnClickDialogue()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if (true)
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            playerInRange = false;
        }
    }
}
