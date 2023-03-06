using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : BonuseBase
{
    public override void OnTriggerEnter(Collider other) 
    {
        this._displayBonuses = FindObjectOfType<DisplayBonuses>();
        PlayerMoveComtroller playerCtrlScript = other.attachedRigidbody.GetComponent<PlayerMoveComtroller>();
        if (playerCtrlScript)
        {
            playerCtrlScript.IncreaseSpeedBoostCount();
            _displayBonuses.Display(ScoreValue);
            Debug.LogWarning("class SpeedBoost. IncreaseSpeedBoostCount");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("class SpeedBoost. else " + other.name);
        }
    }
}
