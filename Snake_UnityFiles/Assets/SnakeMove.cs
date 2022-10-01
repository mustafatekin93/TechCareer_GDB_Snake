using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnakeMove : MonoBehaviour
{
    private Rigidbody2D rbSnake;
    public SpriteRenderer snakeRenderer;
    public Collider2D snakeCollider;
    public TrailRenderer trailRenderer;
    public ParticleSystem explotionEffect;
    public float speed;
    public TMP_Text ScoreText;
    public GameObject GameOverText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        rbSnake = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rbSnake.velocity = Vector2.up * speed;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rbSnake.velocity = Vector2.down * speed;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rbSnake.velocity = Vector2.left * speed;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rbSnake.velocity = Vector2.right * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Apple")
        {
            score++;
            speed = speed + 0.25f;
            trailRenderer.time += 0.1f;
            ScoreText.text = score.ToString();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag == "Wall")
        {
            GameOver();
        }
    }

    void GameOver()
    {
        snakeCollider.enabled = false;
        snakeRenderer.enabled = false;
        GameOverText.SetActive(true);
    }
}
