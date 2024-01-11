using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGold : ItemCurrencyBase
{
    protected override void initData()
    {
        DataController.Ins.DataCurrentcy.SetGold(Quantity);
    }

    protected override void initView()
    {
        int newCoin = GamePlayManager.Ins.GetQuantityGold(Quantity);
        UIGamePlay.Ins.SetQuantityGold(newCoin);
    }
}
