using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{   
    //Score
    public int scorePoint;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Spawner spawner;
    [SerializeField] private GameObject imageGameOver;
    [SerializeField] private GameObject playButton;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Player player;

    private Vector3 playerTransform;

    private void Start()
    {
        playerTransform = player.transform.position;
        scorePoint = 0;
        imageGameOver.SetActive(false);
        Time.timeScale = 0f;
        scoreText.enabled = false;
        playerSprite.enabled = false;
    }
    private void Update()
    {
        scoreText.text = scorePoint.ToString();
    }

    public void IncreaseScore()
    {
        scorePoint++;
    }
   
    public void GameOver()
    {
        spawner.enabled = false;
        
        RectTransform playButtonCor = playButton.GetComponent<RectTransform>();
        Vector2 playButtonPos = playButtonCor.anchoredPosition;
        playButtonPos.y =-50;
        playButtonCor.anchoredPosition = playButtonPos;

        imageGameOver.SetActive(true);

        Time.timeScale=0f;
        playButton.SetActive(true);
    }
    private void Play()
    {
        scorePoint = 0;
        Time.timeScale = 1f;
        spawner.enabled = true;
        playButton.SetActive(false);
        scoreText.enabled = true;
        imageGameOver.SetActive(false);
        playerSprite.enabled = true;
        ResetPlayer();
    }
    private void ResetPlayer()
    {
        player.transform.position = playerTransform;
        player.direction = Vector3.zero;
        DestroyAllPipes();
    }

    private void DestroyAllPipes()
    {
        GameObject[] Obstacles = GameObject.FindGameObjectsWithTag("Pipes");
        foreach (GameObject Obstacle in Obstacles)
        {
            Destroy(Obstacle);
        }
    }
    
}
