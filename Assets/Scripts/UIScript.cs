using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    float time = 0.0f;
    bool counting = false;

    public void Stop()
    {
        counting = false;
    }
    
    public void SetZero()
    {
        time = 0.0f;
        Text timer = GetComponent<Text>();
        timer.text = time.ToString("N2");
    }

    public void TimerStart()
    {
        counting = true;
    }

    public float GetTime()
    {
        return time;
    }
    // Use this for initialization
    void Start() {

    }
	
	// Update is called once per frame
	void Update () {
        if(counting)
        { 
            time += Time.deltaTime;

            Text timer = GetComponent<Text>();
            timer.text = time.ToString("N2");
        }
    }
}
