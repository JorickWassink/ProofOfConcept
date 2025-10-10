using UnityEngine;
using UnityEngine.UI;

public class AudioLevel : MonoBehaviour
{


    [SerializeField] Slider slid;
    [SerializeField] AudioSource source;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        source.volume = slid.value;
    }
}
