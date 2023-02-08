using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapScript : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    void LateUpdate()
    {
        Vector3 camPosition = _playerTransform.position;
        camPosition.y = transform.position.y;
        transform.position = camPosition;
    }
}
