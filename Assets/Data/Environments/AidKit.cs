using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GB;

public sealed class AidKit : BonuseBase// : MonoBehaviour
{
    [SerializeField] private int _healValue;
    //private DisplayBonuses _displayBonuses;
    public void OnTriggerEnter(Collider other)
    {
        LootController loot = FindObjectOfType<LootController>();
        _displayBonuses = FindObjectOfType<DisplayBonuses>();
        PlayerHealth playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            if (playerHealth.Health < playerHealth.MaxHealth)
            {
                _displayBonuses.Display(ScoreValue);
                playerHealth.Heal(_healValue);
                loot.RemoveObjFromList(gameObject.GetComponent<AidKit>());

                DestroyAidKit();
                Debug.LogWarning("class AidKit. _playerHealth.Heal");
            }
            else
            {
                Debug.LogWarning(" AidKit.Heal is max");
            }
        }
        else
        {
            Debug.Log("class AidKit. _playerHealth.Heal. else " + other.name);
        }
    }

    public void DestroyAidKit()
    {
        Destroy(gameObject, 0.1f);
    }
}
