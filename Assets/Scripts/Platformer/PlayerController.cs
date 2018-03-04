using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    public float VelocidadMovimiento;
    private Rigidbody2D rb;

    private bool canMove;

    private AudioSource audioSrc;
    public AudioClip AudioOnGetCoin;

    // Use this for initialization
    void Start()
    {
        // playerInfo.isAlive = true;
        rb = GetComponent<Rigidbody2D>();
        audioSrc = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Movimiento izquierda y derecha
        LeftRightMovement();

        // Logica del salto
        // SaltoLogic();

        // Vidas
        // Vidas();
    }
    void LeftRightMovement()
    {
        // Player cannot move in the air
        if (!canMove)
            return;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(VelocidadMovimiento, rb.velocity.y);
            rb.transform.localScale = new Vector2(1, 1);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-1 * VelocidadMovimiento, rb.velocity.y);
            rb.transform.localScale = new Vector2(-1, 1);
        }
    }

    /*void Vidas()
    {
        if (lives > 0 && gameObject.transform.position.y < -3.5)
        {
            lives = 0;
        }
        if (lives == 0)
        {
            playerInfo.isAlive = true;
            SceneManager.LoadScene(scenesIndex.GameOver, LoadSceneMode.Single);
        }
    }*/


    
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.transform.tag.Equals("Suelo"))
        {
            canMove = true;
            
        }
    }

    void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.transform.tag.Equals("Suelo"))
        {
            // Player cannot move in the air
            canMove = false;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.transform.tag.Equals("Coin"))
        {
            audioSrc.PlayOneShot(AudioOnGetCoin);
        }
    }
}