using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BitSequence : MonoBehaviour
{
    int BitSeq = 0;
    // runs only once at the beggining
    void Start()
    {
        Debug.Log(Convert.ToString(BitSeq, 2)); // converting to base 2

        
    }
    // runs constantly while game is played
    void Update()
    {

    }
}
