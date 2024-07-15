using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class KeyScripts : MonoBehaviour
{
    public static int key_1 = 1;
    public static int key_2 = 2;
    public static int key_3 = 4;
    public static int gold_key = 16;

    // Bitwise text display
    public Text displayText;
    public int keys = 0;

    private void OnTriggerEnter(Collider other)
    {
        // Debug log that we hit a key 
        Debug.Log("Hit key: " + other.gameObject.tag);
        switch (other.gameObject.tag)
        {
            case "key_1":
                keys |= key_1;
                // Destroy the key
                Destroy(other.gameObject);
                break;

            case "key_2":
                keys |= key_2;
                Destroy(other.gameObject);
                break;

            case "key_3":
                keys |= key_3;
                Destroy(other.gameObject);
                break;

            case "gold_key":
                keys |= gold_key;
                Destroy(other.gameObject);
                break;
        }

        // If the gameObject is KEYCHECK then check if it has a MultiTag component 
        if (other.gameObject.tag == "KEYCHECK")
        {
            DoorManager doorManager = other.gameObject.GetComponentInParent<DoorManager>();
            if (doorManager != null)
            {
                // If we have the golden key then open the door
                if ((keys & gold_key) != 0)
                {
                    doorManager.OpenDoor();
                    RemoveKey("gold_key");
                    return;
                }

                MultiTag mt = other.gameObject.GetComponent<MultiTag>();
                if (mt != null)
                {
                    foreach (string t in mt.tags)
                    {
                        if (t == "key_1" && (keys & key_1) != 0)
                        {
                            doorManager.OpenDoor();
                            RemoveKey(t);
                        }
                        // If it requires key 2 and key 3 then use both 
                        if (t == "key_2" && (keys & key_2) == key_2 && (keys & key_3) != 0)
                        {
                            doorManager.OpenDoor();
                            RemoveKey(t);
                        }
                    }
                }
            }
        }
    }

    public void RemoveKey(string tag)
    {
        switch (tag)
        {
            case "key_1":
                keys &= ~KeyScripts.key_1;
                break;
            case "key_2":
                keys &= ~KeyScripts.key_2;
                keys &= ~KeyScripts.key_3;
                break;
            case "gold_key":
                keys &= ~KeyScripts.gold_key;
                break;
        }
    }

    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        displayText.transform.position = screenPoint + new Vector3(0, -50, 0);
        displayText.text = Convert.ToString(keys, 2).PadLeft(8, '0');
    }
}
