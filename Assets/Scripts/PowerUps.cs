using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public enum PowerupType { SpeedUp, SpeedDown, Grow, Shrink } 

    public PowerupType myPowerup;
    public float powerupDuration = 7f;
    PlayerController playerController; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerController= FindObjectOfType<PlayerController>();
        
    }

    public void UsePowerup()
    {
        if (myPowerup == PowerupType.SpeedUp)
            playerController.speed = playerController.baseSpeed * 2;
        if (myPowerup == PowerupType.SpeedDown)
            playerController.speed = playerController.baseSpeed / 3;

        StartCoroutine(ResetPowerup());

        if(myPowerup == PowerupType.Grow)
        {
            Vector3 temp = playerController.gameObject.transform.position; 
            temp.y = 1;
            playerController.gameObject.transform.position = temp;
            playerController.gameObject.transform.localScale = Vector3.one * 2; 
        }

        if (myPowerup == PowerupType.Shrink)
            playerController.gameObject.transform.localScale = Vector3.one /2;

    }

    IEnumerator ResetPowerup()
    {
        yield return new WaitForSeconds(powerupDuration);

        if(myPowerup == PowerupType.SpeedUp || myPowerup == PowerupType.SpeedDown) 
                playerController.speed = playerController.baseSpeed; 

        if(myPowerup == PowerupType.Grow || myPowerup == PowerupType.Shrink)
        {
            playerController.gameObject.transform.localScale = Vector3.one; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
