using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;
public class PopUpWin : PopUpBase
{
    [SerializeField] private Button claimBonusRWButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button homeButton;
    [SerializeField] private Text quantityGoldTxt;
    [SerializeField] private Image iconButton;

    private void Start()
    {
        initQuantityGold();
        initButton();
    }
    private void initButton()
    {
        claimBonusRWButton.onClick.AddListener(onClickButtonClaimBonusRWButton);
    }
    private void onClickButtonNext()
    {
        nextButton.onClick.AddListener(onClickButtonNext);
    }
    private void onClickButtonClaimBonusRWButton()
    {
        claimBonusRWButton.interactable = false;
        iconButton.color = Color.gray;
        int currentGold = GamePlayManager.Ins.GetQuantityGold();
        int newGold = currentGold * 2;
        DOTween.To(() => currentGold, _ =>
        {
            quantityGoldTxt.text = _.ToString();
        }, newGold, 0.3f);
    }
    private void onClickButtonHome()
    {
        SceneManager.LoadScene(1);
    }
    private void initQuantityGold()
    {
        quantityGoldTxt.text = GamePlayManager.Ins.GetQuantityGold().ToString();
    }
}
