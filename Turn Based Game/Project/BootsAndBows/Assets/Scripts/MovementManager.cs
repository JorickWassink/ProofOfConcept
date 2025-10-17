using UnityEngine;
using UnityEngine.AI;

public class MovementManager : MonoBehaviour
{
    Vector2 targetPosition;
    private SelectableCharacter selectedCharacter;
    bool isMoving;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                SelectableCharacter sc = hit.collider.GetComponent<SelectableCharacter>();
                SpriteRenderer sp = hit.collider.GetComponent<SpriteRenderer>();

                if (sc != null && sc.enabled)
                {
                    if (selectedCharacter != null)
                        selectedCharacter.isSelected = false;

                    selectedCharacter = sc;
                    selectedCharacter.isSelected = true;
                    isMoving = false;
                    return;
                }

                if (sc != null && !sc.enabled && selectedCharacter != null)
                {
                    float distToEnemy = Vector2.Distance(selectedCharacter.transform.position, sc.transform.position);
                    if (distToEnemy <= selectedCharacter.attackRange)
                    {
                        Debug.Log("Damage");
                    }
                    else
                    {
                        Debug.Log("Deze guy is te ver weg");
                    }
                    return;
                }
            }

            if (selectedCharacter != null)
            {
                float distance = Vector2.Distance(selectedCharacter.transform.position, mousePos);
                if (distance > selectedCharacter.moveRange)
                {
                    Debug.Log("Buiten move range");
                    return;
                }

                targetPosition = mousePos;
                isMoving = true;
            }
        }

        if (isMoving && selectedCharacter != null && selectedCharacter.isSelected)
        {
            NavMeshAgent agent = selectedCharacter.GetComponent<NavMeshAgent>();
            if (agent == null)
            {
                Debug.LogWarning("character heeft geen NavMeshAgent!");
                isMoving = false;
                return;
            }

            agent.SetDestination(targetPosition);

            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                isMoving = false;
            }
        }
    }
}
