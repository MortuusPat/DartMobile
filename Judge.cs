using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    #region Singleton

    public static Judge instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    
    public int round = 1;
    public int turn = 0;
    
    Player pPlayer;




    public GameObject gameJudge;


    void Start()
    {
        
        Invoke("FindJudge", 0.1f);

    }




    void FindJudge()
    {


        
        if (gameJudge == null)
        {
            gameJudge = GameObject.FindGameObjectWithTag("Judge");
        }
        

    }





    public void NextTurn()
    {
        turn++;
        UpdateJudge();
    }

    public void UpdateJudge()
    {
        Debug.Log(PlayerManagement.instance.players.Length);
        Debug.Log("Fucking Knew it");
        if (turn == PlayerManagement.instance.players.Length)
        {
            round++;
            Debug.Log("NEW ROUND");
           
            turn = 0;

            Invoke("ResetTurns", 0.5f);

            ResetTurns();

        }
        
    }

    void ResetTurns()
    {
        Debug.Log("Her!!!");
        foreach (GameObject player in PlayerManagement.instance.players)
        {
            Debug.Log("Vi nåede da hertil");
            if (player != null)
            {
                pPlayer = player.GetComponent<Player>();
                pPlayer.hadTurn = false;
            }
        }
    }
    



}



