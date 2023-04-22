using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFadeIn : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float fadeInDuration = 0.5f; // 0.5 second
    public bool isFadingIn = false;
    private float fadeTimer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // Check if it's time to fade in 5:30PM
        if (!isFadingIn && FindObjectOfType<Clock>().getOwnerIndex() >= 0 && FindObjectOfType<Clock>().hour == 4 && FindObjectOfType<Clock>().minute >= 30)
        {
            isFadingIn = true;
        }
        // Fade in the sprite
        if (isFadingIn && fadeTimer < fadeInDuration)
        {
            float alpha = fadeTimer / fadeInDuration;
            spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, alpha);
            fadeTimer += Time.deltaTime;
            //TODO: Play some sfx
        }
        else if (isFadingIn)
        {
            spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f); // fully visible
            isFadingIn = false;
        }
    }
}

