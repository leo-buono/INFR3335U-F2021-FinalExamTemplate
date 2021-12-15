using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelHandler : MonoBehaviour
{
    private void Start() 
    {
        LobbyPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
    public GameObject LobbyPanel;
    public GameObject MainMenuPanel;

    // Update is called once per frame
    public void OnCreateLobbyClick()
    {
        LobbyPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
    public void OnJoinLobbyClick()
    {
        LobbyPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void OnLeaveLobbyClick()
    {
        //Run the loading scene
        SceneManager.LoadScene("Lobby");
    }

    public void OnCreateGameClick()
    {
        //Load game
        SceneManager.LoadScene("Arena");
    }
}
