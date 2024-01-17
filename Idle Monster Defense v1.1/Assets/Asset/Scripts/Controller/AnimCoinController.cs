using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AnimCoinController : MonoBehaviour
{
    [SerializeField] private Transform posCoin;
    [SerializeField] private CoinFx coinPrefabs;
    [SerializeField] private int minQuantityCoinFX;
    [SerializeField] private int maxQuantityCoinFX;
    private List<CoinFx> listCoinFx = new();
    private List<CoinFx> listCoinFxFly = new();

    public Transform PosCoin => posCoin;
    public void ActionAnim(System.Action callback = null)
    {
        StartCoroutine(IE_DelayActiveCoin(callback));
    }
    IEnumerator IE_DelayActiveCoin(System.Action callback)
    {
        listCoinFx = new();
        int rand = Random.Range(minQuantityCoinFX, maxQuantityCoinFX);
        Vector3 startPosCoin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        for (int i = 0; i < rand; i++)
        {
            GameObject coinSpawn = SimplePool.Spawn(coinPrefabs.gameObject, Vector3.zero, Quaternion.identity);
            CoinFx coinFx = coinSpawn.GetComponent<CoinFx>();
            coinSpawn.transform.localScale = Vector3.zero;
            coinSpawn.transform.SetParent(transform, false);
            coinSpawn.transform.position = startPosCoin;
            Vector3 newPos = new Vector3(randomPosCoin(startPosCoin).x, randomPosCoin(startPosCoin).y, 0);
            coinFx.DoScale(newPos);
            if (!listCoinFx.Contains(coinFx))
                listCoinFx.Add(coinFx);
            yield return new WaitForSecondsRealtime(Random.Range(0.02f, 0.05f));
        }
        yield return new WaitForSecondsRealtime(0.3f);
        callback?.Invoke();
    }
    private Vector3 randomPosCoin(Vector3 PosCoin)
    {
        Vector3 thePosRand = Random.insideUnitCircle * 1.2f;
        Vector3 newPos = PosCoin + thePosRand;
        return newPos;
    }
}
