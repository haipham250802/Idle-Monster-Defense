using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class Turrent : MonoBehaviour
{
    [FoldoutGroup("STAT")]
    [SerializeField] float rangeAttack;
    [FoldoutGroup("STAT")]
    [SerializeField] float rangeHitEnemy;
    [FoldoutGroup("STAT")]
    [SerializeField] float fireRate;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Bullet bulletSpawn;
    [SerializeField] HeatlhBar healthBar;

    [FoldoutGroup("STAT")]
    [SerializeField] float damageBonus;
    [FoldoutGroup("STAT")]
    [SerializeField] int hp;

    public static Turrent Ins;
    float fireTimer = 0;
    float currentHp;

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
    private void Start()
    {
        fireTimer = 0;
        currentHp = hp;
        healthBar.UpdateFillBar(currentHp, hp);
    }
    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > fireRate)
        {
            Shoot();
        }
    }
    public void RecieveDamage(int attack)
    {
        currentHp -= attack;
        healthBar.UpdateFillBar(currentHp, hp);
        if (currentHp < 0)
        {
            currentHp = 0;
        }
    }
    private void Shoot()
    {
        Enemy enemy = calculateEnmeyNearest();
        if (enemy != null)
        {
            GameObject bullet = SimplePool.Spawn(bulletSpawn.gameObject,Vector3.zero,Quaternion.identity);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Bullet>().SetDamageBonus(damageBonus);
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
