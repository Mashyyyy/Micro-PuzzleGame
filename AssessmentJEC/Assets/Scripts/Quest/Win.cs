using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public void OnClick_MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClick_Quit()
    {
        Application.Quit();
    }
}