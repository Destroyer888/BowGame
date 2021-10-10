
using UnityEngine;

public interface IHittable
{
    public void HitAndDead(Vector2 velocity, float hitModifier);
}
