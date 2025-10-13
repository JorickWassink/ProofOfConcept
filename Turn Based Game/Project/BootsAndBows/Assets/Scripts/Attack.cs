using UnityEngine;

public class Attack : MonoBehaviour
{
    //references itll need
    //the character for range
    private float attackRange = 5f;
    private Camera cam;
    //the mouse to find and track clicks (unless this can be done with the new input system)

    // Update is called once per frame
    void Update()
    {
        //update will function as while attack option is selected cus that has not been made yet
        //when u click
        if (Input.GetMouseButtonDown(0))
        {
            HandleAttackClick();
        }
        
    }
    void HandleAttackClick()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // draw the ray for debugging
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.yellow, 1f);
        // See if you clicked an enemy
        if (Physics.Raycast(ray, out hit))
        {
            // See if raycast hits the enemy
            Debug.Log("Clicked on: " + hit.collider.name);

            // see if the hit is within range
            float distance = Vector3.Distance(transform.position, hit.point);
            if (distance <= attackRange)
            {
                // if yes, deal 1 damage (placeholder)
                Debug.Log("Target in range! (Would deal 1 damage)");
            }
            else
            {
                Debug.Log("Target out of range.");
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        // visualize attack range in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
