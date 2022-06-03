using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shooting : MonoBehaviour
{   
    public Camera cam;
    public ParticleSystem partic;
    public int killed = 0;
    [SerializeField] TextMeshProUGUI killed_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Debug.DrawRay(cam.transform.position, cam.transform.forward * 100f,Color.green); //Raycast
        RaycastHit hit;
        if(Input.GetButtonDown("Fire1")){
            partic.Play();
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 100)){
                if(hit.transform.gameObject.tag == "enemy"){
                    Destroy(hit.transform.gameObject);
                    killed = killed + 1;
                    killed_text.text = "KILLED: " + killed.ToString();
                }
                
            }
        }
    }
}
