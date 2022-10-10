using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuerychanAnimScript : MonoBehaviour {

    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetState(int state)
    {
        //Debug.Log(state.ToString());
        anim.SetInteger("State", state);
    }

    public void SetPose(int pose)
    {
        anim.SetInteger("Pose", pose);
    }
}
