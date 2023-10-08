using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coinn : MonoBehaviour
{
    public int score;
    public int maxScore;
    public TextMeshProUGUI scoreText;
    private PlayerController playerController;
    private Tutorial tutorial;

    public Animator playerAnim;
    public GameObject thisPlayer;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerAnim = thisPlayer.GetComponentInChildren<Animator>();
        tutorial = FindObjectOfType<Tutorial>();
    }

    private void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void Update()
    {
        //scoreText.text = "Score: " + score.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("EndGame"))
        {
            playerController._speed = 0f;
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
            if (score >= maxScore)
            {
                playerAnim.SetBool("Win", true);
                StartCoroutine(RestartSceneAfterDelay(10f));
            }
            else
            {
                playerAnim.SetBool("Lose", true);
                StartCoroutine(RestartSceneAfterDelay(10f));
            }
        }
        else if (other.CompareTag("EndTutorial"))
        {
            tutorial.endTutorial = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddCoin()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    IEnumerator RestartSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
