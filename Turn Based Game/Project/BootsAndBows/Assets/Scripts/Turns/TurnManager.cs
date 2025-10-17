using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    //TODO LINK NAAR SCRIPT 
    AllPlayersSpawning spawn;
    NextTurn next;
    int actionCount = 0;
    bool actionAttack = false;
    int baseActionCount = 0;
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


    private void Update()
    {
        if (actionCount == 2)
        {
            EndOfTurn();
        }
        //if (turnIndex == maxTurnIndex)
        //{
        //    ResetTurns();
        //}
        print(actionCount);
    }

    /// <summary>
    /// set the parameter to true if the action performed is an attack
    /// </summary>
    /// <param name="attack"></param>
    public void ActionCountDown(bool attack = false)
    {
        if (attack && !actionAttack)
        {
            actionAttack = true;
            print("action performed");
            actionCount++;
        }
        else if (!attack)
        {
            actionCount++;
            print("action performed");
        }

    }
    private void EndOfTurn()
    {
        
        actionCount = baseActionCount;
        actionAttack = false;
        turnsElapsed++;
        if (turnsElapsed != maxTurnIndex)
        {
            currentPlayer = spawn.AllSpawnedPlayers[turnsElapsed];
        }
        else
        {
            ResetTurns();
        }
            Invoke("SetCam", 1);
        //LINK CURRENT PLAYER FROM LIST
        
        foreach(GameObject player in spawn.AllSpawnedPlayers)
        {
           if (player != currentPlayer)
            {
                for (int i = 0; i < 3; i++)
                {
                    player.transform.GetChild(i).GetComponent<SelectableCharacter>().enabled = false;
                }
            }
           else
            {
                for (int i = 0; i < 3; i++)
                {
                    player.transform.GetChild(i).GetComponent<SelectableCharacter>().enabled = true;
                }
            }
        }

        // for everyone but current character turn off the input system component

    }

    private void ResetTurns()
    {
        currentPlayer = spawn.AllSpawnedPlayers[0];

        foreach (GameObject player in spawn.AllSpawnedPlayers)
        {
            print("pepperoni");
            if (player != currentPlayer)
            {
                for (int i = 0; i < 3; i++)
                {
                    print("pepperoni 2");
                    player.transform.GetChild(i).GetComponent<SelectableCharacter>().enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    print("pepperoni 3");
                    player.transform.GetChild(i).GetComponent<SelectableCharacter>().enabled = true;
                }
            }
        }
        turnsElapsed = 0;
        Invoke("SetCam", 1);
        
    }

    [SerializeField] GameObject scriptHolder;
    public void SetCam()
    {
        Instantiate(scriptHolder, currentPlayer.transform);
    }
}
