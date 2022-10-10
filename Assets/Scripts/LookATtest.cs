using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookATtest : MonoBehaviour
{
    GameObject target;

    float top, bottom, left, right;
    float speed;
    float maxspeed = 12.0f;
    float minspeed = 4.0f;

    bool wait, isReady;

    QuerychanAnimScript animScript;

    void RadomPosition()
    {
        float x = Random.Range(left, right);
        float z = Random.Range(bottom, top);

        transform.position = new Vector3(x, 0, z);
    }

    void FindAndLook(Transform obj)
    {
        //target.transform.position = new Vector3(obj.transform.position.x, 0, obj.transform.position.z);

        if (obj == null)
            Debug.Log("null임");
        else
        {
            transform.LookAt(obj);
            //Debug.Log(obj.position.ToString());
        }
    }

    void SetPosition()
    {
        RadomPosition();

        FindAndLook(target.transform);

        float distance = (transform.position - target.transform.position).magnitude;
        //Debug.Log(distance.ToString());

        float limit = 10;
        if (distance < limit)
        {
            transform.position = transform.position - transform.forward * (limit - distance);
        }

        isReady = true;
        //GetComponent<QuerychanAnimScript>().SetState(0);
    }

    public void Stop()
    {
        wait = true;
        animScript.SetState(0);
    }

    public void Play()
    {
        if (!isReady)
        {
            SetPosition();
        }
        else
        {
            wait = false;
            isReady = false;
        }
    }

    public void SetRandomPose()
    {
        int i = Random.Range(1, 8);
        animScript.SetPose(i);
        //Debug.Log(i.ToString());
        //animScript.SetPose(3);
    }
    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("UTC_Default");
        //target = GameObject.Find("Misaki_SchoolUniform_summer");

        top = GameObject.Find("wall_top").transform.position.z;
        bottom = GameObject.Find("wall_bottom").transform.position.z;
        left = GameObject.Find("wall_left").transform.position.x;
        right = GameObject.Find("wall_right").transform.position.x;

        speed = Random.Range(minspeed, maxspeed);

        SetPosition();

        wait = true;

        animScript = GetComponent<QuerychanAnimScript>();
        //Debug.Log("이게아닌가");
    }

    // Update is called once per frame
    void Update()
    {
        if (!wait)
        {
            //GetComponent<Animator>().SetInteger("State", 1);
            animScript.SetState(1);

            transform.position = transform.position + transform.forward * speed * Time.deltaTime;

            if (transform.position.z <= bottom
                || transform.position.z >= top
                || transform.position.x <= left
                || transform.position.x >= right)
            {
                FindAndLook(target.transform);
                speed = Random.Range(minspeed, maxspeed);
                //speed += Random.Range(-1.0f, 1.0f);
                //if (speed >= 10)
                //    speed = 10.0f;
            }
        }
        //else
        //{
        //    GetComponent<Animator>().SetInteger("State", 0);
        //}
        //Debug.Log("수행중");
    }
}
