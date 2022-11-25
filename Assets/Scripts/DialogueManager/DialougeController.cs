using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeController : MonoBehaviour
{
    [Header("Sensor")]
    [SerializeField] private GameObject infoIcon;
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    public bool playerInRange;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        playerInRange = false;
        infoIcon.SetActive(false);
    }
    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            infoIcon.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log(inkJSON.text);
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else
        {
            infoIcon.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

}
