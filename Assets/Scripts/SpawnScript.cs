using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnScript : MonoBehaviour
{
    public GameObject ball1, ball2, ball3;
    Transform SpawnPos;
    Text ScoreText;
    int Score = 0;
    bool CanClick = true;
    // Start is called before the first frame update
    private void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        ScoreText.text = Score.ToString();
    }
    void OnMouseDown()
    {
        if (CanClick) { 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        GameObject obj = Instantiate(ball1, new Vector3(ray.origin.x, ray.origin.y, 0), Quaternion.identity) as GameObject;
        obj.name = "Ball1";
        CanClick = false;
        StartCoroutine("ResumeClick");
        }
    }
    public void AddScore(int number)
    {
        Score += number;
        ScoreText.text = Score.ToString();
    }
    IEnumerator ResumeClick()
    {

        yield return new WaitForSeconds(0.4f);
        CanClick = true;
        yield return null;
    }
    }
