using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.EventSystems;


public class DialogueController
{
    public TextAsset loadGlobalJSON;
    public TextAsset inkJSON;
    public bool dialogueIsPlaying;
    public bool canContinuToNextLine = false;
    public DialogueVariables dialogueVariables;
    public bool playerInRange;
    public DialogueController()
    {
        loadGlobalJSON = Resources.Load<TextAsset>("Dialogue/" + "LoadGlobals");
        inkJSON = Resources.Load<TextAsset>("Dialogue/" + "Pokemon");
        dialogueVariables = new DialogueVariables(loadGlobalJSON);
        canContinuToNextLine = false;
        playerInRange = false;
        dialogueIsPlaying = false;
    }
    public void EnterDialogueMode(TextAsset inkJSON)
    {

        dialogueIsPlaying = true;

      //  ContinueStory();
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
