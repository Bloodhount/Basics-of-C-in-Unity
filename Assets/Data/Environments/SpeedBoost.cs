using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : BonuseBase
{
    public void OnTriggerEnter(Collider other)
    {
        LootController loot = FindObjectOfType<LootController>();
        _displayBonuses = FindObjectOfType<DisplayBonuses>();
        PlayerMoveComtroller playerCtrlScript = other.attachedRigidbody.GetComponent<PlayerMoveComtroller>();
        if (playerCtrlScript)
        {
            _displayBonuses.Display(ScoreValue);
            playerCtrlScript.IncreaseSpeedBoostCount();
            loot.RemoveObjFromList(gameObject.GetComponent<SpeedBoost>());
            DestroySpeedBoost();
            // EventOnBonusCollected.AddListener();
            // EventOnBonusCollected.Invoke();
        }
        else
        {
            Debug.Log("class SpeedBoost. else " + other.name);
        }
    }

    private void DestroySpeedBoost()
    {
        Destroy(gameObject, 0.1f);
    }
}
