using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BodyContr : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerBody;
    CharacterController contr;
    float speed = 12f;
    public Camera cam;
    Transform tr;

    public shooting shoot_script;

    int hp = 100;
    int time = 40;
    [SerializeField] TextMeshProUGUI killedText;
    [SerializeField] TextMeshProUGUI timeText;

    void Start()
    {
        contr = playerBody.GetComponent<CharacterController>();
        tr = GetComponent<Transform>();
        InvokeRepeating("timeMinus",1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * 2f;
        float mouseY = Input.GetAxis("Mouse Y");

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        contr.Move(playerBody.forward * vertical * speed * Time.deltaTime);
        contr.Move(playerBody.right * horizontal * speed * Time.deltaTime); 

    }
    void timeMinus(){
        time = time - 1;
        timeText.text = "TIME: " + time;
        if(time==0){
           CancelInvoke("Timer");
           if(hp >=0 && shoot_script.killed >=14){
               print("won");
           } else{
               print("loose");
           }
        }
    }
    void OnControllerColliderHit(ControllerColliderHit col){
        if(col.gameObject.tag == "enemy"){
           Destroy(gameObject);
        }
        if(col.gameObject.tag == "enemy"){
            hp = hp - 5;
            FindObjectOfType<healthbar>().decreaseValue(hp);
        }
    }
}