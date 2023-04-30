using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneDialog : MonoBehaviour
{
    public Dialog dialog;

    private void Start()
    {
        GameObject.FindObjectOfType<CutsceneType>().StartDialog(dialog);
    }
}