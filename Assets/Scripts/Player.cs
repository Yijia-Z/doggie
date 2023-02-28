using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public float runSpeed = 20.0f;
    public SpriteRenderer spriteRenderer;
    public Sprite restingUpSprite;
    public Sprite restingDownSprite;
    public Sprite restingLeftSprite;
    public Sprite restingRightSprite;
    public Sprite movingUpSprite;
    public Sprite movingDownSprite;
    public Sprite movingLeftSprite;
    public Sprite movingRightSprite;
    private Sprite prevSprite;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        prevSprite = spriteRenderer.sprite;
        // Change sprite based on movement state and direction
        if (horizontal != 0 || vertical != 0)
        {
            if (horizontal > 0)
            {
                spriteRenderer.sprite = movingRightSprite;
            }
            else if (horizontal < 0)
            {
                spriteRenderer.sprite = movingLeftSprite;
            }
            else if (vertical > 0)
            {
                spriteRenderer.sprite = movingUpSprite;
            }
            else if (vertical < 0)
            {
                spriteRenderer.sprite = movingDownSprite;
            }
        }
        else
        {
            if (prevSprite = movingRightSprite)
            {
                spriteRenderer.sprite = restingRightSprite;
            }
            else if (prevSprite = movingLeftSprite)
            {
                spriteRenderer.sprite = restingLeftSprite;
            }
            else if (prevSprite = movingUpSprite)
            {
                spriteRenderer.sprite = restingUpSprite;
            }
            else if (prevSprite = movingDownSprite)
            {
                spriteRenderer.sprite = restingDownSprite;
            }
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
