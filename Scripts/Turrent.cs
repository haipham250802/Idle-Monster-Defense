using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class Turrent : MonoBehaviour
{
    #region avariable
    public static Turrent Ins;

    [FoldoutGroup("STAT")]
    [SerializeField] float rangeAttack;
    [FoldoutGroup("STAT")]
    [SerializeField] float rangeHitEnemy;
    [FoldoutGroup("STAT")]
    [SerializeField] float fireRate;
    [FoldoutGroup("STAT")]
    [SerializeField] float damage;
    [FoldoutGroup("STAT")]
    [SerializeField] float hp;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Bullet bulletSpawn;
    [SerializeField] HeatlhBar healthBar;

    public float Damage => damage;
    public float AttackSpeed => fireRate;
    public float HP => hp;
    public float RangeAttack => rangeAttack;


    float fireTimer = 0;
    float currentHp;
    bool isDead;
    bool isShowPopUpLose;

    public float DamageStart = 0;
    public float HpStart = 0;
    public float AttackSpeedStart = 0;
    public float RangeAttackStart = 0;

    public int indexUpradeDamage;
    public int indexUpradeHp;
    public int indexUpradeRangeAttack;
    public int indexUpradeAttackSpeed;
    #endregion

    private void OnValidate()
    {
        spriteRenderer.transform.localScale = new Vector3(rangeAttack, rangeAttack, rangeAttack);
    }
    private void Awake()
    {
        if (!Ins)
        {
            Ins = this;
        }
        else
            DestroyImmediate(gameObject);
    }
    public void OnStart()
    {
        initIndexStat();
        initValueStatBase();
        initStatTurrent();
        setUpValueStart();
        healthBar.UpdateFillBar(currentHp, hp);
        UIGamePlay.Ins.SetTextDamage(damage);
        UIGamePlay.Ins.SetTextHp(hp);
        UpdateRangeAttack();
    }

    private void Update()
    {
        if (!isDead)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer > fireRate)
            {
                Shoot();
            }
        }
    }
    public void UpdateRangeAttack()
    {
        spriteRenderer.transform.localScale = new Vector3(rangeAttack, rangeAttack, rangeAttack);
    }
    private void setUpValueStart()
    {
        fireTimer = 0;
        currentHp = hp;
    }
    private void initIndexStat()
    {
        indexUpradeDamage = DataController.Ins.DataPlayer.GetIndexUpgradeDamage();
        indexUpradeHp = DataController.Ins.DataPlayer.GetIndexUpgradeHP();
        indexUpradeAttackSpeed = DataController.Ins.DataPlayer.GetIndexUpgradeAttackSpeedPlayer();
        indexUpradeRangeAttack = DataController.Ins.DataPlayer.GetIndexUpgradeRangeAttackPlayer();
    }
    private void initValueStatBase()
    {
        DamageStart = DataController.Ins.DataSOController.DataSOPlayer.Player.Damage;
        HpStart = DataController.Ins.DataSOController.DataSOPlayer.Player.Hp;
        AttackSpeedStart = DataController.Ins.DataSOController.DataSOPlayer.Player.AttackSpeed;
        RangeAttackStart = DataController.Ins.DataSOController.DataSOPlayer.Player.RangeAttack;
    }
    private void initStatTurrent()
    {
        SetDamage(indexUpradeDamage);
        SetHp(indexUpradeHp);
        SetRangeAttack(indexUpradeRangeAttack);
        SetAttackSpeed(indexUpradeAttackSpeed);
    }
    public void SetDamage(int index, float initBase = 1.1f, float value = 0.5f)
    {
        damage = CalculateStat(DamageStart, initBase, index, value);
    }
    public float GetNewDamage()
    {
        return CalculateStat(DamageStart, 1.1f, indexUpradeDamage + 1, 0.5f);
    }
    public void SetHp(int index, float initBase = 8f, float value = 2f)
    {
        hp = CalculateStat(HpStart, initBase, index, value);
    }
    public float GetNewHp()
    {
        return CalculateStat(HpStart, 8f, indexUpradeHp + 1, 2f);
    }
    public void SetRangeAttack(int index, float initBase = 0.4f, float value = 0.5f)
    {
        rangeAttack = CalculateStat(RangeAttackStart, initBase, index, value);
    }
    public float GetNewRangeAttack()
    {
        return CalculateStat(RangeAttackStart, 0.4f, indexUpradeRangeAttack + 1, 0.5f);
    }
    public void SetAttackSpeed(int index, float value = 0.5f)
    {
        fireRate = CalculateAttackSpeed(AttackSpeedStart, index, value);
    }
    public float GetNewAttackSpeed()
    {
        return CalculateAttackSpeed(AttackSpeedStart, indexUpradeAttackSpeed + 1, 0.5f);
    }
    public float CalculateAttackSpeed(float start, int index, float value)
    {
        float result = start - ((start * index * value) / 5);
        return result;
    }
    public float CalculateStat(float start, float init, int index, float value)
    {
        float result = start + index * (2 * init + value * (index + 1) - 2 * value) / 5;
        return result;
    }
    public void RecieveDamage(float attack)
    {
        currentHp -= attack;
        healthBar.UpdateFillBar(currentHp, hp);
        if (currentHp < 0)
        {
            currentHp = 0;
            isDead = true;
            isShowPopUpLose = true;
            GamePlayManager.Ins.isLose = true;
            if (!GamePlayManager.Ins.isShowPopUpLose)
            {
                GamePlayManager.Ins.isShowPopUpLose = true;
              //  UIShowPopUp.Ins.ShowPopUpLose();
            }
        }
    }
    private void Shoot()
    {
        Enemy enemy = calculateEnmeyNearest();
        if (enemy != null)
        {
            GameObject bullet = SimplePool.Spawn(bulletSpawn.gameObject, Vector3.zero, Quaternion.identity);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Bullet>().SetDamageBonus(damage);
            bullet.GetComponent<Bullet>().MoveBullet(enemy.transform);
            fireTimer = 0;
        }
    }
    private Enemy calculateEnmeyNearest()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, rangeAttack);
        List<Enemy> closestEnemies = new List<Enemy>();

        foreach (Collider2D enemy in enemies)
        {
            Enemy enemyCache = enemy.GetComponent<Enemy>();
            if (enemyCache)
            {
                closestEnemies.Add(enemyCache);
            }
        }
        closestEnemies.Sort((a, b) => GetDistance2(transform.position, a.transform.position).CompareTo(GetDistance2(transform.position, b.transform.position)));
        if (closestEnemies.Count > 0)
            return closestEnemies[0];
        return null;
    }
    private float GetDistance2(Vector2 a, Vector2 b)
    {
        return (a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeAttack);
        Gizmos.DrawWireSphere(transform.position, rangeHitEnemy);
    }
}
