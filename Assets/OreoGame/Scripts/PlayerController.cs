using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform player;
    public GameObject prefab;
    private GameObject currentPrefab;
    public Vector3 vec;


    private void Update()
    {
        if (Input.touchCount != 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                currentPrefab = Instantiate(prefab, new Vector3(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y, player.transform.position.z), Quaternion.Euler(0, 0, Mathf.Atan2(player.transform.position.y - Camera.main.ScreenToWorldPoint(touch.position).y, player.transform.position.x - Camera.main.ScreenToWorldPoint(touch.position).x) * 57), null);
            }
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                currentPrefab.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y, player.transform.position.z);
                currentPrefab.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(player.transform.position.y - Camera.main.ScreenToWorldPoint(touch.position).y, player.transform.position.x - Camera.main.ScreenToWorldPoint(touch.position).x) * 57);
            }
            if (touch.phase == TouchPhase.Ended)
            {
                currentPrefab = null;
            }
        }
     
    }
}
