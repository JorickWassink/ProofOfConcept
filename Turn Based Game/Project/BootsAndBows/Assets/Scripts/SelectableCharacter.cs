using UnityEngine;
using UnityEngine.AI;

public class SelectableCharacter : MonoBehaviour
{
    public bool isSelected = false;
    public float moveRange = 10f;
    public float attackRange = 5f;
    private SpriteRenderer sr;
    private RangeCircle rangeCircle;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        rangeCircle = GetComponent<RangeCircle>();
        rangeCircle.DrawCircle(moveRange);

        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        rangeCircle.Show(isSelected);
        if (isSelected)
        {
            sr.color = Color.yellow;

        }
        else
        {
            sr.color = Color.white;
        }
    }
}
