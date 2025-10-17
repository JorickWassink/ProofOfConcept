using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip gameBackgroundMusic;
    [SerializeField] public AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayMusic(gameBackgroundMusic);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (audioSource.clip == clip) return;

        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }
}