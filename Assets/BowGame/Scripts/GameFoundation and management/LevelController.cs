using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject[] ObstaclePrefabs, AppleHandlersPrefabs;
    public GameObject ApplePrefab;
    [SerializeField] private GameObject currentObstaclePrefab, currentApplePrefab, currentAppleHandlerPrefab;
    [SerializeField] private Vector2 initApplePos;
    [SerializeField] private AppleController currentAppleController;
    [SerializeField] private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        initApplePos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/2, Screen.height)) - new Vector3(0, 2, 0);
        currentApplePrefab = Instantiate(ApplePrefab, initApplePos, Quaternion.identity, null);
        currentAppleController = currentApplePrefab.GetComponentInChildren<AppleController>();
        currentAppleController.onDeadEvent += SwitchLevel;
        SwitchLevel();

    }
    private void SwitchLevel()
    {
        animator.SetTrigger("SwitchLevel"); // start switching
        Invoke(nameof(Switch), animator.GetCurrentAnimatorStateInfo(0).length);
    }


    
    private void Switch()
    {
        Destroy(currentAppleHandlerPrefab);
        Destroy(currentObstaclePrefab);
        currentObstaclePrefab = Instantiate(ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Length)], Vector2.zero, Quaternion.identity, null);
        currentAppleHandlerPrefab = Instantiate(AppleHandlersPrefabs[Random.Range(0, AppleHandlersPrefabs.Length)], initApplePos, Quaternion.identity, null);
        currentAppleHandlerPrefab.GetComponent<AppleHandler>().PlugApple(currentAppleController);
    }
}
