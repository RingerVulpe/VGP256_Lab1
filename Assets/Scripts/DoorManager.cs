using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Collider mainDoorCollider; // Reference to the main door collider
    public bool doorIsOpen = false; // To keep track of the door state

    public void OpenDoor()
    {
        mainDoorCollider.enabled = false;
        doorIsOpen = true;
    }

    public void CloseDoor()
    {
        mainDoorCollider.enabled = true;
        doorIsOpen = false;
    }
}
