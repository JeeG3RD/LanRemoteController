using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class player_controller : NetworkBehaviour 
{
    private bool isFalling, isServer;
    private float jumpSpeed, walkSpeed;
    private bool isForward, isBack, isLeft, isRight, isJump;
    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.isServer = GameObject.Find("GameManager").GetComponent<game_controller>().isServer;
        if(this.isServer == true && this.isLocalPlayer) {
            
                NetworkServer.Destroy(this.gameObject);

        } else {
            if (this.isLocalPlayer) {
                this.GetComponentInChildren<Camera>().enabled = true;
                this.GetComponentInChildren<Canvas>().enabled = true;
            }
        }

        isForward = false;
        isBack = false;
        isLeft = false;
        isRight = false;
        isFalling = false;
        jumpSpeed = 200.0f;
        walkSpeed = 4.25f;
    }

    void FixedUpdate()
    {
        if (this.isForward == true) {
            GetComponent<Rigidbody>().velocity = transform.forward * walkSpeed;
        }

        if (this.isBack == true) {
            GetComponent<Rigidbody>().velocity = -transform.forward * walkSpeed;
        }

        if (this.isLeft == true) {
            GetComponent<Rigidbody>().velocity = -transform.right * walkSpeed;
        }

        if (this.isRight == true) {
            GetComponent<Rigidbody>().velocity = transform.right * walkSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onJumpBtn()
    {
        if (isFalling == false && this.isLocalPlayer) {
            GetComponent<Rigidbody>().AddForce(transform.up * jumpSpeed);
            //isFalling = true;
        }
    }

    public void onForwardDown()
    {
        if (this.isLocalPlayer) {
            this.isForward = true;
        }
    }

    public void onForwardUp()
    {
        if (this.isLocalPlayer) {
            this.isForward = false;
        }
    }

    public void onLeftDown()
    {
        if (this.isLocalPlayer) {
            this.isLeft = true;
        }
    }

    public void onLeftUp()
    {
        if (this.isLocalPlayer) {
            this.isLeft = false;
        }
    }

    
    public void onRightDown()
    {
        if (this.isLocalPlayer) {
            this.isRight = true;
        }
    }

    public void onRightUp()
    {
        if (this.isLocalPlayer) {
            this.isRight = false;
        }
    }

    public void onBackDown()
    {
        if (this.isLocalPlayer) {
            this.isBack = true;
        }
    }

    public void onBackUp()
    {
        if (this.isLocalPlayer) {
            this.isBack = false;
        }
    }
}
