using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class NotiBossIsComing : MonoBehaviour
{
    [SerializeField] Image fill;
    public void OnNotiBoss()
    {
        DOTween.To(() => 0f, _ =>
        {
            fill.fillAmount = _;
        }, 1, 1f)
            .OnComplete(() => {
                StartCoroutine(IE_delayHidden());
            });
    }
    IEnumerator IE_delayHidden()
    {
        yield return new WaitForSeconds(2);
        fill.fillAmount = 0;
    }
}
