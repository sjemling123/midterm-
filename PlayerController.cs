using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float speed;
    public float jumpForce;
    private int Lives;
    public Text countText;
    public Text winText;
    private int count;
    public Text LivesText;
    public Text LoseText;
    public AudioClip CoinNoise;
    public Text countdown;
    public Text WarningText;

    public bool facingRight = true;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = " ";
        Lives = 3;
        LivesText.text = " ";
        LoseText.text = " ";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (rb2d.velocity.x >= 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }

        else
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            }
            if (Input.GetKey(KeyCode.W))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

            }
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetcountText();
            SetLivesText();
            AudioSource.PlayClipAtPoint(CoinNoise, transform.position); 
        }
        else if (other.gameObject.CompareTag("Evil"))
        {
            other.gameObject.SetActive(false);
            SetcountText();
            Lives = Lives - 1;
            SetLivesText();

        }

        else if (other.gameObject.CompareTag("AngryCat"))
        {
            other.gameObject.SetActive(false);
            SetcountText();
            Lives = Lives - 1;
            SetLivesText();

        }


        if (Lives == 0)
        {
            LoseText.text = "Oh no! You're out of lives!";
        }
        if (other.gameObject.CompareTag("AngryCat"))
        {
            rb2d.AddForce(new Vector2(15, 5), ForceMode2D.Impulse);
        }
    }

    void SetcountText()
    {
        countText.text = "Count:" + count.ToString();

        if (count >= 8)
        {
            winText.text = "You Win! Game created by Sarah Emling";
        }
        if (count == 4)
        {
            transform.position = new Vector2(45, 0);
            Lives = 3;

        }
    }
    void SetLoseText()
    {

        LoseText.text = "Oh no! You're out of lives!";

    }

    void SetLivesText()
    {
        LivesText.text = "Lives: " + Lives.ToString();
    }

    void SetWarningText()
    {
        WarningText.text = " Watch out for those cats! They can give a mean shove!";
    }

}
