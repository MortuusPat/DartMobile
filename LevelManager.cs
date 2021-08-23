using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    PlayerManagement playerManagement;
    Player pPlayer;
    GameObject jJudge;
    bool startFromNew = false;
    private AsyncOperation sceneAsync;


    public void Start()
    {
        playerManagement = PlayerManagement.instance;
    }
    
    public void RestartGameAtNew(bool newgame)
    {
        startFromNew = newgame;
        StartCoroutine(loadScene("Lobby", "GameOver"));
    }

    public void NewGame()
    {
        StartCoroutine(loadScene("GameSetup", "Lobby"));
        
    }

    public void StartGame()
    {
        StartCoroutine(loadScene("GameWindow", "GameSetup"));
        

    }
    public void EndTurnToScoreScreen()
    {
        if(Judge.instance.round == 18)
        {
            StartCoroutine(loadScene("GameOver", "GameWindow"));
        }
        else
        {
            StartCoroutine(loadScene("ScoreScreen", "GameWindow"));
        }
        


    }
    public void NextPlayer()
    {
        Debug.Log("Hvaaa");
        StartCoroutine(loadScene("GameWindow", "ScoreScreen"));


    }

    IEnumerator loadScene(string SceneName, string lastScene)
    {
    AsyncOperation scene = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
    scene.allowSceneActivation = true;
    sceneAsync = scene;
    
    //Wait until we are done loading the scene
   

        while (!scene.isDone)
        {
            Debug.Log("Loading scene " + " [][] Progress: " + scene.progress);
            yield return null;
        }

        //Activate the Scene
        sceneAsync.allowSceneActivation = true;

    Scene thisScene = SceneManager.GetSceneByName(SceneName);

        if (thisScene.IsValid())
        {
            Debug.Log("Scene is Valid");
        
            foreach(GameObject player in playerManagement.players)
            {
                Debug.Log("Foreach");

                if (player != null)
                {
                    pPlayer = player.GetComponent<Player>();
                    if (pPlayer.isPlaying == true)
                    {
                        Debug.Log(pPlayer.name + " is playing: " + pPlayer.isPlaying);
                        player.tag = "Player";
                        if(startFromNew == true)
                        {
                            Destroy(player);
                        }
                        else
                        {
                            SceneManager.MoveGameObjectToScene(player, thisScene);
                        }
                        
                    }
                    
                }

            }
            if (jJudge == null)
            {
                jJudge = GameObject.FindGameObjectWithTag("Judge");
            }
            if (startFromNew == true)
            {
                Destroy(jJudge);
            }
            else
            {
                SceneManager.MoveGameObjectToScene(jJudge, thisScene);
            }
            
            startFromNew = false;
            SceneManager.SetActiveScene(thisScene);
            SceneManager.UnloadSceneAsync(lastScene);
        
        }
        else
        {
        Debug.Log("Invalid scene!!");
        }
        
    }
}
