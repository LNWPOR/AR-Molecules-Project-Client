using UnityEngine;
using System.Collections;

public class CameraEditorController : MonoBehaviour {

    public float zoomSpeed;
    public float maxZoomZ;
    public float minZoomZ;

    public float moveSpeed;

    public bool canMove;
    public bool canZoom;

    void Awake()
    {
        zoomSpeed = 0.1f;
        maxZoomZ = -40f;
        minZoomZ = -7f;

        moveSpeed = 0.05f;

        canMove = true;
        canZoom = true;
    }

    void Update()
    {
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = touchDeltaMag - prevTouchDeltaMag;

            if (transform.position.z + deltaMagnitudeDiff * zoomSpeed >= maxZoomZ && 
                transform.position.z + deltaMagnitudeDiff * zoomSpeed <= minZoomZ &&
                canZoom)
            {
                transform.position = new Vector3(transform.position.x,
                                             transform.position.y,
                                             transform.position.z + deltaMagnitudeDiff * zoomSpeed);
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && canMove)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * moveSpeed, -touchDeltaPosition.y * moveSpeed, 0);
        }
    }
}
