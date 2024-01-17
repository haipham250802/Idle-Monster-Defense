using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ElementShopBase : MonoBehaviour
{
    [SerializeField] TypeShopElement typeShopElement;
    [SerializeField] Text quantityCoinTxt;
    [SerializeField] Text nameTxt;
    [SerializeField] Button purchaseButton;
    private int quantityGoldBonus;

    Tweener tweener;
    private void Start()
    {
        initButton();
        initData();
    }
    private void initButton()
    {
        purchaseButton.onClick.AddListener(onClickPurchaseButton);
    }
    private void onClickPurchaseButton()
    {
        purchase();
    }
    private void purchase()
    {
        GameManager.Ins.AnimCoinController.ActionAnim(() =>
        {
            int currentGold = DataController.Ins.DataCurrentcy.GetGold();
            int newGold = currentGold + quantityGoldBonus;
            DataController.Ins.DataCurrentcy.SetGold(newGold);
            tweener?.Kill(true);
            tweener = DOTween.To(() => currentGold, _ =>
            {
                UILobby.Ins.SetTextQuantityGold(_);
            }, newGold, 1.2f);
        });
    }
    private void initData()
    {
        ShopElementInfo shopElementInfo = DataController.Ins.DataSOShop.GetShopElementOfType(typeShopElement);
        quantityCoinTxt.text = "x" + shopElementInfo.quantityBonus.ToString();
        nameTxt.text = shopElementInfo.name;
        quantityGoldBonus = shopElementInfo.quantityBonus;
    }
}
