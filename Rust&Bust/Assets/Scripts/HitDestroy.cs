using UnityEngine;

public class BarrelHit : MonoBehaviour
{
    public int hitsRequired = 4;
    private int currentHits = 0;

    public void TakeHit()
    {
        currentHits++;
        Debug.Log("Barrel hit count: " + currentHits);

        if (currentHits >= hitsRequired)
        {
            Debug.Log("Barrel destroyed!");
            gameObject.SetActive(false); // or Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            TakeHit();
        }
    }
}