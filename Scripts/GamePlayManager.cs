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
    [SerializeField] private int QuantityCoin = 0;
    [SerializeField] private int QuantityGold = 0;
    [SerializeField] private int QuantityGem = 0;
    [SerializeField] List<GameObject> listObjSpawnItem;

    public SpawnEnemyController SpawnEnemyController => spawnEnemyController;
    public HeatlhBar HealthBar => healthBar;
    public bool isLose;
    public bool isShowPopUpLose;
  
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
    public int GetQuantityCoin(int value)
    {
        return QuantityCoin += value;
    }
    public int GetQuantityCoin()
    {
        return QuantityCoin;
    }
    public int GetQuantityGold(int value)
    {
        return QuantityGold += value;
    }
    public int GetQuantityGold()
    {
        return QuantityGold;
    }
    public int GetQuantityGem(int value)
    {
        return QuantityGem += value;
    }
    private void SpawnNoneCurrency()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject itemCoinClone = SimplePool.Spawn(itemCoin.gameObject, Vector3.zero, Quaternion.identity);
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
    public int GetCoinUpgrade(int index, E_TypeUpgrade typeUpgrade)
    {
        switch (typeUpgrade)
        {
            case E_TypeUpgrade.NONE:
                break;
            case E_TypeUpgrade.DAMAGE:
                return index * 4 + ((index * 5) / 2);
            case E_TypeUpgrade.HP:
                return index * 3 + ((index * 4) / 2);
            case E_TypeUpgrade.RANGE_ATTACK:
                return index * 20 + ((index * 6) / 2);
            case E_TypeUpgrade.ATTACK_SPEED:
                return index * 6 + ((index * 4) / 2);
            default:
                break;
        }
        return 0;
    }
}
