using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public static PrefabManager Instance { get; private set; }

    [SerializeField] public GameObject Rock;

    [SerializeField] public GameObject Paper;

    [SerializeField] public GameObject Scissor;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }
}
