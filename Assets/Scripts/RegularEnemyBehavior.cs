using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class RegularEnemyBehavior : MonoBehaviour
{
    public int enemyType;
    public GameObject enemyRedPrefab;
    public GameObject enemyBluePrefab;
    private Rigidbody2D rb2d;
    
    public  Transform shootPoint;
    public Sprite killSprite;
    private SpriteRenderer spriteRenderer;
    public  GameObject[] redPatterns;
    public  GameObject[] bluePatterns;
    public float deathWaitTime = 0.1f;
    public float shootWaitTime = 0.5f;
    private bool isHit = false;
    private bool isGonnaShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(rb2d.velocity.x, -3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit && deathWaitTime > 0)
        {
            rb2d.velocity = Vector2.zero;
            deathWaitTime -= Time.deltaTime;
            if (deathWaitTime <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (isGonnaShoot && shootWaitTime > 0)
        {
            shootWaitTime -= Time.deltaTime;
            if (shootWaitTime <= 0)
            {
                Shoot();
            }
        }
    }
    

     public void Shoot()
    {
      

        
        
        
        GameObject selectedObject;
        if (enemyType == 0)
        {
            int redPatternChoice;
            redPatternChoice = Random.Range(0, redPatterns.Length);
            selectedObject = redPatterns[redPatternChoice];

        }
        else
        {
            int bluePatternChoice;
            bluePatternChoice = Random.Range(0, bluePatterns.Length);
            selectedObject = bluePatterns[bluePatternChoice];

        }
        Instantiate(selectedObject, shootPoint.position, shootPoint.rotation);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isHit && collision.gameObject.CompareTag("Player Bullet"))
        {
            collision.gameObject.SetActive(false);
            spriteRenderer.sprite = killSprite;
            rb2d.velocity = Vector2.zero; 
            isHit = true;
            PlayerMovement.score = PlayerMovement.score + 10;
        }
    }
    }
