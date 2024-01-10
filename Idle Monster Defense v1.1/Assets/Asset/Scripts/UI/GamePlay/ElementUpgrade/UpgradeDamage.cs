using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDamage : UpgradeBase
{
    public override void OnStart()
    {
        base.OnStart();
        initUpgradeDamageStart();
    }
    private void initUpgradeDamageStart()
    {
        float currentDamage = Turrent.Ins.Damage;
        float newDamage = Turrent.Ins.GetNewDamage();
        CoinUpgrade = GamePlayManager.Ins.GetCoinUpgrade(Turrent.Ins.indexUpradeDamage + 1, E_TypeUpgrade.DAMAGE);
        initViewInfo(currentDamage, newDamage, CoinUpgrade);
    }
    protected override void upgrade()
    {
        if (GamePlayManager.Ins.GetQuantityCoin() < CoinUpgrade) return;
        Turrent.Ins.indexUpradeDamage += 1;
        Turrent.Ins.SetDamage(Turrent.Ins.indexUpradeDamage);
        initUpgradeDamageStart();
        UIGamePlay.Ins.SetTextDamage(Turrent.Ins.Damage);
    }
}
