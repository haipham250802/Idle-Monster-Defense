using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAttackSpeedLobby : UpgradeBase
{
    public override void OnStart()
    {
        base.OnStart();
        initUpgradeAttackSpeedStart();
    }
    protected override void upgrade()
    {
        int gold = DataController.Ins.DataCurrentcy.GetGold();
        if (gold < CoinUpgrade) return;
        UILobby.Ins.UIUpgrade.indexUpradeAttackSpeed += 1;
        DataController.Ins.DataPlayer.SetIndexUpgradeAttackSpeedPlayer(UILobby.Ins.UIUpgrade.indexUpradeAttackSpeed);
        UILobby.Ins.UIUpgrade.SetAttackSpeed(UILobby.Ins.UIUpgrade.indexUpradeAttackSpeed);
        initUpgradeAttackSpeedStart();
    }
    private void initUpgradeAttackSpeedStart()
    {
        float currentAttackSpeed = UILobby.Ins.UIUpgrade.AttackSpeed;
        float newAttackSpeed = UILobby.Ins.UIUpgrade.GetNewAttackSpeed();
        CoinUpgrade = UILobby.Ins.UIUpgrade.GetGoldUpgrade(UILobby.Ins.UIUpgrade.indexUpradeAttackSpeed + 1, E_TypeUpgrade.ATTACK_SPEED);
        initViewInfo(currentAttackSpeed, newAttackSpeed, CoinUpgrade);
    }

}
