using UnityEngine;

public class TurnManager : MonoBehaviour
{
    //TODO LINK NAAR SCRIPT 
    int actionCount = 0;
    bool actionAttack = false;
    int baseActionCount = 2;
    int turnIndex = 0;
    GameObject currentPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SCRIPT LINKEN
        //LINK CURRENT PLAYER FROM LIST
        Reset();
    }

    /// <summary>
    /// set the parameter to true if the action performed is an attack
    /// </summary>
    /// <param name="attack"></param>
    public void ActionCountDown(bool attack)
    {
        if (attack && !actionAttack)
        {
            actionAttack = true;
            actionCount--;
        }
        else if (!attack)
        {
            actionCount--;
        }
        
    }

    private void Reset()
    {
        actionCount = baseActionCount;
        actionAttack = false;
        //
    }
}
