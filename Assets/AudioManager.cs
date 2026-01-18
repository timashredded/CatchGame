using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;

    public AudioClip catchSound;
    public AudioClip errorSound;
    public AudioClip gameOverSound;

    void Awake()
    {
        Instance = this;

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }


    public void PlayCatch()
    {
        audioSource.PlayOneShot(catchSound);
    }

    public void PlayError()
    {
        audioSource.PlayOneShot(errorSound);
        Handheld.Vibrate();
    }

    public void PlayGameOver()
    {
        audioSource.PlayOneShot(gameOverSound);
        Handheld.Vibrate();
    }
}
