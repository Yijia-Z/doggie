using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;

    public TextMeshProUGUI response1Text;
    public TextMeshProUGUI response2Text;
    public DialogueTrigger nextDialogue; // LEAVE EMPTY IN EDITOR
    public RectTransform responseBackgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    Response[] currentResponses;
    int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors, Response[] responses)
    {
        currentMessages = messages;
        currentActors = actors;
        currentResponses =  responses;
        activeMessage = 0;
        isActive = true;
        backgroundBox.localScale = Vector3.one;
        Debug.Log("Started conversation! Loaded messages: " + messages.Length);
        DisplayMessage();
    }

    public void ContinueDialogue()
    {
        activeMessage = 0;
        responseBackgroundBox.localScale = Vector3.zero;
        isActive = true;
        backgroundBox.localScale = Vector3.one;
        Debug.Log("Started conversation! Loaded messages: " + currentMessages.Length);
        DisplayMessage();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

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
            }
        }
    }

    void DisplayResponses()
    {
        responseBackgroundBox.localScale = Vector3.one;
        response1Text.text = currentResponses[0].response;
        response2Text.text = currentResponses[1].response;
    }

    void SetNextDialogue()
    {
        currentMessages = nextDialogue.messages;
        currentActors = nextDialogue.actors;
        currentResponses = nextDialogue.responses;
        nextDialogue = nextDialogue.nextDialogue;
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
