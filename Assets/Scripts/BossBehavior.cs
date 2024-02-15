using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.SceneManagement;
public class BossBehavior : MonoBehaviour
{
    public int bossHP = 50;
    public GameObject[] redPatterns;
    public GameObject[] bluePatterns;
    public Sprite killSprite;
    private SpriteRenderer spriteRenderer;
    public static Transform shootPoint;
    public GameObject goal;
    public bool isDead = false;
    public float deathWaitTime = 1f;
    public Sprite redSprite;
    public Sprite normalSprite;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
     if (isDead)
        {
            deathWaitTime -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player Bullet"))
        {
            bossHP--;
            StartCoroutine(FlashColor());
            collision.gameObject.SetActive(false);
            if (bossHP < 0)
            {
                bossHP = 0;
            }
            if (bossHP == 0) 
            {
                Death();
            }
        }
    }
    public void Shoot()
    {

        if (!isDead)
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
        

    }
    public void Death()
    {
        
            Instantiate(goal, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        
        
        
    }
    IEnumerator FlashColor()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
}
