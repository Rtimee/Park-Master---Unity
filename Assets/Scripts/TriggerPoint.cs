using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    #region MonoBehaviour Callbacks

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Traffic"))
        {
            Traffic.Instance.Invoke("GetCar",3f);
            Traffic.Instance.ReturnToPool(other.gameObject);
        }
    }

    #endregion
}
