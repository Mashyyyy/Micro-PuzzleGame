using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    //Which quest item will be completed
    public int q_identifier;

    public GameObject pressE;

    bool inTrigger = false;

    public CircleCollider2D _collider;
    public SpriteRenderer spriteRend;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            pressE.SetActive(true);
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
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
            GameObject.FindObjectOfType<QuestList>().ClearQuest(q_identifier);
            Invoke("DestroyCollider", 0.1f);
            spriteRend.sprite = null;
        }
    }

    void DestroyCollider()
    {
        Destroy(_collider);
        Destroy(this);
    }
}