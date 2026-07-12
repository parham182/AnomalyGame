using UnityEngine;
using UnityEngine.AI;

public class NpcMovement : MonoBehaviour
{
    [Header("Targets")]
    [SerializeField] Transform normalTarget;
    [SerializeField] Transform player; //For Anomaly

    NavMeshAgent navMeshAgent;

    bool isStop = false;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (normalTarget != null )
        {
            navMeshAgent.isStopped = isStop;
            navMeshAgent.SetDestination(normalTarget.position);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isStop = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isStop = false;
        }
    }
}
