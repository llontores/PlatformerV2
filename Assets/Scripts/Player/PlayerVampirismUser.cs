using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVampirismUser : MonoBehaviour
{
    [SerializeField] private PlayerControl _control;
    [SerializeField] private LayerMask _enemiesMask;
    [SerializeField] private float _vampirismRange;
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _control.VampirismButtonPressed += DetectEnemies;
    }

    private void OnDisable()
    {
        _control.VampirismButtonPressed -= DetectEnemies;
    }
    private void DetectEnemies()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _vampirismRange, _enemiesMask);

        if (enemies != null)
            StartCoroutine(VampirismProcess(enemies[0].GetComponent<Enemy>()));
    }

    private IEnumerator VampirismProcess(Enemy enemy)
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (enemy.Health >= 0)
        {
            enemy.ApplyDamage(_damage);
            _player.RecoverHealth(_damage);

            yield return delay;
        }
    }
}
