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
    public DialogueTrigger goodEnding;
    public DialogueTrigger badEnding;
    public RectTransform responseBackgroundBox; // Different dialogue box for responses
    public bool isSuccessful;

    Message[] currentMessages;
    Actor[] currentActors;
    Response[] currentResponses;
    int activeMessage = 0; // index for current dialogue text
    public static bool isActive = false; // Dialogue is happening
    bool sceneSwitch = false;
    int sceneID;
    private bool isReacting = false;
    public GameObject BlackPanel;

    // Called by Start Dialogue Trigger
    public void OpenDialogue(Message[] messages, Actor[] actors, Response[] responses, bool switchScene)
    {
        StartCoroutine(FadeBlackOut(false));
        BlackPanel.SetActive(false);
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
    public void ContinueDialogue0()
    {
        if (!isActive)
        {
            isSuccessful = true;
            responseBackgroundBox.localScale = Vector3.zero;
            isActive = true;
            backgroundBox.localScale = Vector3.one;
            DisplayReaction(currentResponses[0].ownerReaction);
            SetNextDialogue();
            activeMessage = 0;
            Debug.Log("Continuing conversation 0! Loaded messages: " + currentMessages.Length);
        }
    }

    public void ContinueDialogue1()
    {
        if (!isActive)
        {
            isSuccessful = false;
            responseBackgroundBox.localScale = Vector3.zero;
            isActive = true;
            backgroundBox.localScale = Vector3.one;
            DisplayReaction(currentResponses[1].ownerReaction);
            SetNextDialogue();
            activeMessage = 0;
            Debug.Log("Continuing conversation 1! Loaded messages: " + currentMessages.Length);
        }
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

    void DisplayReaction(Message reaction)
    {
        isReacting = true;
        Message messageToDisplay = reaction;
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
            }
            else
            {
                nextDialogue = null;
                if (sceneSwitch)
                {
                    StartCoroutine(SwitchScene());
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
        if (nextDialogue is null)
        {
            Debug.Log("next diag is null");
            if (isSuccessful)
            {
                nextDialogue = goodEnding;
            }
            else
            {
                nextDialogue = badEnding;
            }
        }
        Debug.Log("Loading dialogue...");
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

    public IEnumerator SwitchScene()
    {
        BlackPanel.SetActive(true);
        Color objectColor = BlackPanel.GetComponent<Image>().color;
        float fadeAmount;

        while (BlackPanel.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColor.a + (1 * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            BlackPanel.GetComponent<Image>().color = objectColor;
            yield return null;
        }
        //yield return new WaitForSecondsRealtime(2);

        SceneManager.LoadScene(sceneID);
    }

    public IEnumerator FadeBlackOut(bool fadeToBlack = true, int fadeSpeed = 1)
    {
        Color objectColor = BlackPanel.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (BlackPanel.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                BlackPanel.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        else
        {
            while (BlackPanel.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                BlackPanel.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
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
            if (isReacting)
            {
                isReacting = false;
                Debug.Log("Entered isReacting!");
                DisplayMessage();
            }
            else
            {
                Debug.Log("Entered else!");
                NextMessage();
            }
        }
    }
}
