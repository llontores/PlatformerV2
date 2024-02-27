using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour 
{
    [SerializeField] private PlayerControl _control;
    [SerializeField] private LayerMask _enemiesMask;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange;
    [SerializeField] private int _damage;

    private void OnEnable()
    {
        _control.AttackButtonPressed += Attack;
    }

    private void OnDisable()
    {
        _control.AttackButtonPressed -= Attack;
    }

    private void Attack()
    {

        Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemiesMask);

        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<Enemy>().ApplyDamage(_damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;

        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}
