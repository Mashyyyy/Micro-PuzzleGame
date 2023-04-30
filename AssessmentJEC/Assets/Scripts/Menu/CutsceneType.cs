using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CutsceneType : MonoBehaviour
{
    [SerializeField] private float _typeSpeed;
    public TextMeshProUGUI dialogText;
    public Button nextButton;

    public AudioSource source;
    public AudioClip clip;

    private Queue<string> sentences;

    private Dialog currentDialog;

    private void Awake()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        currentDialog = new Dialog();
        currentDialog = dialog;
        sentences.Clear();

        foreach (string sentence in currentDialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        nextButton.interactable = false;
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
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            source.PlayOneShot(clip, 0.7f);
            yield return new WaitForSeconds(_typeSpeed);
        }
        nextButton.interactable = true;
    }

    public void EndDialog(Dialog dialog)
    {
        SceneManager.LoadScene("MainLevel");
    }
}