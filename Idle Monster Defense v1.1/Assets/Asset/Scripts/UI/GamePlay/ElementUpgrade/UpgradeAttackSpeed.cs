using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAttackSpeed : UpgradeBase
{
    public override void OnStart()
    {
        base.OnStart();
        initUpgradeAttackSpeedStart();
    }
    private void initUpgradeAttackSpeedStart()
    {
        float currentAttackSpeed = Turrent.Ins.AttackSpeed;
        float newAttackSpeed = Turrent.Ins.GetNewAttackSpeed();
        CoinUpgrade = GamePlayManager.Ins.GetCoinUpgrade(Turrent.Ins.indexUpradeAttackSpeed + 1, E_TypeUpgrade.ATTACK_SPEED);
        initViewInfo(currentAttackSpeed, newAttackSpeed, CoinUpgrade);
    }
    protected override void upgrade()
    {
        if (GamePlayManager.Ins.GetQuantityCoin() < CoinUpgrade) return;
        Turrent.Ins.indexUpradeAttackSpeed += 1;
        Turrent.Ins.SetAttackSpeed(Turrent.Ins.indexUpradeAttackSpeed);
        GamePlayManager.Ins._QuantityCoin -= CoinUpgrade;
        UIGamePlay.Ins.SetQuantityCoin(GamePlayManager.Ins._QuantityCoin);
        initUpgradeAttackSpeedStart();
    }
}
