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

    public void StartDialogue()
    {
        if (nextDialogue != null)
        {
            FindObjectOfType<DialogueManager>().nextDialogue = nextDialogue;
        }
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors, responses);
        
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
    //public DialogueTrigger trigger;
}