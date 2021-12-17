using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    public Text playerName;
    private Player player;
    public void SetPlayerInfo(Player __player)
    {
        player = __player;
        playerName.text = __player.NickName;
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if(player == otherPlayer)
        {
            Destroy(gameObject);
        }
    }
    public override void OnLeftLobby()
    {
        Destroy(gameObject);
    }
}
