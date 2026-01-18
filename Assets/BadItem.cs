using UnityEngine;

public class BadItem : MonoBehaviour
{
    public Sprite[] badSprites;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private enum BadType
    {
        Bomb,
        Brick,
        Trash
    }

    private BadType currentType;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        // ускорение падения
        rb.gravityScale *= GameManager.Instance.fallSpeedMultiplier;

        SetupRandomBadItem();
    }

    void SetupRandomBadItem()
    {
        int randomType = Random.Range(0, 3);
        currentType = (BadType)randomType;

        spriteRenderer.sprite = badSprites[randomType];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Courier"))
        {
            ApplyEffect();
            Destroy(gameObject);
        }
    }

    void ApplyEffect()
    {
        switch (currentType)
        {
            case BadType.Bomb:
                GameManager.Instance.LoseLife();
                AudioManager.Instance.PlayError();
                break;

            case BadType.Brick:
                GameManager.Instance.LoseLife();
                AudioManager.Instance.PlayError();
                break;

            case BadType.Trash:
                GameManager.Instance.LoseLife();
                AudioManager.Instance.PlayError();
                break;
        }
    }
}
