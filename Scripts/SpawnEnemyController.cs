using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TigerForge;

public class SpawnEnemyController : MonoBehaviour
{
    [SerializeField] int indexWay;
    [SerializeField] float timeNextWay;
    [SerializeField] List<WayInfo> listWay;
    [SerializeField] List<EnemyBase> listEnemyCheckEndGame;

    public List<EnemyBase> ListEnemyCheckEndGame => listEnemyCheckEndGame;
    private void Start()
    {
        indexWay = 0;
        SpawnEnemy(listWay[indexWay]);
        EventManager.StartListening(EventConstant.EV_NEXTWAY, NextWay);
    }
    public void SpawnEnemy(WayInfo wayInfo)
    {
        listEnemyCheckEndGame = new();
        float timeCoolDown = 0;
        DOTween.To(() => 0f, _ =>
        {
            if (_ > timeCoolDown)
            {
                int randTypeEnemy = Random.Range(0, wayInfo.listTypeEnemy.Count);
                GameObject enemyClone = SimplePool.Spawn(wayInfo.enemy.gameObject, Vector3.zero, Quaternion.identity);
                EnemyBase enemy = enemyClone.GetComponent<EnemyBase>();
                enemy.transform.position = GameHelper.NewPosition(Turrent.Ins.transform);
                enemy.Flip(Turrent.Ins.transform.position.x);
                enemy.InitEnemy(wayInfo.listTypeEnemy[randTypeEnemy]);
                enemy.resetStat();
                enemy.Move();
                timeCoolDown += 1;
                listEnemyCheckEndGame.Add(enemy);
            }
        }, wayInfo.quantityEnemy, wayInfo.time)
            .SetEase(wayInfo.curve);
    }
    public bool checkCanNextWay()
    {
        if (listEnemyCheckEndGame.Count == 0)
            return true;
        return false;
    }
    private void NextWay()
    {
        indexWay++;
        if (indexWay < listWay.Count)
        {
            StartCoroutine(IE_DelayNextWay());
        }
        else
        {
            StartCoroutine(IE_delayShowWin());
        }
    }
    IEnumerator IE_DelayNextWay()
    {
        yield return new WaitForSeconds(timeNextWay);
        SpawnEnemy(listWay[indexWay]);
        Debug.Log("Next Way");
    }
    IEnumerator IE_delayShowWin()
    {
        yield return new WaitForSeconds(1f);
      //  UIShowPopUp.Ins.ShowPopUpWin();
    }
    private void OnDisable()
    {
        EventManager.StopListening(EventConstant.EV_NEXTWAY, NextWay);
    }
}
[System.Serializable]
public class WayInfo
{
    public List<E_TypeEnemy> listTypeEnemy;
    public EnemyBase enemy;
    public AnimationCurve curve;
    public int quantityEnemy;
    public float time;
}
