using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRangeAttack : UpgradeBase
{
    public override void OnStart()
    {
        base.OnStart();
        initUpgradeRangeAttackStart();
    }
    private void initUpgradeRangeAttackStart()
    {
        float currentRangeAttack = Turrent.Ins.RangeAttack;
        float newRangeAttack = Turrent.Ins.GetNewRangeAttack();
        CoinUpgrade = GamePlayManager.Ins.GetCoinUpgrade(Turrent.Ins.indexUpradeRangeAttack + 1, E_TypeUpgrade.RANGE_ATTACK);
        initViewInfo(currentRangeAttack, newRangeAttack, CoinUpgrade);
    }
    protected override void upgrade()
    {
        if (GamePlayManager.Ins.GetQuantityCoin() < CoinUpgrade) return;
        Turrent.Ins.indexUpradeRangeAttack += 1;
        Turrent.Ins.SetRangeAttack(Turrent.Ins.indexUpradeRangeAttack);
        GamePlayManager.Ins._QuantityCoin -= CoinUpgrade;
        UIGamePlay.Ins.SetQuantityCoin(GamePlayManager.Ins._QuantityCoin);
        initUpgradeRangeAttackStart();
        Turrent.Ins.UpdateRangeAttack();
    }
}
