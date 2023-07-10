using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private LayerMask movableObj;
    [SerializeField] private LayerMask interactableObj;
    public bool pickUpStunGun;
    public bool pickUpSuit;
    private GameObject box;
    private BoxCollider2D playerBox;

    // Start is called before the first frame update
    void Start()
    {
        playerBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitbox = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, movableObj);
        RaycastHit2D hititem = Physics2D.BoxCast(playerBox.bounds.center, playerBox.size, 0, Vector2.zero, 0, interactableObj);
        

        if (hitbox.collider != null && Input.GetKeyDown(KeyCode.F))
        {
            box = hitbox.collider.gameObject;

            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            box.GetComponent<StaticBox>().beingMove = true;
            this.GetComponent<PlayerMovement>().speed /= 2f; 
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<StaticBox>().beingMove = false;
            this.GetComponent<PlayerMovement>().speed = 3f;
        }

        if (hititem.collider != null && Input.GetKeyDown(KeyCode.F))
        {
            pickUp(hititem.collider.gameObject);
        }
    }
    
    private void pickUp(GameObject obj)
    {
        if(obj.tag == "StunGun")
        {
            print("StunGun Picked Up");
            pickUpStunGun = true;
            Destroy(obj);
        }
        else if(obj.tag == "Suit")
        {
            print("Suit Picked Up");
            pickUpSuit = true;
            Destroy(obj);
        }
        else
        {
            pickUpStunGun = false;
            pickUpSuit = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position,(Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
