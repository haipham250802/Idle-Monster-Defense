using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private GameObject fxHit;
    float currentDamage;
    private void Start()
    {
        currentDamage = damage;
    }
    private void spawnFX()
    {
        GameObject fxHitClone = SimplePool.Spawn(fxHit, transform.position, Quaternion.identity);
    }
    public void SetDamageBonus(float damage)
    {
        this.damage = damage;
        currentDamage = damage;
    }
    public void MoveBullet(Transform target)
    {
        rb.velocity = new Vector2(0, 0);
        GameHelper.SetRotation(transform, target.position);
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase enemy = collision.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            SimplePool.Despawn(gameObject);
            enemy.RecieveDamage(currentDamage);
            spawnFX();
        }
    }
}
