using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    public static BowController instance;
    [SerializeField] private GameObject arrowPrefab, currentPrefab;
    private Vector2 startTouchPos, endTouchPos;
    private Rigidbody2D arrowRig;
    [SerializeField] private float bowForce = 0f;

    [SerializeField] private byte arrowCount
    {
        get 
        { 
            return arrowCount; 
        }
        set
        {
            if(value <= 0)
            {
                LevelController.instance.Loose();
            }
        }
    }

    private void Awake() => instance = this;
    private void Update()
    {
        if (Input.touchCount != 0)
        {
            Touch touch = Input.GetTouch(0);
            endTouchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began)
            {
                currentPrefab = Instantiate(arrowPrefab, transform.position, transform.rotation, transform);
                arrowRig = currentPrefab.GetComponent<Rigidbody2D>();
                arrowRig.isKinematic = true;
                startTouchPos = Camera.main.ScreenToWorldPoint(touch.position);
            }
            if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2( transform.position.y - endTouchPos.y, transform.position.x - endTouchPos.x) * 57-90);
            }
            if(touch.phase == TouchPhase.Ended)
            {
                arrowRig.isKinematic = false;
                currentPrefab.transform.parent = null;
                
                arrowRig.AddForce(Vector2.ClampMagnitude(((Vector2)transform.position - endTouchPos), 3) * bowForce, ForceMode2D.Impulse);
            }

        }
    }

    
}
