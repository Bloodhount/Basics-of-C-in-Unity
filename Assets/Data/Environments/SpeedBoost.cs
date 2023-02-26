using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
   // [SerializeField] private int _addBoostCountValue;
    private void OnTriggerEnter(Collider other)
    {
        PlayerMoveComtroller playerCtrlScript = other.attachedRigidbody.GetComponent<PlayerMoveComtroller>();
        //Debug.LogWarning();
        if (playerCtrlScript)
        {         
                playerCtrlScript.IncreaseSpeedBoostCount(); Debug.LogWarning("class SpeedBoost. IncreaseSpeedBoostCount");
                Destroy(gameObject);            
        }
        else
        {
            Debug.Log("class SpeedBoost. else " + other.name);
        }
    }
}
