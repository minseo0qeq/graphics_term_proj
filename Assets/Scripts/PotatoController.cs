using UnityEngine;
using UnityEngine.AI;

public class AIEscape : MonoBehaviour
{
    public Transform player;        // �÷��̾��� Transform
    public float safeDistance = 10f; // �÷��̾���� ���� �Ÿ�
    public float escapeRadius = 20f; // ������ ����

    private NavMeshAgent agent;     // NavMeshAgent ������Ʈ

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // �÷��̾ ��������� ����
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
            // ���� �Ÿ��� ��� ����
            agent.ResetPath();
        }
    }
}
