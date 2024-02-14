using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RegularEnemyBehavior : MonoBehaviour
{
    public int enemyType;
    public GameObject enemyRedPrefab;
    public GameObject enemyBluePrefab;
    private Rigidbody2D rb2d;
    private Transform enemyTransform;
    public static Transform shootPoint;
    public Sprite killSprite;
    private SpriteRenderer spriteRenderer;
    public static GameObject[] redPatterns;
    public static GameObject[] bluePatterns;
    public float deathWaitTime = 0.1f;
    private bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyTransform = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(rb2d.velocity.x, -3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit && deathWaitTime > 0)
        {
            deathWaitTime -= Time.deltaTime;
            if (deathWaitTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    

    static public void Shoot()
    {
        int randomPatternTypeChoice = Random.Range(0, 1);
        int redPatternChoice;
        int bluePatternChoice;
        GameObject selectedObject;
        if (randomPatternTypeChoice == 0)
        {
            redPatternChoice = Random.Range(0, redPatterns.Length);
            selectedObject = redPatterns[redPatternChoice];

        }
        else
        {
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
        }
    }
    }
