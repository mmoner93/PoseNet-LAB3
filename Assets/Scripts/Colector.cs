﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colector : MonoBehaviour
{
    private Rigidbody rb;
    //private int count;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //count = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            Manager.instance.colision();
            //count += 1;
            other.gameObject.SetActive(false);
            Manager.instance.update_numcolisions();
        }
    }
}