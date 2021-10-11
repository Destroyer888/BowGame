using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour, IHittable
{
    public Rigidbody2D rigidbody;
    public delegate void DoAction();
    public event DoAction onDeadEvent;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
  
    
    private void Update()
    {
        transform.Rotate(new Vector3(0,0,10) * Time.deltaTime);
    }

    public void HitAndDead(Vector2 velocity, float hitModifier)
    {
        onDeadEvent?.Invoke();
        rigidbody.isKinematic = false;
        rigidbody.AddForce(velocity * hitModifier, ForceMode2D.Impulse);
    }
    
}
