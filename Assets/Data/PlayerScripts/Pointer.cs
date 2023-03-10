using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    public CoinsManager CoinsManager;
    public Coin ClosestLoot;
    public Text DistToCoinText;

    //private float DistanceToCoin;


    void Update()
    {
        ClosestLoot = CoinsManager.GetCoin(transform.position);
        Debug.DrawLine(transform.position, ClosestLoot.transform.position, Color.red);

        Arrow(transform.position, ClosestLoot.transform.position);

    }

    private void Arrow(Vector3 start, Vector3 end)
    {
        // Vector3 toTarget = _transformTarget.position - transform.position;
        Vector3 toTarget = end - start;
        Vector3 toTargetXZ = new Vector3(toTarget.x, 0f, toTarget.z);
        transform.rotation = Quaternion.LookRotation(toTargetXZ);
        float DistanceToCoin = toTargetXZ.magnitude - 1;
        DistToCoinText.text = DistanceToCoin.ToString("0.00");
        //DistToCoinText.text = toTargetXZ.magnitude.ToString("0.00");
    }
}
