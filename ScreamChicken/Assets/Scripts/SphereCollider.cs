using UnityEngine;

public class SphereCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           other.transform.position = new Vector3(-11, 1, 0);
        }
    }
}
