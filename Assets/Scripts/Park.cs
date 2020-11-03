using UnityEngine;

public class Park : MonoBehaviour
{
    #region Variables

    [SerializeField] Car targetCar;
    [SerializeField] GameObject parkedFx;

    #endregion

    #region MonoBehaviour Callbacks

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == targetCar.transform.name)
        {
            parkedFx.SetActive(true);
            ParkManager.Instance.Parked();
            other.gameObject.GetComponent<Car>().Invoke("CarParked",.2f);
            Destroy(this);
        }
    }

    #endregion
}
