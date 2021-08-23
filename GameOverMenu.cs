using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Button button, rButton, cButton;
    public Text rText, cText;
    public Image backgroundFade, menu, rImage, cImage;
    public void ShowEndMenu()
    {
        button.interactable = false;
        backgroundFade.enabled = true;
        menu.enabled = true;
        rButton.enabled = true;
        cButton.enabled = true;
        rText.enabled = true;
        cText.enabled = true;
        rImage.enabled = true;
        cImage.enabled = true;
    }

    public void Cancel()
    {
        button.interactable = true;
        backgroundFade.enabled = false;
        menu.enabled = false;
        rButton.enabled = false;
        cButton.enabled = false;
        rText.enabled = false;
        cText.enabled = false;
        rImage.enabled = false;
        cImage.enabled = false;
    }
}
