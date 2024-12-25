using UnityEngine;
using UnityEngine.AI;

public class AIEscape : MonoBehaviour
{
    public Transform player;        // 플레이어의 Transform
    public float safeDistance = 10f; // 플레이어와의 안전 거리
    public float escapeRadius = 20f; // 도망갈 범위

    private NavMeshAgent agent;     // NavMeshAgent 컴포넌트

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // 플레이어가 가까워지면 도망
        if (distanceToPlayer < safeDistance)
        {
            Vector3 escapeDirection = (transform.position - player.position).normalized;
            Vector3 escapeTarget = transform.position + escapeDirection * escapeRadius;

            if (NavMesh.SamplePosition(escapeTarget, out NavMeshHit hit, escapeRadius, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
            }
        }
        else
        {
            // 안전 거리일 경우 멈춤
            agent.ResetPath();
        }
    }
}
