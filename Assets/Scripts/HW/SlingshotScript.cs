using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotScript : MonoBehaviour
{
    [SerializeField]
    public List<HwBirdScript> birds = new List<HwBirdScript>();

    public BoxCollider2D boxCollider2D {get; private set;}
    [SerializeField]
    private bool isFree;

    [SerializeField]
    private HwBirdScript activeBird;

    private float shotTime = 10.0f;
    private float currentShotTime  = 0.0f;

    [SerializeField]
    private float maxThinkingTime = 10.0f;
    private float currentThinkingTime = 0.0f;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        if (boxCollider2D == null)
        {
            Debug.LogError("BoxCollider2D not found on this GameObject!");
            boxCollider2D = GetComponentInChildren<BoxCollider2D>();
            if (boxCollider2D == null)
            {
                Debug.LogError("BoxCollider2D not found in children of this GameObject!");
            }
        }
        isFree = true;
        activeBird = null;
        GameState.birdsCount = birds.Count;
        // GameState.needRecountBirds = true;
        Debug.Log("Birds in sligshot's array: " + birds.Count );
    }

    void Update()
    {
        
        if (isFree && birds.Count > 0)//поміщення нової пташки на рогатку, якщо ще є вільні птахи
        {
            
            GameState.birdsCount = birds.Count;
            GameState.needRecountBirds = true;
            boxCollider2D.enabled = true;
            activeBird = birds[0];
            birds.RemoveAt(0);
            isFree = false;

            activeBird.isReady = true;

            PlaceBirdOnTop();
        }
        if(!isFree && activeBird.isReady){//коли пташка готова до вистрілу
            if(currentThinkingTime <= maxThinkingTime){
                currentThinkingTime += Time.deltaTime;
            }
            else{
                currentThinkingTime = 0.0f;
                activeBird.isReady =false;
                isFree = true;
                //видалення активної пташки та заміна значення пташки в масиві на щось пусте
                Destroy(activeBird.gameObject);
                activeBird = null;
                ModalScript.ShowModal("Час сплив", "Довго думав");
                GameState.birdsCount = birds.Count;
                GameState.needRecountBirds = true;
            }
        }

        if (activeBird != null && !activeBird.isReady)//відлік часу, коли пташка полетіла, але ставити нову ще рано
        {
            currentShotTime += Time.deltaTime;
        }
        if(currentShotTime >= shotTime){//коли настав час активності попередньої пташки сплив і потрібно помітити її, як відстріляну
            activeBird = null;
            isFree = true;
            currentShotTime = 0.0f;  
            if(birds.Count ==0){
                GameState.birdsCount = birds.Count;
                GameState.needRecountBirds = true;
            }
        }
    }

    private void PlaceBirdOnTop()
    {
        if (activeBird != null)
        { 

            float colliderTop = boxCollider2D.bounds.max.y;

            float birdHeight = activeBird.GetComponent<SpriteRenderer>().bounds.size.y;

            Vector3 newBirdPosition = new Vector3(
                transform.position.x, 
                colliderTop + birdHeight / 2, 
                activeBird.transform.position.z
            );

            activeBird.transform.position = newBirdPosition;
        }
    }
}
