using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DoorManager doorManager = GetComponentInParent<DoorManager>();
            if (doorManager != null && doorManager.doorIsOpen)
            {
                doorManager.CloseDoor();
            }
        }
    }
}
