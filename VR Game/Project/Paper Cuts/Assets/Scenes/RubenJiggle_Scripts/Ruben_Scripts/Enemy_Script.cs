using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    [Header("Target Settings")]
    public Transform target; // Optional: Set in Inspector

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // If following a target, update the destination every frame
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    void MoveToClickPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }

    // Call this from another script to move to a position
    public void MoveTo(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    // Call this from another script to follow a Transform
    public void Follow(Transform newTarget)
    {
        target = newTarget;
    }

    public void StopFollowing()
    {
        agent.ResetPath();
    }
}

