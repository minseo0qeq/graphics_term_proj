using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunnerSpawner : MonoBehaviour
{
    public GameObject runnerTemplate;
    public int maxRunnerCount = 10;
    public float spawnInterval = 1.5f;
    public float navMeshCheckRadius = 1f;

    private float spawnTimer = 0f;
    private List<GameObject> runners = new List<GameObject>();

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnInterval && runners.Count < maxRunnerCount)
        {
            SpawnRunner();
            spawnTimer = 0f;
        }
    }

    void SpawnRunner()
    {
        Vector3 spawnPosition;
        if (TryGetNavMeshPosition(out spawnPosition))
        {
            GameObject newRunner = Instantiate(runnerTemplate, spawnPosition, Quaternion.identity);

            runners.Add(newRunner);
        }
        else
        {
            Debug.LogWarning("유효한 NavMesh 위치를 찾지 못했습니다. 스폰이 취소됩니다.");
        }
    }

    bool TryGetNavMeshPosition(out Vector3 position)
    {
        for (int i = 0; i < 10; i++)
        {

            Vector3 randomPoint = new Vector3(
                Random.Range(-17f, 17f),
                runnerTemplate.transform.position.y,
                Random.Range(-13f, 13f)
            );

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, navMeshCheckRadius, NavMesh.AllAreas))
            {
                position = hit.position;
                return true;
            }
        }

        position = Vector3.zero;

        return false;
    }
}
