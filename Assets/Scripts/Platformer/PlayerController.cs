using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float VelocidadMovimiento;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        // playerInfo.isAlive = true;
        rb = GetComponent<Rigidbody2D>();
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
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(VelocidadMovimiento, rb.velocity.y);
            rb.transform.localScale = new Vector2(1, 1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
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


    /*
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.transform.tag.Equals("SueloEnMovimiento"))
        {
            gameObject.transform.parent = c.gameObject.transform;
        }
        else
        {
            gameObject.transform.parent = null;
        }

        TocoPiso = c.gameObject.tag.Equals("Suelo")
            || c.gameObject.tag.Equals("SueloEnMovimiento")
            || c.gameObject.tag.Equals("Enemy");


        if (c.gameObject.tag.Equals("Respawn"))
        {
            if (lives > 0)
                lives--;
        }
    }

    void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.transform.tag.Equals("Suelo")
            || c.gameObject.tag.Equals("SueloEnMovimiento")
            || c.gameObject.tag.Equals("Enemy"))
        {
            TocoPiso = false;
        }
    }*/
}