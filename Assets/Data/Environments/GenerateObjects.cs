using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateObjects : MonoBehaviour
{
    [SerializeField] private int _dimension;

    public GameObject BoxPrefab;
    public Material MaterialA;
    public Material MaterialB;

    void Start()
    {
        for (int i = 0; i < _dimension; i++)
        {

            for (int j = 0; j < _dimension; j++)
            {
                GameObject box = Instantiate(BoxPrefab, new Vector3(i, 0, j), Quaternion.identity);

                if (j % 2 == 0 && i % 2 == 0)
                {
                    box.GetComponent<Renderer>().material = MaterialA;
                }
                else if (j % 2 == 0 || i % 2 == 0)
                {
                    box.GetComponent<Renderer>().material = MaterialB;
                }
                else
                {
                    box.GetComponent<Renderer>().material = MaterialA;
                    // box.GetComponent<Renderer>().material.color = Color.red;
                }

            }
        }
    }
}