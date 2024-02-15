using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    public EventManager eventManager;
    private PlayerInput input;
    private int playerForm = 0;
    private AudioSource playerAudioSource;
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
    public static int score;
    public TextMeshProUGUI livesCountText;
    public TextMeshProUGUI scoreCountText;
    public AudioClip shootSound;
    public AudioClip killSound;
    public int lives = 5;
    public bool isDead = false;
    public float deathWaitTime = 1f;
    private BoxCollider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAudioSource = GetComponent<AudioSource>();
        currentSprite = redSprite;
        spriteRenderer.sprite = currentSprite;
        playerForm = 0;
        score = 0;
        lives = 5;
        bulletRB = GetComponentInChildren<Rigidbody2D>();
        isMovementLocked = false;
        Pause.gameIsPaused = false;
        isDead = false;
        
    }

    public void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();
    }

    void OnFire()
    {
        if(!isMovementLocked && Pause.gameIsPaused == false) 
        {
            GameObject bullet = ObjectPooling.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = playerShootPoint.transform.position;
                bullet.transform.rotation = playerShootPoint.transform.rotation;
                bullet.SetActive(true);
                playerAudioSource.PlayOneShot(shootSound);
            }
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
        if (!isMovementLocked)
        {
            rb2d.velocity = moveVal * moveSpeed;
        }
        rb2d.velocity = new Vector2(rb2d.velocity.x, (rb2d.velocity.y + playerVelocityAdd));
        livesCountText.text = lives.ToString();
        scoreCountText.text = score.ToString();
        if (isDead)
        {
            rb2d.velocity = Vector2.zero;
            deathWaitTime -= Time.deltaTime;
            if (deathWaitTime <= 0)
            {
                Revive();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "Red" && playerForm == 1 && !isDead) || (collision.gameObject.tag == "Blue" && playerForm == 0) || (collision.gameObject.tag == "Enemy" ) && !isDead)
        {
            Destroy(collision.gameObject);
            Death();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
    void Death()
    {
        isDead = true;
        spriteRenderer.sprite = killSprite;
        isMovementLocked = true;
        lives--;
        gameObject.tag = "Dead";
        gameObject.layer = 9;
        playerAudioSource.PlayOneShot(killSound);
        if (deathWaitTime <= 0)
        {

            if (lives == 0)
            {
                SceneManager.LoadScene("Game Over");
            }
            else if(lives < 0)
            {
                lives = 0;
            }

        }
        
    }
    void Revive()
    {
        isDead = false;
        deathWaitTime = 1.0f;
        isMovementLocked = false;
        spriteRenderer.sprite = redSprite; 
        playerForm = 0;
        gameObject.layer = 6;
        gameObject.tag = "Player";
        
    }
}
