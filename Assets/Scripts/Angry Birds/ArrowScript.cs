using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    [SerializeField]
    private Transform anchor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dy = Input.GetAxis("Vertical");

        float angle = this.transform.rotation.eulerAngles.z;
        if(angle >180){
            angle -=360;
        }
        if( -30 < angle + dy && angle  + dy < 60){
             this.transform.RotateAround(anchor.position, Vector3.forward, dy);
        }
       
    }
}
