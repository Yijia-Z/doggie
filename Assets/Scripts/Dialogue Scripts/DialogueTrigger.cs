using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;
    public Response[] responses;
    public DialogueTrigger nextDialogue;
    public bool switchScene = false;
    public int sceneID;
    public bool startImmediately;

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
}

