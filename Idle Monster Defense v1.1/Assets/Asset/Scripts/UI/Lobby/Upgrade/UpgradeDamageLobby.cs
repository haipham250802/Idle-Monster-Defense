using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDamageLobby : UpgradeBase
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
        UILobby.Ins.UIUpgrade.indexUpradeDamage += 1;
        DataController.Ins.DataPlayer.SetIndexUpgradeDamage(UILobby.Ins.UIUpgrade.indexUpradeDamage);
        UILobby.Ins.UIUpgrade.SetDamage(UILobby.Ins.UIUpgrade.indexUpradeDamage);
        initUpgradeAttackSpeedStart();
    }
    private void initUpgradeAttackSpeedStart()
    {
        float currentDamage = UILobby.Ins.UIUpgrade.Damage;
        float newDamage = UILobby.Ins.UIUpgrade.GetNewDamage();
        CoinUpgrade = UILobby.Ins.UIUpgrade.GetGoldUpgrade(UILobby.Ins.UIUpgrade.indexUpradeDamage + 1, E_TypeUpgrade.DAMAGE);
        initViewInfo(currentDamage, newDamage, CoinUpgrade);
    }

}
