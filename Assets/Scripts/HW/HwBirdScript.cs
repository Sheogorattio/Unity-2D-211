using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HwBirdScript : MonoBehaviour
{

    [SerializeField]
    Transform arrow;
    [SerializeField]
    BoxCollider2D slingshot;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            slingshot.enabled = false;
            rb2d.AddForce(arrow.right * 800);
        }
    }
}
