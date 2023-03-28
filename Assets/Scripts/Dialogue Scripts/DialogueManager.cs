using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage; // Portrait image in dialogue box
    public TextMeshProUGUI actorName; // Name text
    public TextMeshProUGUI messageText; // Dialogue text
    public RectTransform backgroundBox; // Dialogue box

    public TextMeshProUGUI response1Text; // Response option 1
    public TextMeshProUGUI response2Text; // Response option 2
    public DialogueTrigger nextDialogue; // LEAVE EMPTY IN EDITOR!
    public RectTransform responseBackgroundBox; // Different dialogue box for responses

    Message[] currentMessages;
    Actor[] currentActors;
    Response[] currentResponses;
    int activeMessage = 0; // index for current dialogue text
    public static bool isActive = false; // Dialogue is happening
    bool sceneSwitch = false;
    int sceneID;

    // Called by Dialogue Trigger
    public void OpenDialogue(Message[] messages, Actor[] actors, Response[] responses, bool switchScene)
    {
        currentMessages = messages;
        currentActors = actors;
        currentResponses =  responses;
        sceneSwitch = switchScene;
        activeMessage = 0;
        isActive = true;
        backgroundBox.localScale = Vector3.one;
        Debug.Log("Started conversation! Loaded messages: " + messages.Length);
        DisplayMessage();
    }

    // Called when player selects a response 
    public void ContinueDialogue()
    {
        activeMessage = 0;
        responseBackgroundBox.localScale = Vector3.zero;
        isActive = true;
        backgroundBox.localScale = Vector3.one;
        Debug.Log("Started conversation! Loaded messages: " + currentMessages.Length);
        DisplayMessage();
    }

    // Updates dialogue displayed
    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

    // Continues in dialogue
    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            isActive = false;
            Debug.Log("Conversation ended!");
            backgroundBox.localScale = Vector3.zero;
            if (currentResponses.Length > 0)
            {
                DisplayResponses();
                SetNextDialogue();
            }
            else
            {
                nextDialogue = null;
                if (sceneSwitch)
                {
                    SwitchScene();
                }
            }
        }
    }

    void DisplayResponses()
    {
        responseBackgroundBox.localScale = Vector3.one;
        response1Text.text = currentResponses[0].response;
        response2Text.text = currentResponses[1].response;
    }

    // Sets up next section of dialogue after a response
    void SetNextDialogue()
    {
        currentMessages = nextDialogue.messages;
        currentActors = nextDialogue.actors;
        currentResponses = nextDialogue.responses;
        sceneSwitch = nextDialogue.switchScene;
        if (sceneSwitch)
        {
            sceneID = nextDialogue.sceneID;
        }
        nextDialogue = nextDialogue.nextDialogue;
        
    }

    public void SetSceneID(int id)
    {
        sceneID = id;
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneID);
    }


    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.localScale = Vector3.zero;

        responseBackgroundBox.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            NextMessage();
        }
    }
}