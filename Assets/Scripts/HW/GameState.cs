using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static bool needRecalculatePigs {get;set;}
    public static bool isLevelCompleted {get;set;}

    public static int levelIndex {get;set;} =0;

    public static int birdsCount {get; set;}

    public static bool needRecountBirds {get; set;} =true;

    public static bool isFailed {get;set;} = false;
}
