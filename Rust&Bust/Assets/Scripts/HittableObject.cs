using UnityEngine;

public class HittableObject : MonoBehaviour
{
    public void OnHit()
    {
        Destroy(gameObject);
    }
}