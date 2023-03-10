using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HW7task2 : MonoBehaviour
{
    void Start()
    {   // home work 8
        //Debug.Log("1 " + Application.dataPath);
        //Debug.Log("2 " + Application.persistentDataPath); // часто этот путь исп.для хранения сейвов
        //Debug.Log("3 " + Application.streamingAssetsPath); // файлы подкачки/временные файлы
        //Debug.Log("4 " + Application.temporaryCachePath);

        var savePath = Path.Combine(Application.dataPath, "sAvE.txt");
       // Debug.LogWarning(savePath);
        Save(savePath, "some save data...");

       // Debug.Log(Load(savePath));
        return;

        // home work 7
      //  string str1 = "dfsdfgwe32rqw24оривr";
        // MyExtensions.FindingLengthtOfString(str1);
    }
    public string Load(string savePath = null)
    {
        var result = "";
        using (var sr = new StreamReader(savePath))
        {
            while (!sr.EndOfStream)
            {
                result += sr.ReadLine();
            }
            return result;
        }
    }
    private static void Save(string savePath, string data)
    {
        using (var sw = new StreamWriter(savePath))
        {
            sw.WriteLine(data);
        }
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
