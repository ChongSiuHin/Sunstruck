using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetSpeed;
    [SerializeField] private float offsetManual;
    private Vector3 camPos;
    private PlayerMovement playerMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        camPos = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, transform.position.z);
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.playerRb.velocity.x > 0f)
        {
            camPos = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, transform.position.z);
        }
        else if (playerMovement.playerRb.velocity.x < 0f)
        {
            camPos = new Vector3(player.transform.position.x - offsetX, player.transform.position.y + offsetY, transform.position.z);
        }
        else
        {
            //camPos = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, transform.position.z);

            //Offset to Right
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                camPos = new Vector3(player.transform.position.x + offsetManual, player.transform.position.y + offsetY, transform.position.z);
            }
            else if(Input.GetKeyUp(KeyCode.RightArrow))
            {
                camPos = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, transform.position.z);
            }

            //Offset to Left
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                camPos = new Vector3(player.transform.position.x - offsetManual, player.transform.position.y + offsetY, transform.position.z);
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                camPos = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, transform.position.z);
            }

            //Offset to Up
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                camPos = new Vector3(player.transform.position.x, player.transform.position.y + (offsetManual / 2), transform.position.z);
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                camPos = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, transform.position.z);
            }

            //Offset to Down
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                camPos = new Vector3(player.transform.position.x, player.transform.position.y - (offsetManual / 2), transform.position.z);
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                camPos = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, transform.position.z);
            }
        }

        transform.position = Vector3.Lerp(transform.position, camPos, offsetSpeed * Time.deltaTime);
    }
}


//if(input.getkeydown(keycode.rightarrow))
//    campos = new vector3(player.transform.position.x + offset, player.transform.position.y, campos.z);
//else if(input.getkeydown(keycode.leftarrow))
//    campos = new vector3(player.transform.position.x - offset, player.transform.position.y, campos.z);
//else if (input.getkeydown(keycode.uparrow))
//    campos = new vector3(player.transform.position.x, player.transform.position.y + offset, campos.z);
//else if (input.getkeydown(keycode.downarrow))
//    campos = new vector3(player.transform.position.x, player.transform.position.y - offset, campos.z);