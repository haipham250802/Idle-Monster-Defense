using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInGame : MonoBehaviour
{
    private const string KEY_FIRST_PLAY = "FIRST_PLAY";
    private const string ID_ZONE = "ID_ZONE";
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
    public void SetIDZone(int value)
    {
        PlayerPrefs.SetInt(ID_ZONE, value);
    }
    public int GetIDZone()
    {
        return PlayerPrefs.GetInt(ID_ZONE);
    }
}
