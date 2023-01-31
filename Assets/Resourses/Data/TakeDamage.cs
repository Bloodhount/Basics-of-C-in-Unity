using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GB;

public sealed class TakeDamage : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<AidKit>())
            {
                _enemyHealth.TakeDamage(1);
            }
        }
    }
}
