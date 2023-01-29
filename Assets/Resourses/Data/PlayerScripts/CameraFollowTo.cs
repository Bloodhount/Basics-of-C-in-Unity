using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTo : MonoBehaviour
{
    public List<Vector3> VelocitiesList = new List<Vector3>();

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Rigidbody _playerRigidbody;
    // [SerializeField] private Vector3 _cameraOffset;

    private void Start()
    {
        PlayerMoveComtroller playerMoveComtroller = FindObjectOfType<PlayerMoveComtroller>();
        _playerTransform = playerMoveComtroller.gameObject.transform;
        _playerRigidbody = FindObjectOfType<PlayerMoveComtroller>().gameObject.GetComponent<Rigidbody>();

        for (int i = 0; i < 5; i++)
        {
            VelocitiesList.Add(Vector3.zero);
        }
    }

    //Vector3 summVectors = Vector3.zero;
    private void Update()
    {
        Vector3 summVectors = Vector3.zero;

        for (int i = 0; i < VelocitiesList.Count; i++)
        {
            summVectors += VelocitiesList[i];
        }
        transform.position = _playerTransform.transform.position; // + _cameraOffset;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(summVectors), Time.deltaTime * 5f);
    }

    private void FixedUpdate()
    {
        VelocitiesList.Add(_playerRigidbody.velocity);
        VelocitiesList.RemoveAt(0);
    }

    /// <summary>
    /// использую LateUpdate для плавного рендера сцены, уже после всех расчетов
    /// </summary>
   /* void LateUpdate()
    {
        transform.position = _playerTransform.transform.position; // + _cameraOffset;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(summVectors), Time.deltaTime * 10f);
        //transform.rotation = Quaternion.LookRotation(summVectors);
    }
   */
}
