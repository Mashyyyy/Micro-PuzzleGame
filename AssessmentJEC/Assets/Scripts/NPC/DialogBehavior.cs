using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _playerDialogBox;
    [SerializeField] private GameObject _otherDialogBox;

    [SerializeField] private float _typeSpeed;

    [Header("UI Elements")]
    public TextMeshProUGUI otherName;
    public TextMeshProUGUI otherDialog;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerDialog;
    public Button otherNextButton;
    public Button playerNextButton;

    public AudioSource source;
    public AudioClip clip;

    private Queue<string> sentences;

    private Dialog currentDialog;

    private void Start()
    {
        sentences = new Queue<string>();
    }


    public void StartDialog(Dialog dialog)
    {
        currentDialog = new Dialog();
        currentDialog = dialog;
        sentences.Clear();

        switch (dialog.speaker)
        {
            case Speaker.Player:
            {
                _playerDialogBox.SetActive(true);
                playerName.text = dialog.s_name;
                break;
            }
            case Speaker.Other:
            case Speaker.Quest:
            {
                _otherDialogBox.SetActive(true);
                otherName.text = dialog.s_name;
                break;
            }
        }

        foreach(string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        otherNextButton.interactable = false;
        playerNextButton.interactable = false;
        if (sentences.Count == 0)
        {
            EndDialog(currentDialog);
            return;
        }

        string sentence = sentences.Dequeue();

        StartCoroutine(Type(currentDialog, sentence));
    }

    IEnumerator Type(Dialog dialog, string sentence)
    {
        switch (dialog.speaker)
        {
            case Speaker.Player:
            {
                playerDialog.text = "";
                foreach(char letter in sentence.ToCharArray())
                {
                    playerDialog.text += letter;
                    source.PlayOneShot(clip, 0.7f);
                    yield return new WaitForSeconds(_typeSpeed);
                }
                break;
            }
            case Speaker.Other:
            case Speaker.Quest:
            {
                otherDialog.text = "";
                foreach (char letter in sentence.ToCharArray())
                {
                    otherDialog.text += letter;
                    source.PlayOneShot(clip, 0.7f);
                    yield return new WaitForSeconds(_typeSpeed);
                }
                break;
            }
        }
        otherNextButton.interactable = true;
        playerNextButton.interactable = true;
    }

    public void EndDialog(Dialog dialog)
    {
        switch (dialog.speaker)
        {
            case Speaker.Player:
            {
                _playerDialogBox.SetActive(false);
                playerName.text = "";
                break;
            }
            case Speaker.Other:
            case Speaker.Quest:
            {
                _otherDialogBox.SetActive(false);
                otherName.text = "";
                break;
            }
        }
        GameObject.FindObjectOfType<PlayerMovement>().inDialog = false;
    }
}