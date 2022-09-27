using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInElevator : MonoBehaviour
{
    public float heightOffset;

    Transform elevator;
    Transform player;

    void Start()
    {
        elevator = transform.parent;
        player = null;
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") {
            player = other.transform;
            player.GetComponent<Rigidbody>().useGravity = false;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player") {
            player.GetComponent<Rigidbody>().useGravity = true;
            player = null;
        }
    }


    void Update()
    {
        if(player == null) return;

        player.position = new Vector3(player.position.x, elevator.position.y + heightOffset, player.position.z);
    }
}
