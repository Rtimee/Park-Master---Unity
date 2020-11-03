using UnityEngine;

public class Driver : MonoBehaviour
{
    #region Veriables

    [SerializeField] float speed;

    #endregion

    #region MonoBehaviour Callbacks

    private void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime,Space.World);
    }

    #endregion
}
