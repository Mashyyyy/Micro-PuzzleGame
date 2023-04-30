using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    public Dialog dialog;

    public GameObject pressE;

    [SerializeField]
    bool inTrigger;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pressE.SetActive(true);
            inTrigger = true;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pressE.SetActive(true);
            inTrigger = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pressE.SetActive(false);
            inTrigger = false;
        }
    }

    private void Update()
    {
        if(inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            pressE.SetActive(false);
            FindObjectOfType<DialogBehavior>().StartDialog(dialog);
            GameObject.FindObjectOfType<PlayerMovement>().inDialog = true;
        }
    }
}