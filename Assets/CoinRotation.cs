using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // إذا السيارة (PrometeoCarController) لمست العملة
        if (other.GetComponentInParent<PrometeoCarController>() != null)
        {
            // زِد 10 نقاط
            CoinManager.Instance.AddScore(10);

            // احذف العملة
            Destroy(gameObject);
        }
    }
}

