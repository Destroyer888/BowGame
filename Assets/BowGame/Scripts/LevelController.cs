using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject[] ObstaclePrefabs, ApplePrefabs;
    [SerializeField] private GameObject currentObstaclePrefab, currentApplePrefab;
    [SerializeField] private Vector2 initObstaclePos, initApplePos;
    [SerializeField] private AppleController currentAppleController;
    void Start()
    {
        
    }
    private void SwitchLevel()
    {
        Destroy(currentObstaclePrefab);
        Destroy(currentApplePrefab);
        currentObstaclePrefab = Instantiate(ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Length)], initObstaclePos, Quaternion.identity, null);
        currentApplePrefab = Instantiate(ApplePrefabs[Random.Range(0, ApplePrefabs.Length)], initApplePos, Quaternion.identity, null);
        ///TODO: event invoke from apple and subscription in this script
    }
    
    void Update()
    {
        
    }
}