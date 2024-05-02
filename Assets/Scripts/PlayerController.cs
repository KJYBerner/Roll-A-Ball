using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
   //Movement
    public float speed = 1f;
    [HideInInspector]
    public float baseSpeed; 
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


    //reset point
    GameObject resetPoint;
    bool resetting = false;
    Color originalColour;

    //death screen
    public GameObject deathPanel; 

    //Controller
    GameController gameController;
    CameraController cameraController;

    //Booster
    bool grounded = true;

   


    void Start()
    {
        baseSpeed = speed; 

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

        //reset point
        resetPoint = GameObject.Find("Reset Point"); 
        originalColour = GetComponent<Renderer>().material.color;

        //deathscreen
        deathPanel.SetActive(false);

        gameController = FindObjectOfType<GameController>();
        timer = FindObjectOfType<Timer>();
        if (gameController.gameType == GameType.SpeedRun)
            StartCoroutine(timer.StartCountdown()); 

        cameraController = FindObjectOfType<CameraController>();

    }

    private void Update()
    {
        timerText.text = "Time:" + timer.GetTime().ToString("F2");

    }

    void FixedUpdate()
    {

        if (resetting)
            return;

        if (gameOver == true)
        {
            return;
        }

        if (gameController.gameType == GameType.SpeedRun && !timer.IsTiming())
            return;
        if (gameController.controlType == ControlType.WorldTilt)
            return;

        if (grounded)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
            

            if (cameraController.cameraStyle == CameraStyle.Free)
            {
                transform.eulerAngles = Camera.main.transform.eulerAngles;

                movement = transform.TransformDirection(movement);
            }

            rb.AddForce(movement * speed);

        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = true;
        }
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

        if( other.gameObject.CompareTag("Powerup"))
        {
            other.GetComponent<PowerUps>().UsePowerup();
            other.gameObject.transform.position = Vector3.down * 1000;
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

        if(gameController.gameType == GameType.SpeedRun)
            timer.StopTimer();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Respawn"))
        {
            StartCoroutine(ResetPlayer());
            deathPanelToggle();


        }
    }

    public IEnumerator ResetPlayer()
    {
        resetting = true;
        GetComponent<Renderer>().material.color = Color.black;
        rb.velocity = Vector3.zero;
        Vector3 startPos = transform.position;
        float resetSpeed = 2f;
        var i = 0.0f;
        var rate = 1.0f / resetSpeed;
        while(i<1.0f)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPos, resetPoint.transform.position, i);
            yield return null;
        }
        GetComponent<Renderer>().material.color = originalColour;
        resetting = false;

    }

    public void deathPanelToggle()
    {
        deathPanel.SetActive(true);
    }


}