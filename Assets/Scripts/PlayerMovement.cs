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
   
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    
    public void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();

    }
    void Shoot()
    {

        
        
    }
    void Update()
    {
        rb2d.velocity = moveVal * moveSpeed;
    }
}
