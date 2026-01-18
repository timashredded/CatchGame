using UnityEngine;

public class Food : MonoBehaviour
{
    public Sprite[] foodSprites;
    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale *= GameManager.Instance.fallSpeedMultiplier;

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (foodSprites.Length > 0)
        {
            int randomIndex = Random.Range(0, foodSprites.Length);
            spriteRenderer.sprite = foodSprites[randomIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Courier"))
        {
            ScoreManager.Instance.AddScore(1);
            AudioManager.Instance.PlayCatch();
            Destroy(gameObject);
        }
    }
}
