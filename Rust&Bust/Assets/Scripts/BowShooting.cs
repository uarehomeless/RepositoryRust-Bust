using UnityEngine;

public class BowShoot : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform spawnPoint;
    public float shootForce = 30f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, spawnPoint.position, spawnPoint.rotation);

        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.linearVelocity = spawnPoint.forward * shootForce;

        Destroy(arrow, 10f); // deletes arrow after 10 seconds
    }
}