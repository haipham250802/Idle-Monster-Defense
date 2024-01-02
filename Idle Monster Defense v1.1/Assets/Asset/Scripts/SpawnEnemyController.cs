using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TigerForge;

public class SpawnEnemyController : MonoBehaviour
{
    [SerializeField] int indexWay;
    [SerializeField] List<WayInfo> listWay;
    [SerializeField] List<EnemyBase> listEnemy;

    public List<EnemyBase> ListEnemyBase => listEnemy;
    private void Start()
    {
        indexWay = 0;
        SpawnEnemy(listWay[indexWay]);
        EventManager.StartListening(EventConstant.EV_NEXTWAY, NextWay);
    }
    public void SpawnEnemy(WayInfo wayInfo)
    {
        listEnemy = new();
        float timeCoolDown = 0;
        DOTween.To(() => 0f, _ =>
        {
            if (_ > timeCoolDown)
            {
                GameObject enemyClone = SimplePool.Spawn(wayInfo.enemy.gameObject, Vector3.zero, Quaternion.identity);
                EnemyBase enemy = enemyClone.GetComponent<EnemyBase>();
                enemy.transform.position = GameHelper.NewPosition(Turrent.Ins.transform);
                enemy.Flip(Turrent.Ins.transform.position.x);
                enemy.resetStat();
                enemy.Move();
                timeCoolDown += 1;
                listEnemy.Add(enemy);
            }
        }, wayInfo.quantityEnemy, wayInfo.time)
            .SetEase(wayInfo.curve);
    }
    public bool checkCanNextWay()
    {
        if (listEnemy.Count == 0)
            return true;
        return false;
    }
    private void NextWay()
    {
        indexWay++;
        if (indexWay < listWay.Count)
        {
            SpawnEnemy(listWay[indexWay]);
            Debug.Log("Next Way");
        }
        else
        {
            StartCoroutine(IE_delayShowWin());
        }
    }
    IEnumerator IE_delayShowWin()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Win");
    }
    private void OnDisable()
    {
        EventManager.StopListening(EventConstant.EV_NEXTWAY, NextWay);
    }
}
[System.Serializable]
public class WayInfo
{
    public EnemyBase enemy;
    public AnimationCurve curve;
    public int quantityEnemy;
    public float time;
}
