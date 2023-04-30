using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public Vector3 boundsMax;
    public Vector3 boundsMin;
    bool inBounds = true;

    private void FixedUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPos;

        transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, boundsMin.x, boundsMax.x),
        Mathf.Clamp(transform.position.y, boundsMin.y, boundsMax.y),
        transform.position.z
        );
    }
}