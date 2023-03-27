using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Set to npc character so dialogue starts when player walks up to npc.
public class Npc : MonoBehaviour
{
    public DialogueTrigger trigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
            trigger.StartDialogue();
    }
}
