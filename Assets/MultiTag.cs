using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTag : MonoBehaviour
{
    //string for the multi tag 
    public string[] tags;

    //public get has tag 
    public bool HasTag(string tag)
    {
        foreach (string t in tags)
        {
            if (t == tag)
            {
                return true;
            }
        }
        return false;
    }
}
