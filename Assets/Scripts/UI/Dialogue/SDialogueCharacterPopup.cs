using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
public class SDialogueCharacterPopup : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText2;
    public TextMeshPro dialogueText;

    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalJSON;
    [Header("Ink JSON")]
    [SerializeField] public TextAsset inkJSON;
    public Story currentStory;
    public Coroutine displayLineCoroutine;
    void Start()
    {
        dialoguePanel.SetActive(false);
    }
    public void EnterDialogueMode()
    {
        currentStory = new Story(inkJSON.text);
         SGameInstance.Instance.dialogueController.dialogueVariables.StartListening(currentStory);
        dialoguePanel.SetActive(true);
        SGameInstance.Instance.dialogueController.EnterDialogueMode(inkJSON);

        ContinueStory();
    }
    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine =
                StartCoroutine(DisplayLine(currentStory.Continue()));
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
    private IEnumerator DisplayLine(string line)
    {
        //empty the dialogue text
        dialogueText.text = "";
        //Hide item while text typing
        //HideChoices();
        //canContinuToNextLine = false;
        bool isAddingRichTextTag = false;
        //display each letter one at the time
        foreach (char letter in line.ToCharArray())
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                dialogueText.text = line;
                break;
            }
            //check for rich text tag
            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                dialogueText.text += letter;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            else
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.04f);
            }
        }

        //continueIcon.SetActive(true);

        //DisplayChoices();
        //canContinuToNextLine = true;
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0f);
        SGameInstance.Instance.dialogueController.dialogueVariables.StopListening(currentStory);
        SGameInstance.Instance.dialogueController.dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }
}
