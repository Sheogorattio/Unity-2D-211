using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HwBirdCountScript : MonoBehaviour
{

    private TMPro.TextMeshProUGUI birdsNumberText;
    // Start is called before the first frame update
    void Start()
    {
        birdsNumberText = GetComponent<TMPro.TextMeshProUGUI>();
        birdsNumberText.text = GameState.birdsCount.ToString();
        Debug.Log("First number from BirdsCountScript: " + GameState.birdsCount.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.needRecountBirds ){
            GameState.needRecountBirds = false;
            birdsNumberText.text = GameState.birdsCount.ToString();
              if(GameState.birdsCount <= 0){
                    GameState.birdsCount =0;
                    GameState.isFailed = true;
                    ModalScript.ShowModal("ПРОГРАШ", "Спроби закінчилися");
                }
        } 
    }
}
