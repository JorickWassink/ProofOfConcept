using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    Vector2 targetPosition;
    private SelectableCharacter selectedCharacter;
    bool isMoving;
    

    private void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && !isMoving)
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
                    print(sp.color);
                    BaseCharracterTakeDamage damage = hit.collider.GetComponent<BaseCharracterTakeDamage>();   
                    damage.TakeDamage(gameObject.GetComponent<BaseCharacterInfo>().damage);
                    Debug.Log("Holy shit je damaged deze guy");
                    return;
                }
            }

            if (selectedCharacter != null)
            {
                float distance = Vector2.Distance(selectedCharacter.transform.position, mousePos);
                if (distance > selectedCharacter.moveRange)
                {
                    Debug.Log("buiten move range");
                    return;
                }

                targetPosition = mousePos;
                isMoving = true;
            }
        }

        if (isMoving && selectedCharacter != null && selectedCharacter.isSelected)
        {
            NavMeshAgent agent = selectedCharacter.GetComponent<NavMeshAgent>();
            agent.SetDestination(targetPosition);

            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                isMoving = false;
            }
        }
    }
}
