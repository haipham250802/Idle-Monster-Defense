using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGem : ItemCurrencyBase
{
    protected override void initData()
    {
        DataController.Ins.DataCurrentcy.SetGem(quantityCoin);
    }
}
