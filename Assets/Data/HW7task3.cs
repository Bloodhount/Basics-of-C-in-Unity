using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW7task3 : MonoBehaviour
{
    void Start()
    {
        var a = new[] { 11, 11, 23, 23, 23, 23, 23, 44, 88, 88 };
        var h = new Dictionary<int, int>();
      //  MyExtensions.FindingLengthtOfString(a, h);
    }


}
public static class MyExtensions2
{
    public static void CalculateCounNumInDictionary(this int[] a, Dictionary<int, int> h)
    {
        foreach (var i in a)
        {
            int res;
            if (h.TryGetValue(i, out res))
                h[i] += 1;
            else
                h.Add(i, 1);
        }
        System.Diagnostics.Trace.WriteLine("count: " + h.Count);
        foreach (var kv in h)
            Debug.Log(kv.Key + " (" + kv.Value + ")");
    }
}
