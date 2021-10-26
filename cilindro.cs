using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cilindro : MonoBehaviour
{
    private Vector3 scaleChange;
    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(0.5f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            transform.localScale += scaleChange;
        }
    }
}
