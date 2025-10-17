using UnityEngine;

public class TurnManager : MonoBehaviour
{
    //TODO LINK NAAR SCRIPT 
    AllPlayersSpawning spawn;
    NextTurn next;
    int actionCount = 0;
    bool actionAttack = false;
    int baseActionCount = 2;
    int turnIndex = 0;
    int maxTurnIndex = 0;
    int turnsElapsed = 0;
    GameObject currentPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SCRIPT LINKEN
        spawn = FindAnyObjectByType<AllPlayersSpawning>();
        next = FindAnyObjectByType<NextTurn>();
        maxTurnIndex = spawn.AllSpawnedPlayers.Count;

        ResetTurns();
    }


    private void FixedUpdate()
    {
        if (actionCount == 2)
        {
            EndOfTurn();
        }
        if (turnIndex == maxTurnIndex)
        {
            ResetTurns();
        }
        
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

    private void EndOfTurn()
    {
        actionCount = baseActionCount;
        actionAttack = false;
        turnsElapsed++;
        currentPlayer = spawn.AllSpawnedPlayers[turnIndex];
        next.SetCam(currentPlayer);
        //LINK CURRENT PLAYER FROM LIST
        // for everyone but current character turn off the input system component

    }

    private void ResetTurns()
    {
        turnsElapsed = 0;
        currentPlayer = spawn.AllSpawnedPlayers[0];
        next.SetCam(currentPlayer);
    }
}
