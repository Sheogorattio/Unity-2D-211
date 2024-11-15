using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HwArrowScript : MonoBehaviour
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
        float angle = this.transform.eulerAngles.z;

        if(angle> 180){
            angle -= 360;
        }
        if (angle + dy > -60 && angle + dy < 80){
            this.transform.RotateAround(anchor.position ,Vector3.forward, dy);
        }
    }
}
