using UnityEngine;
using UnityEngine.Events;
public class CameraMove : MonoBehaviour
{
    public float scrollSpeed = 0.05f;
    public bool cameraIsMoving = true;
    private Transform cameraPos;
   

    // Reference to the player's transform
    public Transform playerTransform;

    void Start()
    {
        cameraPos = GetComponent<Transform>();
    }

    void Update()
    {
        if (cameraIsMoving)
        {
            // Move the camera upwards
            cameraPos.Translate(Vector2.up * scrollSpeed * Time.deltaTime);

            // Move the player upwards to compensate for the camera movement
            playerTransform.Translate(Vector2.up * scrollSpeed * Time.deltaTime);
        }
    }
}
