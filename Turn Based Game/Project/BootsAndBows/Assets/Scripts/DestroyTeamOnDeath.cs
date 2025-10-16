using UnityEngine;

public class DestoryTeamOnDeath : MonoBehaviour
{
    private void Update()
    {
        // Check if all child characters are gone
        if (transform.childCount == 0)
        {
            Debug.Log($"{name} eliminated!");
            Destroy(gameObject);
        }
    }
}
