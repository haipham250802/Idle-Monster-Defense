using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ItemFallController : MonoBehaviour
{
    [SerializeField] private ItemCoin itemCoin;
    [SerializeField] private ItemGold itemGold;
    [SerializeField] private bool isBoss;
    public ItemCurrencyBase ItemFall()
    {
        if (!isBoss)
        {
            int random = Random.Range(0, 100);
            if (random < 20)
                return itemGold;
            else
                return itemCoin;
        }
        else
        {
            return itemGold;
        }
    }
    public void spawnItem(ItemCurrencyBase item, int quantity, Transform trans)
    {
        GameObject obj = SimplePool.Spawn(item.gameObject, trans.position, Quaternion.identity);
        obj.transform.DOJump(trans.position, 0.3f, 1, 0.2f);
        ItemCurrencyBase itemCurrency = obj.GetComponent<ItemCurrencyBase>();
        itemCurrency.Quantity = quantity;
    }
}
