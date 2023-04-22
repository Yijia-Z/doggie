using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Set to npc character so dialogue starts when player walks up to npc.
public class Npc : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            if (gameObject.GetComponent<SpriteRenderer>().color.a == 1)
                StartCoroutine(FindObjectOfType<Clock>().fadeBlack());
        }
    }
}
