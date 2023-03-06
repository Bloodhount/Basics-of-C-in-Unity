using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LootController : MonoBehaviour, IDisposable
{
    private InteractiveObject[] _interactiveObjects;
    private SpeedBoost[] _speedBoostObjects;
    private AidKit[] _aidKitObjects;
    [SerializeField] private List<BonuseBase> actions;
    //prop
    private void Awake()
    {
        _interactiveObjects = FindObjectsOfType<InteractiveObject>();
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
        foreach (var a in actions)
        {
            var interactiveObject = a.gameObject.GetComponentInChildren<InteractiveObject>();
            if (interactiveObject == null)
            {
                continue;
            }
            if (interactiveObject is IFlay flay)
            {
                flay.Flay();
            }
            if (interactiveObject is IFlicker flicker)
            {
                flicker.Flicker();
            }
        }

        //for (int i = 0; i < _interactiveObjects.Length; i++)
        //{
        //    var interactiveObject = _interactiveObjects[i];
        //    if (interactiveObject == null)
        //    {
        //        continue;
        //    }
        //    if (interactiveObject is IFlay flay)
        //    {
        //        flay.Flay();
        //    }
        //    if (interactiveObject is IFlicker flicker)
        //    {
        //        flicker.Flicker();
        //    }
        //}
    }

    public void Dispose()
    {
        foreach (var o in _speedBoostObjects)
        {
            Destroy(o.gameObject);
        }
        foreach (var o in _aidKitObjects)
        {
            Destroy(o.gameObject);
        }
        foreach (var o in actions)
        {
            Destroy(o.gameObject);
        }
        foreach (var o in _interactiveObjects)
        {
            Destroy(o.gameObject);
        }
    }
}

