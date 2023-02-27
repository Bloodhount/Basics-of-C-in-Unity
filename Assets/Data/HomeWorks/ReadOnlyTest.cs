using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadOnlyTest : MonoBehaviour
{
    public string inVal;
    [ReadOnly]
    public string outVal;
    [Space(140)]
    public string Val;
    private void Start()
    {
        outVal = "sgsdgsg";
    }
}
