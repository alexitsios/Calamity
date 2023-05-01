using Calamity.Primitives;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private IntReference medKitMagnitudeIntReference;
    [SerializeField] private IntReference playerHealthReference;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        playerHealthReference.Value += medKitMagnitudeIntReference.Value;

        Destroy(gameObject);
    }
}