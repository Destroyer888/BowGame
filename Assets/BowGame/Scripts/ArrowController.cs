using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private float hitModifier = 1f;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(rigidbody.isKinematic == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(transform.position.y - rigidbody.velocity.y, transform.position.x - rigidbody.velocity.x) * 57 - 90);
        }
            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHittable hittable = collision.gameObject.GetComponent<IHittable>();
        if(hittable != null)
        {
            hittable.HitAndDead(rigidbody.velocity, hitModifier);
            rigidbody.isKinematic = true;
            rigidbody.velocity = Vector2.zero;
            rigidbody.angularVelocity = 0;
            transform.parent = collision.transform;
          
        }
    }
}
