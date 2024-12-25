using UnityEngine;
using UnityEngine.AI;

public class SimpleRunnerAI : MonoBehaviour
{
    public float randomMoveRadius = 5f;
    public float moveInterval = 2f;
    public float jumpForce = 6f;
    public float jumpCooldown = 3f;
    private float moveTimer;
    private float jumpTimer;
    private Rigidbody rb;
    private bool isHitByBullet = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody�� �� ������Ʈ�� �����ϴ�.");
        }

        moveTimer = moveInterval;
        jumpTimer = jumpCooldown;
    }

    void Update()
    {

        if (isHitByBullet)
        {
            rb.velocity = Vector3.zero; 
            rb.useGravity = true;
            return;
        }

        moveTimer += Time.deltaTime;

        if (moveTimer >= moveInterval)
        {
            MoveToRandomPosition();
            moveTimer = 0f;
        }

        jumpTimer += Time.deltaTime;
        if (IsGrounded() && jumpTimer >= jumpCooldown && Random.Range(0, 100) < 40)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpTimer = 0f;
        }
    }

    void MoveToRandomPosition()
    {
        Vector3 randomDirection = new Vector3(
            Random.Range(-2f, 2f),
            0f,
            Random.Range(-2f, 2f)
        ).normalized * randomMoveRadius;

        Vector3 destination = transform.position + randomDirection;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(destination, out hit, randomMoveRadius, NavMesh.AllAreas))
        {
            Vector3 validPosition = hit.position;
            Vector3 direction = (validPosition - transform.position).normalized;

            rb.velocity = direction * randomMoveRadius;
        }
        else
        {
            Debug.Log("NavMesh ������ ������ �� �����ϴ�.");
        } 
    }

    public void SetIsHitByBullet(bool set){
        isHitByBullet = set;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.5f);
    }

}
