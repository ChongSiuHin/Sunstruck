using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingMechanism : MonoBehaviour
{
    private bool isHiding;
    private bool hideAllow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hideAllow && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Player hiding");
            isHiding = true;
            this.GetComponent<BoxCollider2D>().isTrigger = true;
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            this.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            Debug.Log("Player came out from hiding");
            this.GetComponent<BoxCollider2D>().isTrigger = false;
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            this.GetComponent<SpriteRenderer>().sortingLayerName = "Sprites";
            isHiding = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hidepoint"))
        {
            Debug.Log("Player can hide");
            hideAllow = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hidepoint"))
        {
            Debug.Log("Player cannot hide");
            hideAllow = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Enemy") && !isHiding)
        {
            transform.position = this.GetComponent<CheckpointRespawn>().respawnPoint;
        }
    }
}
