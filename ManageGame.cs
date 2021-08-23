using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ManageGame : MonoBehaviour
{
    int shotOne, shotTwo, shotThree, currentRound;
    public InputField objectiveOne, objectiveTwo, objectiveThree, round;
    public Toggle toggleOne, toggleTwo, toggleThree, t1x2, t1x3, t2x2, t2x3, t3x2, t3x3;
    public Text turn;
   
    double multiplier = 1f;
    double points = 10f;

    
    PlayerManagement playerManagement;
    Player pPlayer;

    void Start()
    {
        
        
        Debug.Log("Start");
        currentRound = Judge.instance.round;
        
        playerManagement = PlayerManagement.instance;
        
        Invoke("PlayingPlayer", 0.25f);

        
       

        

       


    }

    public void EndTurn()
    {
        GivePoints();
        Judge.instance.NextTurn();

        Debug.Log("Round Turn Counted: " + Judge.instance.turn);

    }

    void GivePoints()
    {
        if (toggleOne.isOn == true)
        {
            multiplier = multiplier + 0.50f;

        }
        if (t1x2.isOn == true)
        {
            multiplier = multiplier + 1f;
        }
        if (t1x3.isOn == true)
        {
            multiplier = multiplier + 2f;
        }
        if (toggleTwo.isOn == true)
        {
            multiplier = multiplier + 0.50f;
        }
        if (t2x2.isOn == true)
        {
            multiplier = multiplier + 1f;
        }
        if (t2x3.isOn == true)
        {
            multiplier = multiplier + 2f;
        }
        if (toggleThree.isOn == true)
        {
            multiplier = multiplier + 0.50f;
        }
        if (t3x2.isOn == true)
        {
            multiplier = multiplier + 1f;
        }
        if (t3x3.isOn == true)
        {
            multiplier = multiplier + 2f;
        }
        points = points * multiplier;
        pPlayer.score = pPlayer.score + points;
        points = 10f;
        multiplier = 1f;

    }
    void PlayingPlayer()
    {
        
        foreach (GameObject player in playerManagement.players)
        {
            
            GenerateNumbers();
            if (player != null)
            {
                pPlayer = player.GetComponent<Player>();
                Debug.Log("Player Found!");
                if (pPlayer.hadTurn == false)
                {
                    Debug.Log("Player has a turn");
                    turn.text = pPlayer.name + "'s turn";
                    round.text = currentRound.ToString();
                    pPlayer.hadTurn = true;
                    Debug.Log("Player is done. Waiting for Player to click next");
                    break;
                    
                }
                


            }

            
            



        }
        




    }
    

    void GenerateNumbers()
    {
        Debug.Log("Generate");
        shotOne = Random.Range(1, 21);
        shotTwo = Random.Range(1, 21);
        while(shotTwo == shotOne)
        {
            shotTwo = Random.Range(1, 21);
        }
        shotThree = Random.Range(1, 21);
        while (shotThree == shotTwo || shotThree == shotOne)
        {
            shotThree = Random.Range(1, 21);
        }



        ApplyToUI();

    }

    void ApplyToUI()
    {
        Debug.Log("Apply");
        objectiveOne.text = shotOne.ToString();
        objectiveTwo.text = shotTwo.ToString();
        objectiveThree.text = shotThree.ToString();


    }

    

    
}
