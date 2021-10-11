using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleHandler : MonoBehaviour
{
    private Joint2D joint;
    private void Awake()
    {
        joint = GetComponentInChildren<Joint2D>();
    }
    public virtual void PlugApple(AppleController apple)
    { 
        UsefulTools.ResetRigidbodyAndTransform(apple.rigidbody, apple.transform, joint.transform.position, false);
        joint.connectedBody = apple.rigidbody;
    }
}
