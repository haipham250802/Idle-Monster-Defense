using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using TigerForge;
using Sirenix.OdinInspector;
public class EnemyBase : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SkeletonAnimation skeleton;

    [SerializeField] bool isAttack;
    [FoldoutGroup("Stat Enemy")]
    [SerializeField] float force;
    [FoldoutGroup("Stat Enemy")]
    [SerializeField] float timeAttack;
    [FoldoutGroup("Stat Enemy")]
    [SerializeField] float damage;
    [FoldoutGroup("Stat Enemy")]
    [SerializeField] float hp;
    [FoldoutGroup("Stat Enemy")]
    [SerializeField] int quantityCoinKillMe;
    [FoldoutGroup("Stat Enemy")]
    [SerializeField] int quantityGoldKillMe;
    [FoldoutGroup("Stat Enemy")]

    [SerializeField] ItemFallController itemFallController;
    HeatlhBar healthBar;
    float currentHp = 0;
    float time = 0;

    Spine.EventData eventData;
    ItemCurrencyBase item;
    private void OnEnable()
    {
        item = itemFallController.ItemFall();
    }
    protected virtual void Start()
    {
        time = 0;
        currentHp = hp;
    }
    protected virtual void Update()
    {
        if (GamePlayManager.Ins.isLose) return;
        time += Time.deltaTime;
        if (time > timeAttack)
        {
            Attack();
            time = 0;
        }
    }
    public void InitEnemy(E_TypeEnemy typeEnemy)
    {
        EnemyInfo enemyInfo = DataController.Ins.DataSOController.DataSOEnemy.GetEnemyOfType(typeEnemy);
        skeleton.skeletonDataAsset = null;
        skeleton.skeletonDataAsset = enemyInfo.skeleton;
        skeleton.Initialize(true);
        force = enemyInfo.speed;
        timeAttack = enemyInfo.timeAttack;
        damage = enemyInfo.Damage;
        hp = enemyInfo.HP;
        quantityCoinKillMe = enemyInfo.quantityCoinKill;
        quantityGoldKillMe = enemyInfo.quantityGoldKill;
    }
    public virtual void resetStat()
    {
        isAttack = false;
        currentHp = hp;
    }
    public virtual void Flip(float x)
    {
        transform.localScale = Vector3.one;
        if (transform.position.x > x)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
    public virtual void RecieveDamage(float damage)
    {
        if (healthBar == null)
        {
            GameObject healthBarClone = SimplePool.Spawn(GamePlayManager.Ins.HealthBar.gameObject, Vector3.zero, Quaternion.identity);
            healthBar = healthBarClone.GetComponent<HeatlhBar>();
            healthBar.InitPos(transform);
        }

        currentHp -= damage;
        healthBar.UpdateFillBar(currentHp, hp);
        if (currentHp <= 0)
        {
            fallItem();
            healthBar.ResetFill();
            SimplePool.Despawn(healthBar.gameObject);
            healthBar = null;

            GamePlayManager.Ins.SpawnEnemyController.ListEnemyCheckEndGame.Remove(this);
            if (GamePlayManager.Ins.SpawnEnemyController.checkCanNextWay())
                EventManager.EmitEvent(EventConstant.EV_NEXTWAY, 0);

            currentHp = 0;
            SimplePool.Despawn(gameObject);
        }
    }
    private void fallItem()
    {
        if (item is ItemCoin)
        {
            itemFallController.spawnItem(item, quantityCoinKillMe, transform);
        }
        else
        {
            itemFallController.spawnItem(item, quantityGoldKillMe, transform);
        }
    }
    protected virtual void Attack()
    {
        if (isAttack)
        {
            skeleton.AnimationState.SetAnimation(0, "Attack", false);
            eventData = skeleton.Skeleton.Data.FindEvent("OnDamaging");
            skeleton.AnimationState.Event += AnimationState_Event;
            skeleton.AnimationState.Complete += _ =>
            {
                if (_.Animation.Name == "Attack")
                {
                    skeleton.AnimationState.SetAnimation(0, "Idle", false);
                }
            };
        }
    }

    protected virtual void AnimationState_Event(Spine.TrackEntry trackEntry, Spine.Event e)
    {
        bool isMatch = (eventData == e.Data);
        if (isMatch)
        {
            Turrent.Ins.RecieveDamage(damage);
            skeleton.AnimationState.Event -= AnimationState_Event;
        }
    }

    public virtual void Move()
    {
        skeleton.AnimationState.SetAnimation(0, "Walk", true);
        rb.velocity = Vector2.zero;
        Vector2 direction = Turrent.Ins.transform.position - transform.position;
        direction.Normalize();
        rb.AddForce(direction * force, ForceMode2D.Impulse);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyHit"))
        {
            if (!isAttack)
                isAttack = true;
            rb.velocity = Vector2.zero;
        }
    }
}
