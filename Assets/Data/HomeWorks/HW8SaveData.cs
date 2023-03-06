using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class HW8SaveData : MonoBehaviour
{
    private JsonData<SaveData> _jsonData = new JsonData<SaveData>();
    private SaveData _saveData = new SaveData() { Name = "...", Position = Vector3.zero };
    string path = null;
    private void Start()
    {
        _saveData.Name = gameObject.name;
        _saveData.Position = GetComponent<Transform>().position;
        if (gameObject.activeSelf)
        {
            _saveData.IsEnabled = true;
        }

        // path = Path.Combine(Application.dataPath, $"JsonSaveData.xml");
        path = Path.Combine(Application.dataPath, $"AllSaves/JsonSaveData{name}.xml");
        _jsonData.Save(_saveData, path);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            var save = _jsonData.Load(path);
            transform.position = save.Position;
            Debug.LogWarning(save);
        }
    }
}

[Serializable]
public sealed class SaveData
{
    public string Name;
    public Vector3Serializable Position;
    public bool IsEnabled;

    public override string ToString() => $"Name {Name} , Position {Position} , status {IsEnabled}";
}

[Serializable]
public struct Vector3Serializable
{
    public float X;
    public float Y;
    public float Z;
    public Vector3Serializable(float valueX, float valueY, float valueZ)
    {
        X = valueX;
        Y = valueY;
        Z = valueZ;
    }
    public static implicit operator Vector3(Vector3Serializable value)
    {
        return new Vector3(value.X, value.Y, value.Z);
    }
    public static implicit operator Vector3Serializable(Vector3 value)
    {
        return new Vector3Serializable(value.x, value.y, value.z);
    }
    public override string ToString() => $" (X = {X} Y = {Y} Z = {Z})";

}

// JSON format
public class JsonData<T> : IData<T>
{
    public void Save(T data, string path = null)
    {
        var str = JsonUtility.ToJson(data);

        File.WriteAllText(path, str);
    }
    public T Load(string path = null)
    {
        var str = File.ReadAllText(path);
        return JsonUtility.FromJson<T>(str);
    }
}

public interface IData<T>
{
    void Save(T data, string path = null);
    T Load(string path = null);
}