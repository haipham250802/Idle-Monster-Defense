using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    float currentDamage;
    private void Start()
    {
        currentDamage = damage;
    }
    public void SetDamageBonus(float damageBonus)
    {
        currentDamage = damage;
        currentDamage += damageBonus;
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
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            SimplePool.Despawn(gameObject);
            enemy.RecieveDamage(currentDamage);
        }
    }
}
