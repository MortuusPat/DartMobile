
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerManagement playerManagement;
    Player pPlayer;
    Player compareToPlayer;
    public InputField[] inputA;
    int index;
    public Text[] textA;
    public List<Player> sortedListofPlayer;
    


    void Start()
    {
        index = 0;
        playerManagement = PlayerManagement.instance;
        Invoke("UpdateScore", 0.25f);
        
    }




    void UpdateScore()
    {
        UpdateScoreBoard();
        
        foreach (Player player in sortedListofPlayer)
        {
            

            if (player != null)
            {
                
                if (player.isPlaying == true)
                {
                    
                    inputA[index].text = player.score.ToString();
                    textA[index].text = player.name.ToString();
                    index++;

                }

            }

        }

    }

    void UpdateScoreBoard()
    {

        sortedListofPlayer = new List<Player>();

        foreach (GameObject player in playerManagement.players)
        {

            pPlayer = player.GetComponent<Player>();
            sortedListofPlayer.Add(pPlayer);




            //if (player != null)
            //{
            //    pPlayer = player.GetComponent<Player>();
            //    if (pPlayer.isPlaying == true)
            //    {

            //        foreach (GameObject cPlayer in playerManagement.players)
            //        {
            //            compareToPlayer = cPlayer.GetComponent<Player>();
            //            if(compareToPlayer.isPlaying == true)
            //            {
            //                if(pPlayer.score > compareToPlayer.score)
            //                {
            //                    if(pPlayer.place == 0)
            //                    {
            //                        //playerManagement.Ord

            //                    }



            //                }


            //            }
            //        }

            //    }

            //}

        }
        sortedListofPlayer = sortedListofPlayer.OrderByDescending(player => player.score).ToList();
         
    }

   

}  