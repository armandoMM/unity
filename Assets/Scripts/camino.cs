using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class camino : MonoBehaviour
{

    public Transform[] points;
    public int destPoint = 0;
    private NavMeshAgent agent;
    public enum tipoMovimiento { loop, reversa, random };
    public tipoMovimiento _tipoMovimientos;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        if (_tipoMovimientos == tipoMovimiento.loop)
        {
            destPoint = destPoint + 1;
            if (destPoint >= points.Length)
            {
                destPoint = 0;
            }
            agent.destination = points[destPoint].transform.position;
            //destPoint = (destPoint + 1) % points.Length;
        }
        else if (_tipoMovimientos == tipoMovimiento.reversa)
        {
            destPoint = destPoint - 1;
            if (destPoint < 0)
            {
                destPoint = points.Length - 1;
            }
            agent.destination = points[destPoint].transform.position;
        }
        else
        {
            destPoint = Random.Range(0, points.Length - 1);
        }
        agent.destination = points[destPoint].transform.position;

        //return;

    }


    void Update()
    {
        if (agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
