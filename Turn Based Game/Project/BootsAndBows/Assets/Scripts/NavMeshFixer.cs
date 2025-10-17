using UnityEngine;
using UnityEngine.AI;

public class NavMeshFixer : MonoBehaviour
{
    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
}
