using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerMoveComtroller : MonoBehaviour
{
    #region Fields
    public CoinsManager CoinsManager;

    [SerializeField] private float _jumpPower;

    private Rigidbody _rigidbody; 
    private bool _isGrounded;

    [SerializeField] private Transform _cameraTransformPoint;
    [SerializeField] private float _inputDirVertical, _inputDirHorizontal, _torqueValue;
    //private float _xRotation;

    #endregion

    #region Code execution
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = 100f;
    }

    void Update()
    {
        InputValues();

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.VelocityChange);
        }

    }

    private void FixedUpdate()
    {
        RbMove();

    }
    #endregion

    #region methods

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

    private void OnCollisionStay(Collision collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);

        if (angle < 45f)

        {
            _isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }
    #endregion
}
