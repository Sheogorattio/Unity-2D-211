using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class HwClockScript : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI clock;
    private float gameTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //clock = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
       gameTime += Time.deltaTime;

        int hours = (int)(gameTime / 3600); 
        int minutes = (int)((gameTime % 3600) / 60); 
        int seconds = (int)(gameTime % 60); 

        clock.text = String.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
    }
}
