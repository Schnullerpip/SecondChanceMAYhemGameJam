﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        print("Collision with Killer");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Character>().Die();
        }
    }

}