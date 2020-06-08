using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Connection : MonoBehaviourPunCallbacks
{
    public static bool test;
    public GameObject InputRoomText;
    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected!");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        string roomName = InputRoomText.GetComponent<Text>().text;
        if (!(PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default)))
             PhotonNetwork.CreateRoom(roomName + "2", roomOptions, TypedLobby.Default);

        }

    public override void OnJoinedRoom()
    {
       PhotonNetwork.LoadLevel("Game");
    }
}
