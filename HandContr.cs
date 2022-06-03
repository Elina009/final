using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandContr : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    GameObject PressE;
    GameObject hand;
    GameObject letter;
    Transform letterTR;
    Transform handTR;
    GameObject level2;
    GameObject story;

    void Start()
    {
        PressE = GameObject.Find("PressE");
        level2 = GameObject.Find("level2");
        story = GameObject.Find("story");
        PressE.SetActive(false);
        level2.SetActive(false);

        story.SetActive(false);

        hand = GameObject.Find("hand");
        letter = GameObject.Find("letter");
        
        handTR = hand.GetComponent<Transform>();
        letterTR = letter.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        PressE.SetActive(false);
        Debug.DrawRay(cam.transform.position, cam.transform.forward * 4f, Color.red);
        RaycastHit touch;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out touch, 4)){
            if(touch.transform.gameObject.tag == "letter"){
                PressE.SetActive(true);
                    if(Input.GetKeyDown("e")){
                        print("взял письмо");
                        story.SetActive(true);
                        if(letter.GetComponent<Rigidbody>()){
                            Destroy(letter.GetComponent<Rigidbody>());
                        }

                        letterTR.position = handTR.position;
                        letterTR.rotation = handTR.rotation;
                        letterTR.SetParent(handTR);
                    }
            }
        }
        if(Input.GetKeyDown("space")){
            if(letterTR.position == handTR.position){
                print("drop");
                story.SetActive(false);
                letterTR.parent = null;
                letter.AddComponent<Rigidbody>();
                letter.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 500f);

                level2.SetActive(true);
            }
           
        }
    }
}
