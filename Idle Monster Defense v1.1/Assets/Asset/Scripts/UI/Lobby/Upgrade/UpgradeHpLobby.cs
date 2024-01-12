using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHpLobby : UpgradeBase
{
    public override void OnStart()
    {
        base.OnStart();
        initUpgradeHp();
    }
    protected override void upgrade()
    {
        int gold = DataController.Ins.DataCurrentcy.GetGold();
        if (gold < CoinUpgrade) return;
        UILobby.Ins.UIUpgrade.indexUpradeHp += 1;
        DataController.Ins.DataPlayer.SetIndexUpgradeHPPlayer(UILobby.Ins.UIUpgrade.indexUpradeHp);
        UILobby.Ins.UIUpgrade.SetHp(UILobby.Ins.UIUpgrade.indexUpradeHp);
        initUpgradeHp();
    }
    private void initUpgradeHp()
    {
        float currentHp = UILobby.Ins.UIUpgrade.HP;
        float newHp = UILobby.Ins.UIUpgrade.GetNewHp();
        CoinUpgrade = UILobby.Ins.UIUpgrade.GetGoldUpgrade(UILobby.Ins.UIUpgrade.indexUpradeHp + 1, E_TypeUpgrade.HP);
        initViewInfo(currentHp, newHp, CoinUpgrade);
    }

}
