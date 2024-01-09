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
        int coinUpgrade = GamePlayManager.Ins.GetCoinUpgrade(Turrent.Ins.indexUpradeRangeAttack + 1, E_TypeUpgrade.RANGE_ATTACK);
        initViewInfo(currentRangeAttack, newRangeAttack, coinUpgrade);
    }
    protected override void upgrade()
    {
        Turrent.Ins.indexUpradeRangeAttack += 1;
        Turrent.Ins.SetRangeAttack(Turrent.Ins.indexUpradeRangeAttack);
        initUpgradeRangeAttackStart();
        Turrent.Ins.UpdateRangeAttack();
    }
}
