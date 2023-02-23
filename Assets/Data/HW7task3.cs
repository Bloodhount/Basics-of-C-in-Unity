using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW7task3 : MonoBehaviour
{
    void Start()
    {
        var numbersList1 = new[] { 11, 11, 23, 23, 33, 33, 23, 23, 44, 88, 88, 88 };
        var result = new Dictionary<int, int>();
        var list2 = new List<int>();

        MyExtensions2.CalculateCounNumInDictionary(numbersList1, result);
    }


}
public static class MyExtensions2
{
    public static void CalculateCounNumInDictionary(this int[] targetList, Dictionary<int, int> r)
    {
        foreach (var i in targetList)
        {
            int res;
            if (r.TryGetValue(i, out res))
                r[i] += 1;
            else
                r.Add(i, 1);
        }
        Debug.Log("number of original values: " + r.Count);
        foreach (var kv in r)
            Debug.Log(kv.Key + " (" + kv.Value + ")");
    }
}
