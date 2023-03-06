using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : BonuseBase
{
    public override void OnTriggerEnter(Collider other)
    {
        LootController loot = FindObjectOfType<LootController>();
        this._displayBonuses = FindObjectOfType<DisplayBonuses>();
        PlayerMoveComtroller playerCtrlScript = other.attachedRigidbody.GetComponent<PlayerMoveComtroller>();
        if (playerCtrlScript)
        {
            playerCtrlScript.IncreaseSpeedBoostCount();
            _displayBonuses.Display(ScoreValue);
            Debug.LogWarning("class SpeedBoost. IncreaseSpeedBoostCount");
            loot.RemoveObjFromList(gameObject.GetComponent<SpeedBoost>());
            Destroy(gameObject);
            // EventOnBonusCollected.AddListener();
            // EventOnBonusCollected.Invoke();
        }
        else
        {
            Debug.Log("class SpeedBoost. else " + other.name);
        }
    }
}
