using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PopUpLose : PopUpBase
{
    [SerializeField] Button claimX2;
    [SerializeField] Button replayButton;
    [SerializeField] Button homeButton;
    [SerializeField] Image iconButton;
    [SerializeField] Text quantityCoin;

    private void Start()
    {
        initButton();
        initQuantityGold();
    }
    private void initButton()
    {
        replayButton.onClick.AddListener(onClickButtonReplay);
        homeButton.onClick.AddListener(onClickButtonHome);
        claimX2.onClick.AddListener(onClickButtonClaimX2);
    }
    private void onClickButtonClaimX2()
    {
        claimX2.interactable = false;
        iconButton.color = Color.gray;
        int currentGold = GamePlayManager.Ins.GetQuantityGold();
        int newGold = currentGold * 2;
        DOTween.To(() => currentGold, _ =>
        {
            quantityCoin.text = _.ToString();
        }, newGold, 0.3f);
    }
    private void onClickButtonReplay()
    {
        SceneManager.LoadScene(1);
    }
    private void onClickButtonHome()
    {

    }
    private void initQuantityGold()
    {
        quantityCoin.text = GamePlayManager.Ins.GetQuantityGold().ToString();
    }
}
