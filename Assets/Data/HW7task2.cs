using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW7task2 : MonoBehaviour
{
    void Start()
    {
        string str1 = "dfsdfgwe32rqw24оривr";
        MyExtensions.FindingLengthtOfString(str1);
    }


}
public static class MyExtensions
{
    public static void FindingLengthtOfString(this string self)
    {
        int count = 0;
        foreach (var i in self)
        {
            count++;
        }
        Debug.Log("string length: " + count);
    }

    //public static void FindingLengthtOfString(this int[] a, Dictionary<int, int> h)
    //{
    //    foreach (var i in a)
    //    {
    //        int res;
    //        if (h.TryGetValue(i, out res))
    //            h[i] += 1;
    //        else
    //            h.Add(i, 1);
    //    }
    //    System.Diagnostics.Trace.WriteLine("count: " + h.Count);
    //    foreach (var kv in h)
    //        System.Diagnostics.Trace.WriteLine(kv.Key + " (" + kv.Value + ")");
    //}
}
