using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCoin : ItemCurrencyBase
{
    protected override void initData()
    {
        //  DataController.Ins.DataCurrentcy.SetCoin(quantityCoin);
    }

    protected override void initView()
    {
        int newCoin = GamePlayManager.Ins.GetQuantityCoin(Quantity);
        UIGamePlay.Ins.SetQuantityCoin(newCoin);
    }
}
