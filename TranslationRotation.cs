using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 1f;
    public float rotationSpeed = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Translation
        if(Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        //Rotation
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.RotateAround(transform.position, Vector3.down, rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.RotateAround(transform.position, Vector3.up, rotationSpeed);
        }
    }
}
