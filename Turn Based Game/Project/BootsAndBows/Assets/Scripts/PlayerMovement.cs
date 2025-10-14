using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    Vector2 targetPosition;
    private SelectableCharacter selectedCharacter;
    bool isMoving;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = mousePos;


            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider != null && hit.collider.GetComponent<SelectableCharacter>())
            {
                if (selectedCharacter != null)
                    selectedCharacter.isSelected = false;

                selectedCharacter = hit.collider.GetComponent<SelectableCharacter>();
                selectedCharacter.isSelected = true;
                isMoving = false;
            }

            else if (selectedCharacter != null)
            {
                targetPosition = mousePos;
                isMoving = true;
            }
        }

        if (isMoving && selectedCharacter != null && selectedCharacter.isSelected)
        {
            NavMeshAgent agent = selectedCharacter.GetComponent<NavMeshAgent>();
            agent.SetDestination(targetPosition);
        }
    }
}
