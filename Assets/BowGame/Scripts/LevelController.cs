using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject[] ObstaclePrefabs, ApplePrefabs;
    [SerializeField] private GameObject currentObstaclePrefab, currentApplePrefab;
    [SerializeField] private Vector2 initApplePos;
    [SerializeField] private AppleController currentAppleController;
    private void Start()
    {
        initApplePos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/2, Screen.height)) - new Vector3(0, 2, 0);
        SwitchLevel();

    }
    private void SwitchLevel()
    {
        Destroy(currentObstaclePrefab);
        Destroy(currentApplePrefab);
        currentObstaclePrefab = Instantiate(ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Length)], Vector2.zero, Quaternion.identity, null);
        currentApplePrefab = Instantiate(ApplePrefabs[Random.Range(0, ApplePrefabs.Length)], initApplePos, Quaternion.identity, null);
        currentAppleController = currentApplePrefab.GetComponent<AppleController>();
        ///TODO: event invoke from apple and subscription in this script
    }
    
    void Update()
    {
        
    }
}
