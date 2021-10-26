using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubo : MonoBehaviour
{
    private Vector3 scaleChangeUp;
    private Vector3 scaleChangeDown;
    // Start is called before the first frame update
    void Start()
    {
        scaleChangeUp = new Vector3(0.5f, 0.5f, 0.5f);
        scaleChangeDown = new Vector3(-0.5f, -0.5f, -0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Sphere")
        {
            transform.localScale += scaleChangeUp;
        }
        if (col.gameObject.tag == "Player1")
        {
            transform.localScale += scaleChangeDown;
        }
    }
}
