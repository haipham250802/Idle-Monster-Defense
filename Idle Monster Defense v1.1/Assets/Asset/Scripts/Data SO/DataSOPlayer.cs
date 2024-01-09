using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/DataStatBasePlayer" , fileName = "DataStatBasePlayer")]
public class DataSOPlayer : ScriptableObject
{
    public PlayerInfo Player;
}
[System.Serializable]
public class PlayerInfo
{
    public float Damage;
    public float Hp;
    public float RangeAttack;
    public float AttackSpeed;
}
