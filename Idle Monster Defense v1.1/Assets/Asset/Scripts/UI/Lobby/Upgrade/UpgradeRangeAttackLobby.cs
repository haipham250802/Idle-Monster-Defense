using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRangeAttackLobby : UpgradeBase
{
    public override void OnStart()
    {
        base.OnStart();
        initUpgradeRangeAttack();
    }
    protected override void upgrade()
    {
        int gold = DataController.Ins.DataCurrentcy.GetGold();
        if (gold < CoinUpgrade) return;
        UILobby.Ins.UIUpgrade.indexUpradeRangeAttack += 1;
        DataController.Ins.DataPlayer.SetIndexUpgradeRangeAttackPlayer(UILobby.Ins.UIUpgrade.indexUpradeRangeAttack);
        UILobby.Ins.UIUpgrade.SetRangeAttack(UILobby.Ins.UIUpgrade.indexUpradeRangeAttack);
        initUpgradeRangeAttack();
    }
    private void initUpgradeRangeAttack()
    {
        float currentRangeAttack = UILobby.Ins.UIUpgrade.RangeAttack;
        float newRangeAttack = UILobby.Ins.UIUpgrade.GetNewRangeAttack();
        CoinUpgrade = UILobby.Ins.UIUpgrade.GetGoldUpgrade(UILobby.Ins.UIUpgrade.indexUpradeRangeAttack + 1, E_TypeUpgrade.RANGE_ATTACK);
        initViewInfo(currentRangeAttack, newRangeAttack, CoinUpgrade);
    }

}
