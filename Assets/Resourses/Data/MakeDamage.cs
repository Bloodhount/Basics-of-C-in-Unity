using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GB;

public class MakeDamage : MonoBehaviour
{
    [SerializeField] private int _damageValue = 1;
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<PlayerHealth>())
            {
                collision.rigidbody.GetComponent<PlayerHealth>().TakeDamage(_damageValue);
            }
        }
    }
}
