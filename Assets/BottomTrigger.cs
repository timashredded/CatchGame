using UnityEngine;

public class BottomTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            GameManager.Instance.LoseLife();
            AudioManager.Instance.PlayError();
            Destroy(collision.gameObject);

        }
    }
}
