using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Data Shop", fileName = "Data Shop")]
public class DataSOShop : ScriptableObject
{
    [SerializeField] private List<ShopElementInfo> ListShopElement = new();
    public ShopElementInfo GetShopElementOfType(TypeShopElement type)
    {
        foreach (ShopElementInfo item in ListShopElement)
        {
            if(type == item.Type)
            {
                return item;
            }
        }
        return null;
    }
}
[System.Serializable]
public class ShopElementInfo
{
    public TypeShopElement Type;
    public int quantityBonus;
    public string name;
}
