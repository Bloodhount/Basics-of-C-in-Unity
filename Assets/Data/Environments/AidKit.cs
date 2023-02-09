using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GB;

public sealed class AidKit : MonoBehaviour
{
    [SerializeField] private int _healValue;
    private void OnTriggerEnter(Collider other)
    {
        if (other)
        {
            Debug.Log(other.name);
        }
        PlayerHealth playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.Heal(_healValue);
            Destroy(gameObject);
        }
    }
}