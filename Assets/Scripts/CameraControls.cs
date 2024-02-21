using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        //Set the offset of the camera based on the players position
        offset = transform.position - player.transform.position; 
    }

    
    void Update()
    {
        //Make the transform position of the camera follow the player's transform position  
        transform.position = player.transform.position + offset; 
    }
}
