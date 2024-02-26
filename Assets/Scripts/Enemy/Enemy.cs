using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : AliveObject
{
    [SerializeField] private Player _target;
    public Player Target => _target;

    public override void ApplyDamage(int damage)
    {
        base.ApplyDamage(damage);
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
