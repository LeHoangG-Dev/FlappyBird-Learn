using UnityEngine;

public class Player : MonoBehaviour
{
    private float gravity = -9.8f;
    private float strength = 4f;
    public Vector3 direction;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    private GameManager gameManager;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite),0.15f,0.15f);
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
       {
            direction = Vector3.up * strength;
       }
    }

    private void FixedUpdate()
    {
        direction.y += gravity * Time.deltaTime;
        transform.position += direction*Time.deltaTime;
    }

    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex =0;
        }
        if (spriteIndex >=0 && spriteIndex <sprites.Length)
        {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Score"))
        {
            gameManager.IncreaseScore();
        }
        if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Ground"))
        {
            gameManager.GameOver();
        }
    }
    
}
