using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GB;

public sealed class TakeDamage : MonoBehaviour
{
   // [SerializeField] 
    private EnemyHealth _enemyHealth;
   // [SerializeField] 
    private PlayerHealth _playerHealth;
    void Start()
    {
        // _enemyHealth = GetComponent<EnemyHealth>();
        //_playerHealth = GetComponent<PlayerHealth>();
        if (GetComponent<EnemyHealth>())
        {
            _enemyHealth = GetComponent<EnemyHealth>();
        }
        if (GetComponent<PlayerHealth>())
        {
            _playerHealth = GetComponent<PlayerHealth>();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {// 2? ??????? ??????? ??????... ?? ???? ??? ??????????
            //if (collision.rigidbody.GetComponent<AidKit>())
            //{
            //    _playerHealth.Heal(2);Debug.LogWarning("class TakeDamage. _playerHealth.Heal(2)");
            //}
            if (collision.rigidbody.GetComponent<PlayerHealth>())
            {
                _enemyHealth.TakeDamage(1); Debug.LogError(collision.gameObject.name);
            }
            if (collision.rigidbody.GetComponent<EnemyHealth>())
            {
                _playerHealth.TakeDamage(1);Debug.LogError(collision.gameObject.name);
            }
        }
    }
}
