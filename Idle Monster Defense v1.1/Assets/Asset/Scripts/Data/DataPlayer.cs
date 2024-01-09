using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPlayer : MonoBehaviour
{
    #region KEY
    private static string KEY_DAMAGE_PLAYER = "DAMAGE_PLAYER";
    private static string KEY_HP_PLAYER = "DAMAGE_PLAYER";
    private static string KEY_RANGE_ATTACK_PLAYER = "RANGE_ATTACK_PLAYER";
    private static string KEY_ATTACK_SPEED_PLAYER = "ATTACK_SPEED_PLAYER";
    #endregion
    #region Damage
    public void SetIndexUpgradeDamage(int value)
    {
        PlayerPrefs.SetInt(KEY_DAMAGE_PLAYER, value);
    }
    public int GetIndexUpgradeDamage()
    {
        return PlayerPrefs.GetInt(KEY_DAMAGE_PLAYER);
    }
    #endregion
    #region HP
    public void SetIndexUpgradeHPPlayer(int value)
    {
        PlayerPrefs.SetInt(KEY_HP_PLAYER, value);
    }
    public int GetIndexUpgradeHP()
    {
        return PlayerPrefs.GetInt(KEY_HP_PLAYER);
    }
    #endregion
    #region Range Attack
    public void SetIndexUpgradeRangeAttackPlayer(int value)
    {
        PlayerPrefs.SetInt(KEY_RANGE_ATTACK_PLAYER, value);
    }
    public int GetIndexUpgradeRangeAttackPlayer()
    {
        return PlayerPrefs.GetInt(KEY_RANGE_ATTACK_PLAYER);
    }
    #endregion
    #region Attack Speed
    public void SetIndexUpgradeAttackSpeedPlayer(int value)
    {
        PlayerPrefs.SetInt(KEY_ATTACK_SPEED_PLAYER, value);
    }
    public int GetIndexUpgradeAttackSpeedPlayer()
    {
        return PlayerPrefs.GetInt(KEY_ATTACK_SPEED_PLAYER);
    }
    #endregion
}
