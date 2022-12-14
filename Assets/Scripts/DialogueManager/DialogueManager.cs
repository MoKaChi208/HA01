using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalJSON;
    [Header("Ink JSON")]
    [SerializeField] public TextAsset inkJSON;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    public Story currentStory;
    public bool dialogueIsPlaying { get; private set; }
    public bool canContinuToNextLine = false;
    public Coroutine displayLineCoroutine;
    private static DialogueManager instance;
    private DialogueVariables dialogueVariables;
    public bool playerInRange;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Dialogue Manager in the scene");
        }
        instance = this;

        dialogueVariables = new DialogueVariables(loadGlobalJSON);
    }
    public static DialogueManager GetInstance()
    {
        return instance;
    }
    void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        //get all choices text
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }
    void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }
        if (canContinuToNextLine && currentStory.currentChoices.Count == 0
                && Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        dialogueVariables.StartListening(currentStory);

        ContinueStory();
    }
    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0f);
        dialogueVariables.StopListening(currentStory);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
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
        continueIcon.SetActive(false);
        HideChoices();
        canContinuToNextLine = false;
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

        continueIcon.SetActive(true);

        DisplayChoices();
        canContinuToNextLine = true;
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        //defensive check UI support number of choices 
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. " +
            "Number of choices given: "
            + currentChoices.Count);
        }

        int index = 0;
        //enable and initialize the choices up to the amount of choices
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        //go through the remaining choives and hidden 
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }
    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        if (canContinuToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
    }

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " + variableName);
        }
        return variableValue;
    }

    //This method will get called anytime the application exits.
    //Depending on your game, you may want to save variable state in other places
    public void OnApplicationQuit()
    {
        if (dialogueVariables != null)
        {
            dialogueVariables.SaveVariables();
        }
    }
}
