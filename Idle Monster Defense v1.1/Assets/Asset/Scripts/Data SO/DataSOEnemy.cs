using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

[CreateAssetMenu(menuName = "Data/Data Enemy",fileName = "Data Enemy")]
public class DataSOEnemy : ScriptableObject
{
    [SerializeField] private List<EnemyInfo> listEnemyInfo = new();
    public EnemyInfo GetEnemyOfType(E_TypeEnemy typeEnemy)
    {
        foreach (EnemyInfo item in listEnemyInfo)
        {
            if (typeEnemy == item.TypeEnemy)
                return item;
        }
        return null;
    }
}
[System.Serializable]
public class EnemyInfo
{
    public E_TypeEnemy TypeEnemy;
    public SkeletonDataAsset skeleton;
    public float Damage;
    public float HP;
    public float speed;
    public float timeAttack;
    public int quantityCoinKill;
    public int quantityGoldKill;
}