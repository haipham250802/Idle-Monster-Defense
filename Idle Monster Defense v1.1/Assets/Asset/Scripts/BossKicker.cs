using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKicker : EnemyBase
{
    public override void Flip(float x)
    {
        base.Flip(x);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override void Move()
    {
        base.Move();
    }

    public override void RecieveDamage(float damage)
    {
        base.RecieveDamage(damage);
    }

    public override void resetStat()
    {
        base.resetStat();
    }

    public override string ToString()
    {
        return base.ToString();
    }

    protected override void AnimationState_Event(TrackEntry trackEntry, Spine.Event e)
    {
        base.AnimationState_Event(trackEntry, e);
    }

    protected override void Attack()
    {
        base.Attack();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
