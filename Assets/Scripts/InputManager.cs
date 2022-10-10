using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    //GameObject player;
    Vector3 dir;
    Quaternion rot;

    // Use this for initialization
    void Start () {
        //player = GameObject.Find("UTC_Default");
        dir = new Vector3();
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Walk"))
        {
            GetComponent<Movetest>().Walking(true);
        }
        if (Input.GetButtonUp("Walk"))
        {
            GetComponent<Movetest>().Walking(false);
        }

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            dir.x = h;
            dir.z = v;

            if(dir != Vector3.zero)
                rot = Quaternion.LookRotation(dir);

            GetComponent<Movetest>().MoveToward(rot);
        }
        else
        {
            //GetComponent<UnitychanAnimScript>().SetState(0);
        }

        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Movetest>().Jump();
        }

        if (Input.GetButtonDown("Start"))
        {
            //Debug.Log("enter");
            GetComponent<Movetest>().Play();
            GetComponent<QCTManager>().AllPlay();         
        }
    }
}
