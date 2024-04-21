using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CameraStyle {Fixed, Free}
public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
    public CameraStyle cameraStyle;
    public Transform pivot;
    public float rotationSpeed = 1f;

   
    private Vector3 pivotOffset; 

    void Start()
    {

        pivotOffset = pivot.position - player.transform.position;
        //Set the offset of the camera based on the players position
        offset = transform.position - player.transform.position;
    }


    void Update()
    {
        //Make the transform position of the camera follow the player's transform position  
        transform.position = player.transform.position + offset;
    }

    private void LateUpdate()
    {
        if(cameraStyle == CameraStyle.Fixed)
        {
            transform.position = player.transform.position + offset;

            Quaternion turnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);

            offset = turnAngle * offset;

            transform.position = pivot.transform.position + offset;

            transform.LookAt(pivot); 

        }
    }

}