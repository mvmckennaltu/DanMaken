using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public EventManager eventManager;
    private PlayerInput input;
    private int playerForm;
    public Vector2 moveVal;
    public float moveSpeed;
    public Sprite redSprite;
    public Sprite blueSprite;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Sprite currentSprite;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentSprite = redSprite;
        spriteRenderer.sprite = currentSprite;
        playerForm = 0;
    }

    public void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();
    }

    void OnFire()
    {
        // Handle firing logic
    }

    void OnColorSwap()
    {
        if (currentSprite == redSprite)
        {
            currentSprite = blueSprite;
            playerForm = 1;
        }
        else
        {
            currentSprite = redSprite;
            playerForm = 0;
        }
        spriteRenderer.sprite = currentSprite;
    }

    void Update()
    {
        rb2d.velocity = moveVal * moveSpeed;
    }
}
