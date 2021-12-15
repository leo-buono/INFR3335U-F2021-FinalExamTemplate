using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PanelHandler : MonoBehaviourPunCallbacks
{
    
    public InputField createInput;
    public InputField joinInput;
    // public Text Error;

    // string errorInfo = "Error!";

    // Start is called before the first frame update
    public override void OnJoinedRoom()
    {
        //PhotonNetwork.LoadLevel("SampleScene");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        //Error.text = message;
        Debug.Log("Failed to Create room!");
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        //Error.text = message;
        Debug.Log(message);
    }
    private void Start() 
    {
        LobbyPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
        PhotonNetwork.ConnectUsingSettings();
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
        SceneManager.LoadScene("Loading");
    }

    public void OnCreateGameClick()
    {
        //Load game
        PhotonNetwork.LoadLevel("Arena");
        //PhotonNetwork.JoinRoom(joinInput.text);
        if (string.IsNullOrEmpty(createInput.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(createInput.text);
    }
}
