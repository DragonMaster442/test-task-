using UnityEngine;

public class ProjectileReactionSurface : MonoBehaviour, IHaveProjectileReaction
{
    [Header("Impact Effect Prefabs")]
    [SerializeField] private Transform [] _impactPrefabs;

    public void React(Transform hitLocation, Quaternion hitNormal)
    {
        Instantiate (_impactPrefabs [Random.Range 
				(0, _impactPrefabs.Length)], hitLocation.position, 
				hitNormal);
    }
}
