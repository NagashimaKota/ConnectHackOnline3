using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cheese : MonoBehaviour {


    private float input_hight, input_side;
    private float speed = 0.2f;     // PLの移動速度
    private float speed_low = 0.4f; //上のspeedの倍率
    private float timeCount = 0;

    private int chizeCount = 0;
    private int endTime = 30;

    private Vector3 chizePos;
    private Transform pl, chize;
    private Text score;

    void Start () {
        pl = GameObject.Find("PL").GetComponent<Transform>();
        chize = GameObject.Find("chize").GetComponent<Transform>();
        score = GameObject.Find("Text").GetComponent<Text>();

        chizePos = chize.position;
        PlayerPrefs.SetInt("score", 0);
    }
	

	void Update () {
        if (chize.position.y > -1.5)
        {
            chize.Translate(0, -0.1f, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
