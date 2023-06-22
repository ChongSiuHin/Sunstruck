using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetSpeed;
    private Vector3 camPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        if (player.transform.localScale.x > 0f)
        {
            camPos = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, transform.position.z);
        }
        else if (player.transform.localScale.x < 0f)
        {
            camPos = new Vector3(player.transform.position.x - offsetX, player.transform.position.y + offsetY, transform.position.z);
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