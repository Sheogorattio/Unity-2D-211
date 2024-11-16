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
    }

    void Update()
    {
        if (isFree && birds.Count > 0)
        {
            boxCollider2D.enabled = true;
            activeBird = birds[0];
            birds.RemoveAt(0);
            isFree = false;

            activeBird.isReady = true;

            PlaceBirdOnTop();
        }

        if (activeBird != null && !activeBird.isReady)
        {
            activeBird = null;
            isFree = true;
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
