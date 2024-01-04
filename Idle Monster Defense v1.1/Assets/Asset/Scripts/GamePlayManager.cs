using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager Ins;
    [SerializeField] HeatlhBar healthBar;
    [SerializeField] SpawnEnemyController spawnEnemyController;
    [SerializeField] ItemGold itemGold;
    [SerializeField] ItemCoin itemCoin;
    [SerializeField] List<GameObject> listObjSpawnItem;
    public SpawnEnemyController SpawnEnemyController => spawnEnemyController;
    public HeatlhBar HealthBar => healthBar;
    private void Awake()
    {
        if (Ins == null)
            Ins = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        SpawnNoneCurrency();
    }
    private void SpawnNoneCurrency()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject itemCoinClone = SimplePool.Spawn(itemCoin.gameObject,Vector3.zero,Quaternion.identity);
            listObjSpawnItem.Add(itemCoinClone);
        }
        for (int i = 0; i < 5; i++)
        {
            GameObject itemGoldClone = SimplePool.Spawn(itemGold.gameObject, Vector3.zero, Quaternion.identity);
            listObjSpawnItem.Add(itemGoldClone);
        }
        foreach (GameObject item in listObjSpawnItem)
        {
            SimplePool.Despawn(item);
        }
    }
}
