using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public EventManager eventManager;
    private PlayerInput input;
    private int playerForm = 0;
    public Vector2 moveVal;
    public float moveSpeed;
    public Sprite redSprite;
    public Sprite blueSprite;
    public Sprite killSprite;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Sprite currentSprite;
    public GameObject playerPrefab;
    public Transform playerShootPoint;
    private Rigidbody2D bulletRB;
    public bool isMovementLocked = false;
    public float playerVelocityAdd = 2.5f;
    public Camera mainCamera;
    public CameraMove cameraMoveScript;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentSprite = redSprite;
        spriteRenderer.sprite = currentSprite;
        playerForm = 0;
        bulletRB = GetComponentInChildren<Rigidbody2D>();
        isMovementLocked = false;
    }

    public void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();
    }

    void OnFire()
    {
        if(!isMovementLocked) 
        {
            Instantiate(playerPrefab, playerShootPoint.position, playerShootPoint.rotation);
        }
        

    }

    void OnColorSwap()
    {   
        if (!isMovementLocked) 
        {
            if (currentSprite == redSprite && playerForm == 0)
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
        
    }

    void Update()
    {
        if(!isMovementLocked) 
        {
            rb2d.velocity = moveVal * moveSpeed;
        }
        rb2d.velocity = new Vector2(rb2d.velocity.x, (rb2d.velocity.y + playerVelocityAdd));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Red" && playerForm == 0)
        {
            Death();
        }
    }
    void Death()
    {
        spriteRenderer.sprite = killSprite;
        isMovementLocked = true;
    }
}
