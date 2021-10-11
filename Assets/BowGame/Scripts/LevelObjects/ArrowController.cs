using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Collider2D collider;
    [SerializeField] private float hitModifier = 1f;
    private void Start()
    {
        collider = GetComponent<Collider2D>();
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
            UsefulTools.ResetRigidbodyAndTransform(rigidbody, transform, transform.position, true);
            collider.enabled = false;
            transform.parent = collision.transform;
            Destroy(gameObject, 1f);
            Debug.Log("shooted");
        }
    }
}
