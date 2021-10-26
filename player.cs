using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody rb;
    private float contador;
    public Text texto;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.W))
       {
            rb.AddForce(Vector3.forward * moveSpeed);
       }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * moveSpeed);
        }
        SetDistance();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Cylinder")
        {
            contador = contador + 1;
        }
    }

    void SetDistance()
    {
        texto.text = "Player 1: " + contador.ToString();
    }
}
