using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour, IHittable
{
    private Rigidbody2D rigidbody;

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
        rigidbody.isKinematic = false;
        rigidbody.AddForce(velocity * hitModifier, ForceMode2D.Impulse);
    }


}
