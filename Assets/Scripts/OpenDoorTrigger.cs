using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DoorManager doorManager = GetComponentInParent<DoorManager>();
            if (doorManager != null && !doorManager.doorIsOpen)
            {
                KeyScripts keyScripts = other.GetComponent<KeyScripts>();
                if (keyScripts != null)
                {
                    MultiTag mt = GetComponent<MultiTag>();
                    if (mt != null)
                    {
                        foreach (string t in mt.tags)
                        {
                            if ((t == "key_1" && (keyScripts.keys & KeyScripts.key_1) != 0) ||
                                (t == "key_2" && (keyScripts.keys & KeyScripts.key_2) != 0 && (keyScripts.keys & KeyScripts.key_3) != 0) ||
                                (keyScripts.keys & KeyScripts.gold_key) != 0)
                            {
                                doorManager.OpenDoor();
                                keyScripts.RemoveKey(t);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
