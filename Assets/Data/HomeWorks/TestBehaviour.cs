using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public sealed class TestBehaviour : MonoBehaviour
{   // DontDestroyOnLoad  DestroyObject  DestroyImmediate  Destroy
    public int count = 10;
    public int offset = 1;
    public GameObject obj;
    public float Test;

    private Transform _root;

    private void Start()
    {
      //  CreateObj();
    }
    public void CreateObj()
    {
        _root = new GameObject("Root").transform;
        for (int i = 1; i <= count; i++)
        {
            Instantiate(obj, new Vector3(0, offset * i, 0), Quaternion.identity, _root);
        }
    }
    public void AddComponent()
    {
        obj.AddComponent<Rigidbody>();
        obj.AddComponent<BoxCollider>();
        gameObject.AddComponent<MeshRenderer>();
    }
    public void RemoveComponent()
    {
        DestroyImmediate(GetComponent<Rigidbody>());
        DestroyImmediate(GetComponent<MeshRenderer>());
        DestroyImmediate(GetComponent<BoxCollider>());
    }
    //public void OnGUI()
    //{
    //}
}
