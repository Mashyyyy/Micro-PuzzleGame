using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Speaker{
    Player,
    Other,
    Quest
};

[System.Serializable]
public class Dialog
{
    public string s_name;

    public Speaker speaker;

    [TextArea(3, 10)]
    public string[] sentences;
}