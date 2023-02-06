using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPursuit : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _playerTransform;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerTransform = FindObjectOfType<PlayerMoveComtroller>().transform;
    }

    void Update()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        _rigidbody.AddForce((toPlayer) * _speed, ForceMode.Acceleration);
    }
}
