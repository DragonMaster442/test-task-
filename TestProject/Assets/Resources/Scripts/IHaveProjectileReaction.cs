using UnityEngine;

public interface IHaveProjectileReaction
{
    public void React(Transform hitLocation, Quaternion hitNormal);
}
