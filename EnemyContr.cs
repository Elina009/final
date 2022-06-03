using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyContr : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    public GameObject player;
    Transform playerTR;
    float distanceToPlayer;
    float distance = 10f;
    int hp = 100;

    public healthbar hp_script;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTR = player.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
        distanceToPlayer = Vector3.Distance(player.transform.position, agent.transform.position);
        print(distanceToPlayer);
        if(distanceToPlayer <= distance){
            print("alarm");
            hp = hp - 5;

        }
    }
}
