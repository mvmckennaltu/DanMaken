using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossBehavior : MonoBehaviour
{
    public int bossHP = 50;
    public GameObject[] redPatterns;
    public GameObject[] bluePatterns;
    public Sprite killSprite;
    private SpriteRenderer spriteRenderer;
    public static Transform shootPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player Bullet"))
        {
            bossHP = bossHP - 1;
            if (bossHP < 0)
            {
                bossHP = 0;
            }
            if (bossHP == 0) 
            {
                
            }
        }
    }
    public void Shoot()
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
