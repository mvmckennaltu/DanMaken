using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerProjectile : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float moveSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(0, 1) * moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag ==("Top"))
        {
            Destroy(gameObject);
        }
    }
}
