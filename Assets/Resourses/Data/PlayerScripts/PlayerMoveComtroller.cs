using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveComtroller : MonoBehaviour
{
    public CoinsManager CoinsManager;

    [SerializeField] private float _jumpPower;

    private Rigidbody _rigidbody;
    [SerializeField] private Transform _cameraTransformPoint;
    [SerializeField] private float _inputDirVertical, _inputDirHorizontal, _torqueValue;

    //private float _xRotation;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = 100f;
    }

    void Update()
    {
        InputValues();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        }

    }

    private void FixedUpdate()
    {
        RbMove();

    }

    private void InputValues()
    {
        _inputDirHorizontal = Input.GetAxis("Horizontal");
        _inputDirVertical = Input.GetAxis("Vertical");
    }

    private void RbMove()
    {
        _rigidbody.AddTorque(-_cameraTransformPoint.forward * _inputDirHorizontal * _torqueValue);
        _rigidbody.AddTorque(_cameraTransformPoint.right * _inputDirVertical * _torqueValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        Loot loot = other.GetComponent<Loot>();
        if (loot)
        {
            CoinsManager.CollectCoin(loot);
        }
    }
}
