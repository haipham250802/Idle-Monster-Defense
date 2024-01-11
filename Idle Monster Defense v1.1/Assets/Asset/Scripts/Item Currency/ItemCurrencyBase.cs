using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public abstract class ItemCurrencyBase : MonoBehaviour
{
    [SerializeField] SpriteRenderer icon;
    [SerializeField] TextMeshPro quantityTxt;
    public int Quantity;
    private void OnEnable()
    {
        quantityTxt.gameObject.SetActive(false);
        StartCoroutine(IE_delayDespawn());
    }
    IEnumerator IE_delayDespawn()
    {
        yield return new WaitForSeconds(1f);
        despawn();
    }
    private void despawn()
    {
        initText();
        initData();
        initView();
        quantityTxt.gameObject.SetActive(true);
        transform.DOMoveY(transform.position.y + 0.25f, 1f);
        DOTween.To(() => 1f, _ =>
        {
            Color color = icon.color;
            color.a = _;
            icon.color = color;
            quantityTxt.color = color;
        }, 0f, 1f)
            .OnComplete(() =>
            {
                
            });
    }
    public void initText()
    {
        quantityTxt.text = Quantity.ToString();
    }
    protected abstract void initData();
    protected abstract void initView();
}
