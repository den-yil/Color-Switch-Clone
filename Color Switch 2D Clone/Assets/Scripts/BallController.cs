using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class BallController : MonoBehaviour
{
    public string currentColor;
    public float jumpForce = 15f;
    private Color ballColor;
    public Color yellow, turquoise, pink, purple;
    public TextMeshProUGUI scoreText, bestScoreText;
    int score;
    public GameObject[] gameObjects;
    public GameObject gameOverPanel,dead,stars,cm;
    public int bestScore;
    

    void Start()
    {
        RandomColor();
        score = 0;
        scoreText.text = score.ToString();
    }

    [System.Obsolete]
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
        }
        if(Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            if(finger.phase == TouchPhase.Began)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            }
        }
        scoreText.color = GetComponent<SpriteRenderer>().color;

        dead.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;

        jumpForce += Time.deltaTime/17;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != currentColor && collision.tag != "ColorChanger" && collision.tag != "AddScore")
        {          
            Instantiate(dead, transform.position, transform.rotation);

            if(score > PlayerPrefs.GetInt("BestScore",0))
            {
                PlayerPrefs.SetInt("BestScore", score);
                bestScoreText.text = score.ToString();
            }
            else
            {
                bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
            }
            

            Invoke("GameOver", 1.5f);

            gameObject.SetActive(false);
        }

        if(collision.gameObject.tag == "ColorChanger")
        {
            RandomColor();
            Destroy(collision.gameObject);
            
        }

        if(collision.gameObject.tag == "AddScore")
        {
            score++;
            scoreText.text = score.ToString();
            int random = Random.Range(0, 2);
            Instantiate(stars, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Instantiate(gameObjects[random], new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), transform.rotation);
        }

    }

    void RandomColor()
    {
        int random = Random.Range(0, 4);

        switch (random)
        {
            case 0: currentColor = "Turquoise";
                ballColor = turquoise;
                break;
            case 1: currentColor = "Yellow";
                ballColor = yellow;
                break;
            case 2: currentColor = "Pink";
                ballColor = pink;
                break;
            case 3: currentColor = "Purple";
                ballColor = purple;
                break;
        }
        GetComponent<SpriteRenderer>().color = ballColor;
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
