using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GarbageNet : MonoBehaviour, IPunObservable
{
    public PhotonView photonView;
    public bool GameFlag;
    public static string ScoreOpp = "";
    public static string ScoreMy = "";
    public GameObject ScoreOppObj;
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(GameFlag);
            stream.SendNext(ScoreMy);
        }
        else
        {
            GameFlag = (bool)stream.ReceiveNext();
            ScoreOpp = (string)stream.ReceiveNext();
        }

    }
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        Game.players.Add(this);
        ScoreOppObj = GameObject.Find("ScoreOpp");
    }

    void Update()
    {
        ScoreOppObj.GetComponent<TextMesh>().text = ScoreOpp;
        if (photonView.IsMine)
        {
            if (Input.GetKey("space"))
            {
                GameFlag = true;
            }
        }

    }
}
