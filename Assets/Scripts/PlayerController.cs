using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   //Movement
    public float speed = 1f;
    private Rigidbody rb;

    //Pickups
    private int pickUpCount;

    //Timer
    private Timer timer;

    //Win
    private bool gameOver = false;

    [Header("UI")]
    public TMP_Text pickUpText;
    public TMP_Text timerText;

    public GameObject winPanel;
    public GameObject inGamePanel;
    public TMP_Text winTimer;

    


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Number of Pickups
        pickUpCount = GameObject.FindGameObjectsWithTag("Pick Up").Length;

        CheckPickUps();

        //Get timer ojbect and start timer
        timer = FindObjectOfType<Timer>();
        timer.StartTimer();

        winPanel.SetActive(false);
        inGamePanel.SetActive(true);
        

        //pause
        Time.timeScale = 1;

    }

    private void Update()
    {
        timerText.text = "Time:" + timer.GetTime().ToString("F2");

    }

    void FixedUpdate()
    {

        if (gameOver == true)
        {
            return;
        }
        
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
        pickUpText.text = "Pick Ups Left:" + pickUpCount;
       
        
            
        
        if (pickUpCount == 0)
        {
            WinGame();

        }

    }

    void WinGame()
    {
        //Game Over
        gameOver = true; 


       pickUpText.color = Color.green;
        timerText.color = Color.green;

        //stop timer
        timer.StopTimer();

        //Display Win Panel
        winPanel.SetActive(true);
        inGamePanel.SetActive(false);


        winTimer.text = "Time:" + timer.GetTime().ToString("F2");

        //Stop the ball from moving
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        
    }
   
       
    
}