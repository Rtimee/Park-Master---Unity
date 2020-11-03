using UnityEngine;

public class Coin : MonoBehaviour
{
    #region MonoBehaviour Callbacks

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
            GetCoin();
    }

    #endregion

    #region Other Methods

    void GetCoin()
    {
        FxManager.Instance.GetCoin(new Vector3(transform.position.x,2,transform.position.z));
        GameManager.Instance.GetCoin();
        Destroy(gameObject);
    }

    #endregion
}
