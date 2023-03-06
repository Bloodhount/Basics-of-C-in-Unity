using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BonuseBase : MonoBehaviour
{
    [field: SerializeField] public int ScoreValue { get; protected set; } = 5;
    [field: SerializeField] public DisplayBonuses _displayBonuses { get; protected set; }
    public abstract void OnTriggerEnter(Collider collider);
}
