using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UpgradeBase : MonoBehaviour
{
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Image iconButton;
    [SerializeField] protected Text currentValue;
    [SerializeField] protected Text newValue;
    [SerializeField] protected Text coinUpgrade;

    public virtual void OnStart()
    {
        initButton();
    }
    private void initButton()
    {
        upgradeButton.onClick.AddListener(onClickButtonUpgrade);
    }
    private void onClickButtonUpgrade()
    {
        upgrade();
    }
    protected virtual void initViewInfo(float currentValue, float newValue, int coinUpgrade)
    {
        this.currentValue.text = currentValue.ToString();
        this.newValue.text = newValue.ToString();
        this.coinUpgrade.text = coinUpgrade.ToString();
    }
    protected abstract void upgrade();
}
