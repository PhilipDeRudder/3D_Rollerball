using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour

{

    public AudioSource coinhit;
    public AudioSource GameOver;

    public float speed;
    private Rigidbody rb;
    public LayerMask groundlayers;
    LoadLevel level = new LoadLevel();
    public int jumpForce;
    int previousJump;
    public SphereCollider col;
    public GameObject spawnPoint, heart1, heart2,heart3;
    private int lives = 3;
    #region Monobehaviour API;


    void Start()
    {

        previousJump = jumpForce;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            PauseGame();

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ContinueGame();
        }
    }

    void FixedUpdate()
    {
        Debug.Log(jumpForce);

        MovePlayer();

      

    }


    private void PauseGame()
    {
        Time.timeScale = 0;
        //Disable scripts that still work while timescale is set to 0
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
        //enable the scripts again
    }

    private void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);


        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

        
    }





    private void OnCollisionStay(Collision collision)
        {

            switch (collision.gameObject.tag)
            {
                case "speedBoost":
                    Debug.Log("hit speedboost");
                rb.velocity = Vector3.forward * 20;
                    break;
                case "jumpPad":
                rb.velocity = Vector3.up * 8;
                    Debug.Log("hit jumppad");
                    break;
                case "deadzone":
                    lives--;
                    CheckHealth(lives);
                    this.transform.position = spawnPoint.transform.position;
                    rb.velocity = Vector3.zero;
                    Debug.Log(lives);
                    break;
                case "road":
                    jumpForce = previousJump;
                    speed = 8;
                    break;
                case "spacezone":
                rb.useGravity = false;
                
                break;
            case "Finish":
                ScoreScript.scoreValue = 0;
                lives = 3;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
                default:
                    Debug.Log("normal");
                    jumpForce = previousJump;
                    break;
            }
        }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "spacezone")
        {
        }
    }


  





    private void CheckHealth(int lives)
    {
        switch (lives)
        {
            case 0:
                Destroy(heart1.gameObject);
                level.GameOVer();
                break;
            case 1:
                Destroy(heart2.gameObject);
                break;
            case 2:
                Destroy(heart3.gameObject);
              
                break;

            default:
                break;
        }


    }




    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * 0.3f, groundlayers);
      
    }
    
}

    #endregion
