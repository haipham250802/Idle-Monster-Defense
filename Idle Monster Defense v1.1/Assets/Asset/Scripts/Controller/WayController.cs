using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayController : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] AnimationCurve curve;
    [SerializeField] private int quantityEnemy;
    [SerializeField] private float time;

    float timeCoolDown = 0;
    private void Start()
    {
        timeCoolDown = 0;
     //   spawnEnemy();
    }
   /* private void spawnEnemy()
    {
        DOTween.To(() => 0f, _ =>
        {
            if (_ > timeCoolDown)
            {
                GameObject enemyClone = SimplePool.Spawn(enemy.gameObject, Vector3.zero, Quaternion.identity);
                enemyClone.transform.position = GameHelper.NewPosition(Turrent.Ins.transform);
                enemyClone.GetComponent<EnemyBase>().Flip(Turrent.Ins.transform.position.x);
                enemyClone.GetComponent<EnemyBase>().resetStat();
                enemyClone.GetComponent<EnemyBase>().Move();
                timeCoolDown += 1;
            }
        }, quantityEnemy, time)
            .SetEase(curve);
    }
*/
}
