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
        int coinUpgrade = GamePlayManager.Ins.GetCoinUpgrade(Turrent.Ins.indexUpradeAttackSpeed + 1, E_TypeUpgrade.ATTACK_SPEED);
        initViewInfo(currentAttackSpeed, newAttackSpeed, coinUpgrade);
    }
    protected override void upgrade()
    {
        Debug.Log("Upgrade attackspeed");
        Turrent.Ins.indexUpradeAttackSpeed += 1;
        Turrent.Ins.SetAttackSpeed(Turrent.Ins.indexUpradeAttackSpeed);
        initUpgradeAttackSpeedStart();
    }
}
