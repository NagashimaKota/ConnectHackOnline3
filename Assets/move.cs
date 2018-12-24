using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CnControls;

public class move : MonoBehaviour {

    private float input_hight, input_side;
    private float speed = 0.2f;     // PLの移動速度
    private float speed_low = 0.4f; //上のspeedの倍率
    private float timeCount = 0;

    private int chizeCount = 0;
    private int endTime = 30;

    private Vector3 chizePos;
    private Transform pl, chize;
    private Text score, time;
    

	void Start () {
        pl = GameObject.Find("PL").GetComponent<Transform>();
        chize = GameObject.Find("chize").GetComponent<Transform>();
        score = GameObject.Find("Text").GetComponent<Text>();
        //time = GameObject.Find("Text (1)").GetComponent<Text>();

        chizePos = chize.position;
        PlayerPrefs.SetInt("score", 0);
    }
	

	void Update () {
        if(chize.position.y > -1.5)
        {
            chize.Translate(0, -0.1f, 0);
        }
        
        input_hight = Input.GetAxis("Vertical");
        input_side = Input.GetAxis("Horizontal") * speed;
        

        //キーボード操作
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            pl.position = new Vector3(pl.position.x + input_side * speed_low, pl.position.y, 0);
            
        }
        else
        {
            pl.position = new Vector3(pl.position.x + input_side, pl.position.y, 0);
        }
        
        /* 時間制限
        timeCount += Time.deltaTime;
        time.text = "　　Time：" + (endTime - timeCount).ToString("##");
        
        if (timeCount >= endTime)
        {
            SceneManager.LoadScene("END");
        }
        */

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("end"))
        {
            chize.position = new Vector3(7, -1.5f, 0);
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            chize.position = new Vector3(pl.position.x + chize.localScale.x * 0.8f, -1.5f, 0);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("end") && chize.position.x < -6)
        {
            pl.transform.Rotate(0, 0, 0);
            ScoreCount();
            
        }

        if (other.gameObject.CompareTag("chize"))
        {
            pl.transform.Rotate(0, 180, 0);
        }
        
    }


    void ScoreCount()
    {
        pl.transform.Rotate(0, 180, 0);

        chizeCount++;
        score.text = chizeCount.ToString();
        PlayerPrefs.SetInt("score", chizeCount);

        if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("hiScore"))
        {
            PlayerPrefs.SetInt("hiScore", chizeCount);
        }

        
    }

}
