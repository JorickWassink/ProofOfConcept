using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip gameBackgroundMusic;
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayMusic(gameBackgroundMusic);
    }

    void PlayMusic(AudioClip clip)
    {
        if (audioSource.clip == clip) return;
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }
}
