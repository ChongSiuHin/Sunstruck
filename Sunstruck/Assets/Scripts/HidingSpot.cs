using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpot : MonoBehaviour
{
    [SerializeField] private Sprite nSprite;
    private Sprite oriSprite;
    private HidingMechanism checkHide;
    private bool playerCheck;

    private void Start()
    {
        oriSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        checkHide = FindObjectOfType<HidingMechanism>();
        
        if(playerCheck)
        {
            if (checkHide.isHiding)
            {
                print("Player hiding");
                gameObject.GetComponent<SpriteRenderer>().sprite = nSprite;
            }
            else
                gameObject.GetComponent<SpriteRenderer>().sprite = oriSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerCheck = false;
        }
    }
}
