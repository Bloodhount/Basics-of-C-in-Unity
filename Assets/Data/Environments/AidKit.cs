using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GB;

public sealed class AidKit : MonoBehaviour
{
    [SerializeField] private int _healValue;
    private void OnTriggerEnter(Collider other)
    {
        //if (other)
        //{
        //    Debug.Log(other.name);
        //}
        PlayerHealth playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();
        //Debug.LogWarning(playerHealth.Health);
        if (playerHealth)
        {
            if (playerHealth.Health < playerHealth.MaxHealth)
            {
                playerHealth.Heal(_healValue); Debug.LogWarning("class AidKit. _playerHealth.Heal");
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.Log("class AidKit. _playerHealth.Heal. else " + other.name);
        }
    }
}
