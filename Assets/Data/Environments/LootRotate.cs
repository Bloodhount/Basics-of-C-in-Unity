using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootRotate : MonoBehaviour
{
    private Transform _targetTransform;


    [SerializeField] private float _rotateSpeed = 1f;

    void Start()
    {
        //_targetTransform = FindObjectOfType<PlayerMoveComtroller>().transform;
    }

    void Update()
    {
        gameObject.transform.Rotate( Vector3.up, _rotateSpeed * Time.deltaTime);
    }
}
