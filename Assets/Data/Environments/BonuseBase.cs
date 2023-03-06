using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BonuseBase : MonoBehaviour
{
    [field: SerializeField] public int ScoreValue { get; protected set; } = 5;
    public DisplayBonuses _displayBonuses { get; protected set; }
    //  public UnityEvent EventOnBonusCollected;
    public abstract void OnTriggerEnter(Collider collider);
}
