using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    #region Singleton

    public static PlayerManagement instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject[] players;
    

    void Start()
    {
        Invoke("FindPlayers", 0.1f);
        
    }

  


    void FindPlayers()
    {



        if (players.Length == 0)
        {
            players = GameObject.FindGameObjectsWithTag("Player");
        }

    }

   
}
