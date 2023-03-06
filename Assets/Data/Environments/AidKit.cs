using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GB;

public sealed class AidKit : BonuseBase// : MonoBehaviour
{
    [SerializeField] private int _healValue;
    //private DisplayBonuses _displayBonuses;
    public override void OnTriggerEnter(Collider other)
    {
        _displayBonuses = FindObjectOfType<DisplayBonuses>();
        PlayerHealth playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            if (playerHealth.Health < playerHealth.MaxHealth)
            {
                _displayBonuses.Display(ScoreValue);
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
