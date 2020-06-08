using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInfoAndReturn : MonoBehaviour
{
    public GameObject ScoreYourObj;
    public GameObject ArrowAll;
    public Rigidbody ObjectRB;
    public static int RandomedSpeedMult = 0;
    public static int ScoreYour;
    void OnCollisionEnter(Collision ArrowToWall)
    {
        Debug.Log(ArrowToWall.collider.name);
        RandomedSpeedMult = Random.Range(4, 15);
        ArrowAll.transform.position = new Vector3(-1.65f, 1.25f, 14f);
        if (ArrowToWall.collider.name != "WallWood")
        {
            switch (ArrowToWall.gameObject.tag)
            {
                case "1":
                    ScoreYour += 1;
                    break;
                case "2":
                    ScoreYour += 2;
                    break;
                case "3":
                    ScoreYour += 3;
                    break;
                case "4":
                    ScoreYour += 4;
                    break;
                case "5":
                    ScoreYour += 5;
                    break;
                case "6":
                    ScoreYour += 6;
                    break;
                case "7":
                    ScoreYour += 7;
                    break;
                case "8":
                    ScoreYour += 8;
                    break;
                case "9":
                    ScoreYour += 9;
                    break;
                case "10":
                    ScoreYour += 10;
                    break;
                case "11":
                    ScoreYour += 11;
                    break;
                case "12":
                    ScoreYour += 12;
                    break;
                case "13":
                    ScoreYour += 13;
                    break;
                case "14":
                    ScoreYour += 14;
                    break;
                case "15":
                    ScoreYour += 15;
                    break;
                case "16":
                    ScoreYour += 16;
                    break;
                case "17":
                    ScoreYour += 17;
                    break;
                case "18":
                    ScoreYour += 18;
                    break;
                case "19":
                    ScoreYour += 19;
                    break;
                case "20":
                    ScoreYour += 20;
                    break;
                case "21":
                    ScoreYour += 21;
                    break;
                case "22":
                    ScoreYour += 22;
                    break;
                case "24":
                    ScoreYour += 24;
                    break;
                case "26":
                    ScoreYour += 26;
                    break;
                case "27":
                    ScoreYour += 27;
                    break;
                case "28":
                    ScoreYour += 28;
                    break;
                case "30":
                    ScoreYour += 30;
                    break;
                case "32":
                    ScoreYour += 32;
                    break;
                case "34":
                    ScoreYour += 34;
                    break;
                case "36":
                    ScoreYour += 36;
                    break;
                case "38":
                    ScoreYour += 38;
                    break;
                case "40":
                    ScoreYour += 40;
                    break;
                case "42":
                    ScoreYour += 42;
                    break;
                case "45":
                    ScoreYour += 45;             
                    break;
                case "48":
                    ScoreYour += 48;
                    break;
                case "51":
                    ScoreYour += 51;
                    break;
                case "54":
                    ScoreYour += 54;
                    break;
                case "57":
                    ScoreYour += 57;
                    break;
                case "60":
                    ScoreYour += 60;
                    break;
                case "25":
                    ScoreYour += 25;
                    break;
                case "50":
                    ScoreYour += 50;
                    break;  
                default:
                    break;
            }
            ScoreYourObj.GetComponent<TextMesh>().text = "Score: " + ScoreYour;
            GarbageNet.ScoreMy = "Score: " + ScoreYour;
        }
    }
}
