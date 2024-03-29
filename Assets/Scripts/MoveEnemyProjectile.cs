using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyProjectile : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float moveSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(rb2d.velocity.x, (rb2d.velocity.y - 5f));
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Top") || (collision.gameObject.CompareTag("Enemy")))
           {
            Destroy(gameObject);
        }
    }
}
