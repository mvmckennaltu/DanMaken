using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallaxMultiplier;
    float parallaxMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       parallaxMovement = Camera.main.transform.position.y * parallaxMultiplier;

        Vector2 newPosition = transform.localPosition;
        newPosition.y = parallaxMovement;
        transform.localPosition = newPosition;
    }
}
