using UnityEngine;

public class NextTurn : MonoBehaviour
{
    [SerializeField] GameObject scriptHolder;
    public void SetCam(GameObject currentPlayer)
    {
        Instantiate(scriptHolder,currentPlayer.transform);
    }


}
