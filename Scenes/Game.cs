using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Specialized;
using UnityEngine.UI;

public class Game : MonoBehaviourPunCallbacks
{
    public GameObject Plate;
    public GameObject Arrow;
    public GameObject WaitingText;
    public GameObject PushText;
    public GameObject Player2Text;
    public GameObject TextOpp;

    float ArrowXDefault = 0f;
    float ArrowYDefault = 1.25f;
    float ArrowZDefault = 13f;

    float Player2XDefault = -13.5f;
    float Player2YDefault = 4.34f;
    float Player2ZDefault = 4f;

    float ScoreOppX = 9.89f;
    float ScoreOppY = 6f;
    float ScoreOppZ = -4f;
    public static bool ButtonStart = false;
    public static int ticks = 0;
    public static int ticksrotate = 0;
    public float moveSpeed = 0.01f;
    public bool GameOn = false;

    public static float RandomedSpeedMultXY = 0;
    public static float RandomedSpeedMultX = 0;
    public static float RandomedSpeedMultY = 0;
    public static int RandomedSpeedMultZ = 0;
    public static int RandomedSpeedMultRotate = 0;


    public static List<GarbageNet> players = new List<GarbageNet>();

    void Start()
    {
        RandomedSpeedMultZ = Random.Range(4, 15);
        GameObject HostArrow1 = Instantiate(Arrow, new Vector3(ArrowXDefault - 0.2f, ArrowYDefault, ArrowZDefault), Quaternion.Euler(270, 0, 0));
        GameObject HostArrow2 = Instantiate(Arrow, new Vector3(ArrowXDefault, ArrowYDefault, ArrowZDefault), Quaternion.Euler(270, 0, 0));
        GameObject HostArrow3 = Instantiate(Arrow, new Vector3(ArrowXDefault + 0.2f, ArrowYDefault, ArrowZDefault), Quaternion.Euler(270, 0, 0));
        if (!PhotonNetwork.IsMasterClient)
        {
            GameObject Player2TextCreated = Instantiate(Player2Text, new Vector3(Player2XDefault, Player2YDefault, Player2ZDefault), Quaternion.Euler(180, 0, 180));
            GameObject PlayerArrow1 = Instantiate(Arrow, new Vector3(ArrowXDefault - 0.2f - 4.2f, ArrowYDefault, ArrowZDefault), Quaternion.Euler(270, 0, 0));
            GameObject PlayerArrow2 = Instantiate(Arrow, new Vector3(ArrowXDefault - 4.2f, ArrowYDefault, ArrowZDefault), Quaternion.Euler(270, 0, 0));
            GameObject PlayerArrow3 = Instantiate(Arrow, new Vector3(ArrowXDefault + 0.2f - 4.2f, ArrowYDefault, ArrowZDefault), Quaternion.Euler(270, 0, 0));
            Destroy(WaitingText);
            PushText.transform.position = new Vector3(-3.5f, 1.25f, 3.5f);
        }
        players.Clear();
        PhotonNetwork.Instantiate("NetPl", new Vector3(-100f,-100f,-100f), Quaternion.identity);
        TextOpp.transform.position = new Vector3(-4f, 6f, 3f);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Arrow != null && GameOn)
        {
            ticks++;
            ticksrotate++;
            Plate.transform.Rotate(new Vector3(0, 40, 0) * Time.deltaTime * RandomedSpeedMultRotate, Space.Self);
            Arrow.transform.Translate(RandomedSpeedMultXY * moveSpeed * -Input.GetAxis("Horizontal") * Time.deltaTime, RandomedSpeedMultXY * moveSpeed * -Input.GetAxis("Vertical") * Time.deltaTime, RandomedSpeedMultZ * Time.deltaTime);
            if (ticksrotate == 120)
            {
                RandomedSpeedMultRotate = Random.Range(-3, 3);
                ticksrotate = 0;
            }
            if (ticks == 60)
            {
                RandomedSpeedMultXY = Random.Range(0.5f, 2f);
                RandomedSpeedMultZ = Random.Range(4, 15);
                ticks = 0;
            }
        }
        if (players.Count == 2)
        {
            if (players[0].GameFlag && players[1].GameFlag)
            {
                GameOn = true;
                Destroy(PushText);
            }
                
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player otherPlayer)
    {
        GameObject Player2TextCreated = Instantiate(Player2Text, new Vector3(Player2XDefault, Player2YDefault, Player2ZDefault), Quaternion.Euler(180, 0, 180));
        GameObject PlayerArrow1 = Instantiate(Arrow, new Vector3(ArrowXDefault - 0.2f - 4.2f, ArrowYDefault, ArrowZDefault), Quaternion.Euler(270, 0, 0));
        GameObject PlayerArrow2 = Instantiate(Arrow, new Vector3(ArrowXDefault - 4.2f, ArrowYDefault, ArrowZDefault), Quaternion.Euler(270, 0, 0));
        GameObject PlayerArrow3 = Instantiate(Arrow, new Vector3(ArrowXDefault + 0.2f - 4.2f, ArrowYDefault, ArrowZDefault), Quaternion.Euler(270, 0, 0));
        Destroy(WaitingText);
        PushText.transform.position = new Vector3(-3.5f, 1.25f, 3.5f);
    }

}

