using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Set to npc character so dialogue starts when player walks up to npc.
public class Npc : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collission detected...");
        if (collision.gameObject.CompareTag("Player") == true)
        {
            Debug.Log("..collission with player...");
            if (gameObject.GetComponent<SpriteRenderer>().color.a == 1)
            {
                Debug.Log("...fading black");
                StartCoroutine(FindObjectOfType<Clock>().fadeBlack());
            }
        }
    }
}
