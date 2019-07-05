using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private bool isGrounded;
    public Camera cam1;
    public Camera cam2;
    public Text score;
    public float speed;
    private Rigidbody rb;
    float hit;
    private int count;
    
    // Start is called before the first frame update


    void Start()
    {
      
        rb = GetComponent<Rigidbody>();
        count = 0;
        displayScore();
        cam1.enabled = true;
        cam2.enabled = false;
        
    }

    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        if (Input.GetKeyDown("space"))
        {
            if (isGrounded)
            {

                rb.AddForce(new Vector3(0f, 400f, 0f));
            }
        }
        if (Input.GetKeyDown("q"))
        {
            cam1.enabled = true;
            cam2.enabled = false;
        }
        if (Input.GetKeyDown("w"))
        {
            cam1.enabled = false;
            cam2.enabled = true;
        }
       /* if(score.text=="16")
        {
            score.text = "YOU WIN!!!!";
            Invoke("restart", 4f);
        }*/

    }
    void OnCollisionEnter(Collision other)//when the object is on the ground
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
        if (other.gameObject.tag == "gameovercollider")
        {
            displayGameOver();
            Invoke("restart", 2f);
        }
       
    }



    void OnCollisionExit(Collision other)//when the player object leaves the ground.
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("points"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            displayScore();
        }
        if (other.gameObject.tag == "wingame")
        {
            other.gameObject.SetActive(false);
            score.text = "YOU WIN!!!!";
            Invoke("restart", 2f);
        }
    }
    void displayScore()
    {
        score.text = "" + count.ToString();
    }
    void displayGameOver()
    {
        score.text = "Game over";
    }

    public void restart()
    {
        SceneManager.LoadScene("Exercise_4");
    }

    

}