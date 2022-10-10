using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movetest : MonoBehaviour {

    //Animator anim;

    //Vector3 dir;
    //Quaternion rot;

    float walkSpeed = 6.0f;
    float runSpeed = 10.0f;
    float speed = 0.0f;

    bool die;
    bool wait;

    GameObject movingcam;

    UIScript uiScript;

    UnitychanAnimScript animScript;

    QCTManager qctMng;

    //enum Estate
    //{
    //    idle,
    //    move,
    //    down
    //}

    // Use this for initialization

    public void Walking(bool walking)
    {
        if(walking)
        {
            speed = walkSpeed;
            animScript.SetWalking(true);
        }
        else
        {
            speed = runSpeed;
            animScript.SetWalking(false);
        }
    }

    public void MoveToward(Quaternion rot)
    {
        //if (dir != Vector3.zero)
        //rot = Quaternion.LookRotation(dir);

        if (!die && !wait)
        {
            transform.rotation = rot;

            transform.position = transform.position + transform.forward * speed * Time.deltaTime;

            animScript.SetState(1);
        }
    }

    public void Jump()
    {
        if(!wait)
        {
            animScript.Jump();
        }
    }

    public void Play()
    {
        if (die)
        {
            die = false;
            wait = true;
            transform.position = Vector3.zero;
            animScript.SetState(0);
            uiScript.SetZero();
            movingcam.GetComponent<CamManager>().Init();
            movingcam.SetActive(false);
        }
        else if (wait)
        {
            wait = false;
            uiScript.TimerStart();
        }
    }

    void Start()
    {
        speed = runSpeed;
        //anim = GetComponent<Animator>();
        //dir = new Vector3();
        die = false;
        wait = true;

        //GameObject.Find("Query-Chan-Tachi").SetActive(false);
        movingcam = GameObject.Find("MovingCamera");
        movingcam.SetActive(false);

        uiScript = GameObject.Find("Timer").GetComponent<UIScript>();
        animScript = GetComponent<UnitychanAnimScript>();
        qctMng = GetComponent<QCTManager>();
    }

    // Update is called once per frame
    void Update() {

        /*if (!die && !wait)
        {
            /*if (Input.GetButtonDown("Walk"))
            {
                speed = walkSpeed;
                anim.SetBool("Running", false);
            }
            if (Input.GetButtonUp("Walk"))
            {
                speed = runSpeed;
                anim.SetBool("Running", true);
            }*/

            /*if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                float h = Input.GetAxisRaw("Horizontal");
                float v = Input.GetAxisRaw("Vertical");
                dir.x = h;
                dir.z = v;

                if (dir != Vector3.zero)
                {
                    rot = Quaternion.LookRotation(dir);
                }

                transform.rotation = rot;

                transform.position = transform.position + transform.forward * speed * Time.deltaTime;
                //anim.SetInteger("State", (int)Estate.move);
                GetComponent<UnitychanAnimScript>().SetState((int)Estate.move);
            }
            else
            {
                //anim.SetInteger("State", (int)Estate.idle);
                GetComponent<UnitychanAnimScript>().SetState((int)Estate.idle);
            }
            
            if (Input.GetButtonDown("Jump"))
            {
                //GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
                //anim.SetTrigger("Jump");
            }
        }*/
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OncollisionEnter");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Query")
        {
            //Debug.Log(other.gameObject.ToString());

            die = true;
            //anim.SetInteger("State", 2);
            animScript.SetState(2);
            qctMng.AllStop();
            uiScript.Stop();

            movingcam.GetComponent<CamManager>().SetTarget(other.GetComponent<Transform>());
            movingcam.SetActive(true);
            //GameObject.Find("MovingCamera").GetComponent<CameraManager>().CameraMove();

            qctMng.Posing(other.GetComponent<Transform>());
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //if(hit.collider.gameObject.tag != "Wall")
            //Debug.Log(hit.collider.gameObject.ToString());
    }
}
