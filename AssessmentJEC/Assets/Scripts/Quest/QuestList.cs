using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestList : MonoBehaviour
{
    [SerializeField] private float q_timer = 300;
    public bool timerIsRunning = false;

    public TextMeshProUGUI timerText;

    public List<TextMeshProUGUI> questList;

    public int questCompletedCount;

    [SerializeField] private QuestGiver questGiver;

    private void Start()
    {
        questGiver = FindObjectOfType<QuestGiver>();
    }

    public void ClearQuest(int identfier)
    {
        questList[identfier].fontStyle = FontStyles.Strikethrough;
        questCompletedCount++;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if(q_timer > 0)
            {
                q_timer -= Time.deltaTime;
                DisplayTime(q_timer);
            }
            else
            {
                //Timer has run out
                q_timer = 0;
                questGiver.GameOver();
            }
        }
    }

    void DisplayTime(float timeDisplay)
    {
        timeDisplay += 1;
        float minutes = Mathf.FloorToInt(timeDisplay / 60);
        float seconds = Mathf.FloorToInt(timeDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}