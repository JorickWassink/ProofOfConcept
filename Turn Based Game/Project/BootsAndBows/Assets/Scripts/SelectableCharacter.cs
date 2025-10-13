using UnityEngine;
using UnityEngine.AI;

public class SelectableCharacter : MonoBehaviour
{
    public bool isSelected = false;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if (isSelected)
            sr.color = Color.yellow;
        else
            sr.color = Color.white;
    }
}
