using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour {

    Camera movecam;
    Vector3 startpos, endpos;
    Quaternion startrot, endrot;
    float t;
    // Use this for initialization
    void Start () {
        movecam = GameObject.Find("MovingCamera").GetComponent<Camera>();
        startpos = movecam.transform.position;
        startrot = movecam.transform.rotation;
        //startpos = new Vector3(0, 26, 0);
        //startrot = Quaternion.Euler(90, 180, 180);
        //endpos = GameObject.Find("MovePoint").transform.position;
        //endrot = GameObject.Find("MovePoint").transform.rotation;
        t = 0;
	}
	
	// Update is called once per frame
	void Update () {

        CameraMove();
        
    }

    void CameraMove()
    {
        movecam.transform.position = Vector3.Lerp(startpos, endpos, t);
        movecam.transform.rotation = Quaternion.Slerp(startrot, endrot, t);

        if (t < 1.0f)
        {
            t += 0.8f * Time.deltaTime;
            //movecam.transform.LookAt(GameObject.Find("UTC_Default").transform.position);
        }
        else
        {
            //movecam.transform.rotation = GameObject.Find("MovePoint").transform.rotation;
        }
    }

    public void SetTarget(Transform target)
    {
        //endpos = target.position + target.forward * 1.5f + target.up;
        //endrot = target.rotation * Quaternion.Euler(15, 180, 0);

        endpos = target.position + target.right * -0.65f + target.up * 0.5f + target.forward * 1.3f;
        endrot = target.rotation * Quaternion.Euler(0, 155, 0);
    }

    public void Init()
    {
        t = 0;
        movecam.transform.position = startpos;
        movecam.transform.rotation = startrot;
        //Debug.Log(movecam.transform.position.ToString());
        //Debug.Log(movecam.transform.rotation.ToString());
    }
}
