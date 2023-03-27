using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages; // dialogue text
    public Actor[] actors; // characters in this dialogue
    public Response[] responses; // response choices
    public DialogueTrigger nextDialogue; // next set of dialogue after choice
    public bool switchScene = false; 
    public int sceneID;
    public bool startImmediately;

    // Initiates the dialogue. Set only to first dialogue trigger if player needs to press a button to enter dialogue.
    public void StartDialogue()
    {
        if (nextDialogue != null)
        {
            FindObjectOfType<DialogueManager>().nextDialogue = nextDialogue;
        }
        if (switchScene)
        {
            FindObjectOfType<DialogueManager>().SetSceneID(sceneID);
        }
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors, responses, switchScene);
        
    }


    // Start is called before the first frame update
    void Start()
    {
        if (startImmediately)
        {
            StartDialogue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// Classes for parts of dialogue system
[System.Serializable]
public class Message
{
    public int actorId;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}

[System.Serializable]
public class Response
{
    public string response;
    public Message ownerReaction;
}

