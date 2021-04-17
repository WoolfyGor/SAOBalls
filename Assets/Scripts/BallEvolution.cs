using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEvolution : MonoBehaviour
{
   public GameObject ball2, ball3, ball4, ball5, ball6, ball7, ball8, ball9;
   public  int thisNumber;
    GameObject RightBall, SpawnArea;

    BallEvolution ba;
    SpawnScript SA;
    public bool Spawner = true;
    // Start is called before the first frame update
    private void Start()
    {
           SpawnArea = GameObject.FindGameObjectWithTag("SpawnArea");
           thisNumber = Convert.ToInt32(name.Substring(4));
        SA = SpawnArea.GetComponent<SpawnScript>();
        if (name != "Ball1")
        {
            this.GetComponent<AudioSource>().Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == name)
        {
            ba = collision.gameObject.GetComponent<BallEvolution>();
            if (collision.transform.position.y < transform.position.y)
            {
                ba.Spawner = false;
            }
            else { Spawner = false; };
      
       
            if (Spawner) { 
            SpawnBall(thisNumber, GetRightObj(thisNumber));
                SA.AddScore(this.thisNumber);
            }
           
                Destroy(gameObject);
            

        }
    }
    void SpawnBall(int ThisNumber, GameObject ball)
    {
        GameObject NewChild = Instantiate(ball, transform) as GameObject;
        NewChild.transform.parent = null;
        NewChild.transform.localScale = GetRightScale(ThisNumber); 
        NewChild.name = ball.name;
      
    }
    Vector3 GetRightScale(int thisNuber)
    {
        Vector3 RightScale = new Vector3(0.22f, 0.22f);
        switch (thisNuber)
        {
            case 1:
                RightScale = new Vector3(0.22f, 0.22f);
                break;

            case 2:
                RightScale = new Vector3(0.24f, 0.24f);
                break;

            case 3:
                RightScale = new Vector3(0.26f, 0.26f);
                break;

            case 4:
                RightScale = new Vector3(0.28f, 0.28f);
                break;

            case 5:
                RightScale = new Vector3(0.4f, 0.4f);
                break;

            case 6:
                RightScale = new Vector3(0.42f, 0.42f);
                break;

            case 7:
                RightScale = new Vector3(0.44f, 0.44f);
                break;

            case 8:
                RightScale = new Vector3(0.46f, 0.46f);
                break;
        }
        return RightScale;
    }
    GameObject GetRightObj (int thisNumber)
    {
        GameObject ball = ball2 ;
        switch (thisNumber)
        {
            case 1:
                ball = ball2;
                break;

            case 2:
                ball = ball3;
                break;

            case 3:
                ball = ball4;
                break;

            case 4:
                ball = ball5;
                break;

            case 5:
                ball = ball6;
                break;

            case 6:
                ball = ball7;
                break;

            case 7:
                ball = ball8;
                break;

            case 8:
                ball = ball9;
              
                break;
        }
        return ball;
   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DebugArea")
        {
            transform.position = SpawnArea.transform.position;
        }
    }
}
