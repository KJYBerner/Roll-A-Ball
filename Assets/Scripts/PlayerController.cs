using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody rb;
    private int pickUpCount;
    private string winCondition;
    private Timer timer;



    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Number of Pickups
        pickUpCount = GameObject.FindGameObjectsWithTag("Pick Up").Length;

        CheckPickUps();

        //Get timer ojbect and start timer
        timer = FindObjectOfType<Timer>();
        timer.StartTimer();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pick Up")
        {
            Destroy(other.gameObject);

            //Decrease the pickUpCount

            pickUpCount--;
            CheckPickUps();
        }
    }

    void CheckPickUps()
    {
        if (pickUpCount == 0)
        {
            winCondition = "WIN";
            print(winCondition);
            print("Your time was:" + timer.GetTime());

            //stop timer
            timer.StopTimer();

        }

    }
}