using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    public Vector3 newBoundsMin;
    public Vector3 newBoundsMax;

    public Transform teleportTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindObjectOfType<Camera>().GetComponent<PlayerCamera>().boundsMax = newBoundsMax;
            GameObject.FindObjectOfType<Camera>().GetComponent<PlayerCamera>().boundsMin = newBoundsMin;

            collision.transform.position = teleportTarget.position;
        }
    }
}