using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.left * 0.01f);
        if(this.transform.position.x < -10.0f)
        {
            this.transform.position = new Vector3(10f, this.transform.position.y);
        }
    }
}
