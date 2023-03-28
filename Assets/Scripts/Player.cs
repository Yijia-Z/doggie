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
    public Animator playerAnimator;
    public Sprite restingUpSprite;
    public Sprite restingDownSprite;
    public Sprite restingLeftSprite;
    public Sprite restingRightSprite;
    public Sprite movingUpSprite;
    public Sprite movingDownSprite;
    public Sprite movingLeftSprite;
    public Sprite movingRightSprite;
    private Sprite prevSprite;
    private Clock clock;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
        clock = FindObjectOfType<Clock>();
    }

    void Update()
    {
        if (!clock.getIsPaused())
        {
            horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
            vertical = Input.GetAxisRaw("Vertical"); // -1 is down
            prevSprite = spriteRenderer.sprite;
            // Change sprite based on movement state and direction
            if (horizontal != 0 || vertical != 0)
            {
                if (horizontal > 0)
                {
                    //spriteRenderer.sprite = movingRightSprite;
                    playerAnimator.Play("walkright");
                }
                else if (horizontal < 0)
                {
                    //spriteRenderer.sprite = movingLeftSprite;
                    playerAnimator.Play("walkleft");
                }
                else if (vertical > 0)
                {
                    //spriteRenderer.sprite = movingUpSprite;
                    playerAnimator.Play("walkup");

                }
                else if (vertical < 0)
                {
                    //spriteRenderer.sprite = movingDownSprite;
                    playerAnimator.Play("walkdown");
                }
            }
            else
            {
                playerAnimator.Play("idlefront");
                /*
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
                  */
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
