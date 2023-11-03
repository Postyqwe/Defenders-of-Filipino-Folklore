using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 2.0f;

    private void Update()
    {
        // Calculate the movement distance
        float moveDistance = moveSpeed * Time.deltaTime;

        // Move the camera along the X-axis
        transform.Translate(Vector3.right * moveDistance);
    }
}
