using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFx : MonoBehaviour
{

    Tweener tweenMove;
    private void OnEnable()
    {
        StartCoroutine(IE_delayMoveCoin());
    }
    private IEnumerator IE_delayMoveCoin()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Transform posCoin = GameManager.Ins.AnimCoinController.PosCoin;
        DoMove(posCoin);
    }
    public void DoScale(Vector3 pos)
    {
        float duration = Random.Range(0.15f, 0.25f);
        float sizeRandom = Random.Range(0.2f, 0.3f);
        transform.DOScale(Vector3.one * sizeRandom, 0.15f)
            .SetEase(Ease.InOutBack)
            .SetUpdate(true);
        transform.DOMove(pos, 0.3f)
            .SetEase(Ease.InOutSine)
            .SetUpdate(true);
    }
    public void DoMove(Transform target)
    {
        float duration = Random.Range(0.4f, 0.5f);
        tweenMove?.Kill(true);
        tweenMove = transform.DOMove(target.position, duration)
            .SetEase(Ease.InOutSine)
            .SetUpdate(true)
            .OnComplete(() => DoScaleEnd());
    }
    public void DoScaleEnd()
    {
        transform.DOScale(Vector3.one * 0.32f, 0.25f)
            .SetEase(Ease.InOutBack)
            .SetUpdate(true)
            .OnComplete(() => SimplePool.Despawn(gameObject));
    }
}
