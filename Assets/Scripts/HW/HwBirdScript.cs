using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HwBirdScript : MonoBehaviour
{

    [SerializeField]
    int maxAccelerations;

    [SerializeField]
    float basicAccelerationSpeed;

    [SerializeField]
    Transform arrow;

    [SerializeField]
    BoxCollider2D slingshotCollider;
    Rigidbody2D rb2d;

    [SerializeField]
    public bool isReady = false;
    private int accelerationsCounter;
    private HwForceScript forceScript;
    private SlingshotScript slingshotScript;
    // Start is called before the first frame update
    void Start()
    {
        accelerationsCounter =0;
        rb2d = GetComponent<Rigidbody2D>();
        forceScript = GameObject.Find("ForceCanvasIndicator").GetComponent<HwForceScript>();
        slingshotScript = GameObject.Find("Slingshot").GetComponent<SlingshotScript>();
        slingshotScript.birds.Add(this);
        //slingshotCollider = slingshotScript.boxCollider2D;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isReady){
            accelerationsCounter++;
            if (accelerationsCounter == maxAccelerations)
            {
                isReady = false;
            }
            slingshotCollider.enabled = false;
           
            if(forceScript != null){
                basicAccelerationSpeed *= forceScript.forceFactor + 0.5f;
            } 
            else{
                Debug.LogError("forceScript NULL, used default");
            }
            rb2d.AddForce(arrow.right * basicAccelerationSpeed);
            //slingshotCollider.enabled = true;
        }
    }
}
