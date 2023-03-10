using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LootController : MonoBehaviour//, IDisposable
{
    // private InteractiveObject[] _interactiveObjects;
    private SpeedBoost[] _speedBoostObjects;
    private AidKit[] _aidKitObjects;
    [SerializeField] private List<BonuseBase> actions;
    //prop
    private void Awake()
    {
        // _interactiveObjects = FindObjectsOfType<InteractiveObject>();
        _speedBoostObjects = FindObjectsOfType<SpeedBoost>();
        _aidKitObjects = FindObjectsOfType<AidKit>();

        // Task 1
        actions = new List<BonuseBase>(); // <BonuseBase> as <SpeedBoost> & <AidKit>

        for (var i = 0; i < _speedBoostObjects.Length; i++)
        {
            actions.Add(_speedBoostObjects[i]);
            // actions.Add(() => _interactiveObjects(i));
            //actions.Add(() => _interactiveObjects(i));
        }
        for (var i = 0; i < _aidKitObjects.Length; i++)
        {
            actions.Add(_aidKitObjects[i]);
        }
        //foreach (var action in actions)
        //{
        //    Debug.Log(action);
        //}
    }

    void Update()
    {
        for (int i = 0; i < actions.Count; i++)
        {
            if (actions[i] == null)
            {
                continue;
            }

            if (actions[i] != null)
            {
                var interactiveObject = actions[i].GetComponentInChildren<InteractiveObject>();
            }
            else
            {
                Debug.Log("LootController-actions[i] == null- " + actions[i]);
            }

            if (actions[i] != null && actions[i] is IFlay flay)
            {
                flay.Flay();
            }
            if (actions[i] != null && actions[i] is IFlicker flicker)
            {
                flicker.Flicker();
            }
        }

        //foreach (var a in actions)
        //{
        //    //  Debug.Log("LootController-before- " + a);

        //    var interactiveObject = a.gameObject.GetComponentInChildren<InteractiveObject>();
        //    //  Debug.Log("LootController-after- " + a);

        //    if (interactiveObject == null)
        //    {
        //        continue;
        //    }
        //    if (interactiveObject != null && interactiveObject is IFlay flay)
        //    {
        //        flay.Flay();
        //    }
        //    if (interactiveObject is IFlicker flicker)
        //    {
        //        flicker.Flicker();
        //    }
        //}
    }
    public void RemoveObjFromList(BonuseBase @base) // (int index)
    {
        actions.Remove(@base);
        //actions.Sort();
    }
    //public void Dispose()
    //{
    //    foreach (var o in _speedBoostObjects)
    //    {
    //        Destroy(o.gameObject);
    //    }
    //    foreach (var o in _aidKitObjects)
    //    {
    //        Destroy(o.gameObject, 1);
    //    }
    //    foreach (var o in actions)
    //    {
    //        RemoveObjFromList(o);
    //        Destroy(o.gameObject);
    //    }
    //    //foreach (var o in _interactiveObjects)
    //    //{
    //    //    Destroy(o.gameObject);
    //    //}
    //}
}

