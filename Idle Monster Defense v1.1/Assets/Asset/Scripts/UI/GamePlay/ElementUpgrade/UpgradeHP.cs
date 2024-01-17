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
        CoinUpgrade = GamePlayManager.Ins.GetCoinUpgrade(Turrent.Ins.indexUpradeHp + 1, E_TypeUpgrade.HP);
        initViewInfo(currentHp, newHp, CoinUpgrade);
    }
    protected override void upgrade()
    {
        if (GamePlayManager.Ins.GetQuantityCoin() < CoinUpgrade) return;
        Turrent.Ins.indexUpradeHp += 1;
        Turrent.Ins.SetHp(Turrent.Ins.indexUpradeHp);
        GamePlayManager.Ins._QuantityCoin -= CoinUpgrade;
        UIGamePlay.Ins.SetQuantityCoin(GamePlayManager.Ins._QuantityCoin);
        initUpgradeHPStart();
        UIGamePlay.Ins.SetTextHp(Turrent.Ins.HP);
    }
}
