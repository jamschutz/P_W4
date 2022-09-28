using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishGame : MonoBehaviour
{
    public UnityEvent eventOnWin;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") {
            Debug.Log("YOU WIN! :)");

            eventOnWin.Invoke();
        }
    }
}
