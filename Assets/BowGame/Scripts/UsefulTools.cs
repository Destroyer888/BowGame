using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UsefulTools
{
    public static void ResetRigidbodyAndTransform(Rigidbody2D rigidbody)
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0;
        
    }
    public static void ResetRigidbodyAndTransform(Rigidbody2D rigidbody, Transform objectTransform, Vector2 targetPos)
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0;
        objectTransform.position = targetPos;
    }

    public static void ResetRigidbodyAndTransform(Rigidbody2D rigidbody, Transform objectTransform, Vector2 targetPos, bool isKinematic)
    {
        rigidbody.isKinematic = isKinematic;
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0;
        objectTransform.position = targetPos;
       
    }
    public static void ResetRigidbodyAndTransform(Rigidbody2D rigidbody, Transform objectTransform, Vector2 targetPos, bool isKinematic, bool enabled)
    {
        rigidbody.gameObject.SetActive(enabled);
        rigidbody.velocity = Vector2.zero;
        rigidbody.angularVelocity = 0;
        objectTransform.position = targetPos;
        rigidbody.isKinematic = isKinematic;
    }


}
