using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rd2d;
    public float speed;
    public Text score;
    private int scoreValue = 0;
    public Text winText;
    private int lives;
    public Text livesText;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;
    Animator anim;


    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        winText.text = "";
        lives = 3;
        SetLivesText();
        musicSource.clip = musicClipOne;
        musicSource.Play();
        musicSource.loop = true;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (scoreValue == 4)
        {
            transform.position = new Vector3(100.0f, 1.2f, 0.0f);
        }
        if (scoreValue == 4)
        {
            lives = 3;
            SetLivesText();
        }
        if (scoreValue == 9)
        {   
            musicSource.loop = false;
            musicSource.Stop();

            musicSource.clip = musicClipTwo;
            musicSource.Play();
            winText.text = "You Win! Game created by Roque Tacsa";
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetInteger("State",1);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("State",0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetInteger("State",1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("State",0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetInteger("State",2);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("State",0);
        }
    }

    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        if (Input.GetAxisRaw("Horizontal") > 0) GetComponent<SpriteRenderer>().flipX = false;
        else if (Input.GetAxisRaw("Horizontal") < 0) GetComponent<SpriteRenderer>().flipX = true;

        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.tag == "Enemy")
        {
            lives = lives -1;
            SetLivesText();
            Destroy(collision.collider.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 4),ForceMode2D.Impulse);
            }
        }
    }

    void SetLivesText ()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives <=0)
        {
            winText.text = "You lose!";
            Destroy (gameObject);
        }
    }
}