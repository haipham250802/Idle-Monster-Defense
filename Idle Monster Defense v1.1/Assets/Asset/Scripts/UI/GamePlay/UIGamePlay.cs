using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIGamePlay : MonoBehaviour
{
    public static UIGamePlay Ins;
    [SerializeField] private Text quantityCoinClaim;
    [SerializeField] private Text quantityGoldClaim;
    [SerializeField] private Text quantityGemClaim;
    [SerializeField] private Text damageTxt;
    [SerializeField] private Text hpTxt;
    [SerializeField] private contentProcess _contentProcess;
    [SerializeField] private List<UpgradeBase> listUpgradeBase;

    public contentProcess ContentProcess => _contentProcess;

    private void Awake()
    {
        if (Ins == null)
            Ins = this;
        else
            DestroyImmediate(gameObject);
    }
    public void OnStart()
    {
        SetQuantityCoin(0);
        SetQuantityGold(0);
        SetQuantityGem(0);
        ElementUpgradeOnStart();
    }
    private void ElementUpgradeOnStart()
    {
        foreach (UpgradeBase item in listUpgradeBase)
        {
            item.OnStart();
        }
    }
    public void SetTextHp( float hp)
    {
        hpTxt.text = hp.ToString();
    }
    public void SetTextDamage(float damage)
    {
        damageTxt.text = damage.ToString();
    }
    public void SetQuantityCoin(int quantityCoin)
    {
        quantityCoinClaim.text = quantityCoin.ToString();
    }
    public void SetQuantityGold(int quantityGold)
    {
        quantityGoldClaim.text = quantityGold.ToString();
    }
    public void SetQuantityGem(int quantityGem)
    {
        quantityGemClaim.text = quantityGem.ToString();
    }
}
