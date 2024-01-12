using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Sirenix.OdinInspector;
public class UILobby : MonoBehaviour
{
    public static UILobby Ins;
    [SerializeField] TypeSellectLobby typeSellectOnStart;
    [SerializeField] float timeTransition;
    [SerializeField] UIUpgrade uiUpGrade;
    [FoldoutGroup("Button Sellect")]
    [SerializeField] Button fightButton;
    [FoldoutGroup("Button Sellect")]
    [SerializeField] Button upgradeButton;
    [FoldoutGroup("Button Sellect")]
    [SerializeField] Button shopButton;
    [SerializeField] Transform content;
    [SerializeField] Text quantityGoldTxt;
    [SerializeField] Text quantityGemTxt;
    public UIUpgrade UIUpgrade => uiUpGrade;

    private void Awake()
    {
        if (Ins == null)
            Ins = this;
        else
            Destroy(gameObject);
    }
    public void Onstart()
    {
        initButton();
        initView();
        TransitionSellect(typeSellectOnStart);
        UIUpgrade.OnStart();
    }

    private void initView()
    {
        int quantityGold = DataController.Ins.DataCurrentcy.GetGold();
        int quantityGem = DataController.Ins.DataCurrentcy.GetGem();

        quantityGoldTxt.text = quantityGold.ToString();
        quantityGemTxt.text = quantityGem.ToString();
    }
    private void initButton()
    {
        fightButton.onClick.AddListener(onClickFightButton);
    }
    private void onClickFightButton()
    {
        SceneManager.LoadScene(1);
    }
    public void TransitionSellect(TypeSellectLobby type)
    {
        switch (type)
        {
            case TypeSellectLobby.NONE:
                break;
            case TypeSellectLobby.FIGHT:
                transitionFight();
                break;
            case TypeSellectLobby.UPGRADE:
                transitionUpgrade();
                break;
            case TypeSellectLobby.SHOP:
                transitionShop();
                break;
            default:
                break;
        }
    }
    public void transitionFight()
    {
        content.transform.DOLocalMoveX(0, timeTransition);
    }
    public void transitionUpgrade()
    {
        content.transform.DOLocalMoveX(920, timeTransition);
    }
    public void transitionShop()
    {
        content.transform.DOLocalMoveX(-920, timeTransition);
    }
}

