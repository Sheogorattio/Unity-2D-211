using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HwPigsCountScript : MonoBehaviour
{
    private TMPro.TextMeshProUGUI pigsCountTM;
    private int pigsCount =1 ;
    // Start is called before the first frame update
    void Start()
    {
        pigsCountTM = GetComponent<TMPro.TextMeshProUGUI>();
        GameState.needRecalculatePigs = true;
    }

    // Update is called once per frame
    void Update()
    {
   
       pigsCount =  GameObject.FindGameObjectsWithTag("Pig").Length;
        Debug.Log("GameState.isLevelCompleted " +GameState.isLevelCompleted + "\nPigs " + pigsCount + "\nScene index " + GameState.levelIndex);
        if(  GameState.needRecalculatePigs){
            pigsCountTM.text = 
            pigsCount
            .ToString();
            GameState.needRecalculatePigs = false;
        }
        if(pigsCount == 0){
            
            GameState.isLevelCompleted = true;
            pigsCount=1;
        }
    }
}
