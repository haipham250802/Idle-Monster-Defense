using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHP : UpgradeBase
{
    public override void OnStart()
    {
        base.OnStart();
        initUpgradeHPStart();
    }
    private void initUpgradeHPStart()
    {
        float currentHp = Turrent.Ins.HP;
        float newHp = Turrent.Ins.GetNewHp();
        int coinUpgrade = GamePlayManager.Ins.GetCoinUpgrade(Turrent.Ins.indexUpradeHp + 1, E_TypeUpgrade.HP);
        initViewInfo(currentHp, newHp, coinUpgrade);
    }
    protected override void upgrade()
    {
        Turrent.Ins.indexUpradeHp += 1;
        Turrent.Ins.SetHp(Turrent.Ins.indexUpradeHp);
        initUpgradeHPStart();
        UIGamePlay.Ins.SetTextHp(Turrent.Ins.HP);
    }
}
