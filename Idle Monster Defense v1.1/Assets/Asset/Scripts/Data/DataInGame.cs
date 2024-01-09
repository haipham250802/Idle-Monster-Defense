using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInGame : MonoBehaviour
{
    private const string KEY_FIRST_PLAY = "FIRST_PLAY";
    public bool GetFirstPlay()
    {
        int index = PlayerPrefs.GetInt(KEY_FIRST_PLAY);
        if (index == 0)
            return false;
        else
            return true;
    }
    public void SetFirstPlay(int value)
    {
        PlayerPrefs.SetInt(KEY_FIRST_PLAY, value);
    }
}
