using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public string playerTag = "Player";
    public float smoothSpeed = 5f;

    private Transform target;
    private Vector3 offset;

    private void Start()
    {

        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        if (playerObject != null)
        {
            target = playerObject.transform;
            offset = transform.position - target.position;
        }
        else
        {
            Debug.LogWarning("Player not found with tag: " + playerTag);
        }
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;

            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
