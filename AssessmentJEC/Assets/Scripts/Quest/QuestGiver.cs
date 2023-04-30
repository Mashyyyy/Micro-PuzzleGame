using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private bool questActive = false;
    public GameObject questPanel;
    public GameObject questItems;

    bool inTrigger = false;

    public NPCBehavior dialog1, dialog2;

    public GameObject gameOverPanel, winPanel, altWinPanel;

    public GameObject pressE;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inTrigger = false;
        }
    }

    private void Update()
    {
        if(inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (!questActive)
            {
                questActive = true;
                dialog1.enabled = false;
                dialog2.enabled = true;
                questPanel.SetActive(true);
                questItems.SetActive(true);
                questPanel.gameObject.GetComponent<QuestList>().timerIsRunning = true;
            }
            else if(questActive)
            {
                if(questPanel.gameObject.GetComponent<QuestList>().questCompletedCount == 4)
                {
                    Destroy(dialog1);
                    Destroy(dialog2);
                    Win();
                }
                else if (questPanel.gameObject.GetComponent<QuestList>().questCompletedCount == 5)
                {
                    Destroy(dialog1);
                    Destroy(dialog2);
                    AltWin();
                }
            }
        }
    }

    public void GameOver()
    {
        GameObject.FindObjectOfType<PlayerMovement>().finished = true;
        questPanel.SetActive(false);
        questItems.SetActive(false);
        pressE.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void Win()
    {
        GameObject.FindObjectOfType<PlayerMovement>().finished = true;
        questPanel.SetActive(false);
        questItems.SetActive(false);
        pressE.SetActive(false);
        winPanel.SetActive(true);
    }

    public void AltWin()
    {
        GameObject.FindObjectOfType<PlayerMovement>().finished = true;
        questPanel.SetActive(false);
        questItems.SetActive(false);
        pressE.SetActive(false);
        altWinPanel.SetActive(true);
    }
}