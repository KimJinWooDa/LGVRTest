using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCAgent : MonoBehaviour
{
    private NavMeshAgent _agent;

    Transform Parent; 
    Transform[] target;
    private int index;
    private int maxIndex;
    
    private void Start()
    {
        if (Parent == null) Parent = GameObject.Find("NPC_MovePoints").GetComponent<Transform>();
        
        target = Parent.GetComponentsInChildren<Transform>();
        
        maxIndex = target.Length;
        
        index = Random.Range(0, maxIndex);
      
        _agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        _agent.SetDestination(target[index].position);

        if (Vector3.Distance(this.transform.position, target[index].position) <= 3f)
        {
            index = Random.Range(0, maxIndex);
        }
        
    }
}
