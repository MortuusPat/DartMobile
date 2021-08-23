using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetup : MonoBehaviour
{
    public InputField input;
    public Toggle isPlaying;
    public Player player;
    void Start()
    {
        
        
        //input.onValueChanged.AddListener(delegate { EditChangeCheck(); });
    }

    void Update()
    {
        if (isPlaying.isOn == true)
        {
            player.isPlaying = true;
            input.readOnly = false;
            input.interactable = true;
        }

        if (isPlaying.isOn == false)
        {
            player.isPlaying = false;
            input.readOnly = true;
            input.interactable = false;
            
        }
    }

    public void EditChangeCheck()
    {
        Debug.Log("Updated!!");
        //input.onValueChanged.RemoveAllListeners();
        player.name = input.text;
        
    }
}
