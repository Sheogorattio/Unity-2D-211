using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(collision.gameObject.name + "");
        if(collision.gameObject.CompareTag("PigDestroy")){
            ModalScript.ShowModal("ЗНИЩЕНО", "-1 супротивник");
            GameObject.Destroy(this.gameObject);
            GameState.needRecalculatePigs = true;
        }
    }
}