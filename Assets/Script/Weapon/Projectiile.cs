using UnityEngine;

public class Projectiile : MonoBehaviour
{
    private float lifetime = 3.0f;
    public void Fire(Vector3 direction,float fireSpeed)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * fireSpeed, ForceMode.Impulse);
        Destroy(gameObject, lifetime);
    }
}
