using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QCTManager : MonoBehaviour {

    //List<GameObject> QueryArr;
    GameObject[] QueryArr;

    // Use this for initialization
    void Start () {
        //QueryList.Add(GameObject.Find("Query-Chan-Tachi"));
        QueryArr = GameObject.FindGameObjectsWithTag("Query");
        //Debug.Log(QueryArr.Length.ToString());
        //Debug.Log(QueryArr[0].ToString());
    }

    // Update is called once per frame
    void Update () {
        //QueryList[0].GetComponent<LookATtest>().Stop();
    }

    public void AllPlay()
    {
        foreach (GameObject query in QueryArr)
        {
            query.GetComponent<LookATtest>().Play();
        }
    }

    public void AllStop()
    {
        foreach (GameObject query in QueryArr)
        {
            //Debug.Log("why");
            query.GetComponent<LookATtest>().Stop();
        }
    }

    public void Posing(Transform query)
    {
        query.GetComponent<LookATtest>().SetRandomPose();
    }
}
