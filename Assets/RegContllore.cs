using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegContllore : MonoBehaviour {

    float start_pos = 10;
    float end_pos = 2.3f;
    float speed = -0.1f;
    float time = 0;
    float time_intabal = 3f;

    public GameObject PL;
    public GameObject chize;
    Transform reg;

    // Use this for initialization
	void Start ()
    {
        reg = GameObject.Find("reg").GetComponent<Transform>();
	}

    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (reg.position.y >= end_pos && time < time_intabal)
        {
            reg.Translate(0, speed, 0);
        }

        if (time > time_intabal && reg.position.y < start_pos)
        {
            reg.Translate(0, -speed, 0);
            
        }
        if (time > time_intabal * 2)
        {
            time = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);

        if (col.gameObject.CompareTag("chize"))
        {
            chize.transform.position = new Vector3(7, 10f,0);
        }
        else if (col.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("END");
        }
    }
}
