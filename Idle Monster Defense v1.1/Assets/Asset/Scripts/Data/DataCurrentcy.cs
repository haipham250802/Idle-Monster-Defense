using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCurrentcy : MonoBehaviour
{
    private static string KEY_COIN = "KEY_COIN";
    private static string KEY_GOLD = "KEY_GOLD";
    private static string KEY_GEM = "KEY_GEM";

    public void SetCoin(int coin)
    {
        PlayerPrefs.SetInt(KEY_COIN, coin);
        PlayerPrefs.Save();
    }
    public int GetCoin()
    {
        return PlayerPrefs.GetInt(KEY_COIN);
    }
    public void SetGold(int coin)
    {
        PlayerPrefs.SetInt(KEY_GOLD, coin);
        PlayerPrefs.Save();
    }
    public int GetGold()
    {
        return PlayerPrefs.GetInt(KEY_GOLD);
    }
    public void SetGem(int coin)
    {
        PlayerPrefs.SetInt(KEY_GEM, coin);
        PlayerPrefs.Save();
    }
    public int GetGem()
    {
        return PlayerPrefs.GetInt(KEY_GEM);
    }
}
