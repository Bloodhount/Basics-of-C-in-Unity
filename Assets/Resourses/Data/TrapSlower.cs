using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSlower : MonoBehaviour, ISlower
{
    private PlayerMoveComtroller player;
    public void Slower()
    {
        player = FindObjectOfType<PlayerMoveComtroller>();
        player.GetComponent<Rigidbody>().angularDrag = 22f;
    }

    private void OnTriggerStay(Collider other)
    {
        Slower();
    }
    private void OnTriggerExit(Collider other)
    {
        player.GetComponent<Rigidbody>().angularDrag = 1.5f;
    }
}
