using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISellectBottom : MonoBehaviour
{
    [SerializeField] Button fightButton;
    [SerializeField] Button upgrade;
    [SerializeField] Button shop;

    public SellectButton SellectButton;
    private void Start()
    {
        initButton();
    }
    private void initButton()
    {
        fightButton.onClick.AddListener(onClickButtonFightButton);
        upgrade.onClick.AddListener(onClickButtonUpgradeButton);
        shop.onClick.AddListener(onClickButtonShop);
    }
    private void onClickButtonFightButton()
    {
        UILobby.Ins.TransitionSellect(TypeSellectLobby.FIGHT);
    }
    private void onClickButtonUpgradeButton()
    {
        UILobby.Ins.TransitionSellect(TypeSellectLobby.UPGRADE);
    }
    private void onClickButtonShop()
    {
        UILobby.Ins.TransitionSellect(TypeSellectLobby.SHOP);
    }
}
