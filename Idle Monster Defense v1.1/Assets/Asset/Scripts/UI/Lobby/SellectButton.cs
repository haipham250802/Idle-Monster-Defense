using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class SellectButton : MonoBehaviour
{
    [SerializeField] Button buttonSellect;
    [SerializeField] Image BGSellect;
    [SerializeField] Image Icon;
    [SerializeField] Text txt;
    [SerializeField] Sprite iconSellect;
    [SerializeField] Sprite iconUnSellect;
    [SerializeField] bool isSellectFirst;
    [SerializeField] UISellectBottom uiSellectBottom;
    bool isSellect;
    bool isSellecting;
    private void Start()
    {
        initButton();
        if (isSellectFirst)
            TransitionState(E_StateSellect.SELLECT);
    }
    private void initButton()
    {
        buttonSellect.onClick.AddListener(onClickButtonSellect);
    }
    private void onClickButtonSellect()
    {
        if (isSellect && !isSellecting)
            TransitionState(E_StateSellect.UNSELLECT);
        else if(!isSellect)
            TransitionState(E_StateSellect.SELLECT);
    }
    public void TransitionState(E_StateSellect State)
    {
        switch (State)
        {
            case E_StateSellect.NONE:
                break;
            case E_StateSellect.SELLECT:
                enterStateSellect();
                break;
            case E_StateSellect.UNSELLECT:
                enterStateUnSellect();
                break;
            default:
                break;
        }

    }
    private void enterStateSellect()
    {
        if (uiSellectBottom.SellectButton != null && isSellecting == false)
            uiSellectBottom.SellectButton.TransitionState(E_StateSellect.UNSELLECT);
        uiSellectBottom.SellectButton = this;
        isSellecting = true;
        isSellect = true;
        BGSellect.sprite = iconSellect;
        Icon.transform.DOScale(Vector3.one * 1.3f, 0.25f);
        txt.transform.DOScale(Vector3.one * 1.2f, 0.1f);
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, 350);
    }
    private void enterStateUnSellect()
    {
        isSellect = false;
        isSellecting = false;
        BGSellect.sprite = iconUnSellect;
        Icon.transform.DOScale(Vector3.one * 0.8f, 0.1f);
        txt.transform.DOScale(Vector3.one * 0.8f, 0.1f);
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, 319);
    }
}
public enum E_StateSellect
{
    NONE = -1,
    SELLECT,
    UNSELLECT
}
