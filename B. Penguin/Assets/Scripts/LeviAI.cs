using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LeviAI : MonoBehaviour
{

    NavMeshAgent agent;
    [SerializeField]
    GameObject player;
    [SerializeField]
    private Transform[] points;

    private int
        destPoint,
        currentPoint;

    private float
        pointRestTime = 5.0f,
        defaultRestTime;

    enum agentStates {Idle, Aggro}
    agentStates currentState;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = agentStates.Idle;
        defaultRestTime = pointRestTime;
    }

    void GotoNextPoint(){
        if (points.Length == 0) {return;}

        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
        
        pointRestTime = defaultRestTime;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            currentState = agentStates.Aggro;
        }
    }

    void Aggro_SuperUpdate (){
        agent.destination = player.transform.position;
    }
    
    void Idle_SuperUpdate (){
        if (pointRestTime >= 0){
        pointRestTime -= Time.deltaTime;}
        
        if (pointRestTime <= 0){
            GotoNextPoint();
        }
    }
    

    // Update is called once per frame
    void Update()
    {
       switch (currentState){
           case agentStates.Aggro : Aggro_SuperUpdate(); break;
           case agentStates.Idle : Idle_SuperUpdate(); break;
       }
    }
}
