using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dragSpeed = 2f;
    public float boundary = 10f;

    private Vector3 dragOrigin;

    void Update()
    {
        HandleCameraDrag();
    }

    void HandleCameraDrag()
    {
        if (Input.GetMouseButtonDown(1))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(1)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

        Vector3 newPosition = transform.position + move;

        // Limit the camera position within specified boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, -boundary, boundary);
        newPosition.y = Mathf.Clamp(newPosition.y, -boundary, boundary);

        transform.position = newPosition;
    }
}
