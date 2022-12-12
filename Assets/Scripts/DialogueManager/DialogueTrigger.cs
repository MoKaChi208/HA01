using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviourCore
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private void Awake()
    {
        //        DialogueManager.GetInstance().playerInRange = false;
        visualCue.SetActive(false);
    }
    private void Update()
    {
        if (DialogueManager.GetInstance().playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            // if (Input.GetKeyDown(KeyCode.Space))
            // {
            //     DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            // }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DialogueManager.GetInstance().inkJSON = inkJSON;
            DialogueManager.GetInstance().playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DialogueManager.GetInstance().inkJSON = null;
            DialogueManager.GetInstance().playerInRange = false;
        }
    }

}
