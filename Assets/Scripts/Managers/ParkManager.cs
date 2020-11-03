using UnityEngine;

public class ParkManager : MonoBehaviour
{
    #region Variables

    public static ParkManager Instance;

    [SerializeField] Park[] parks;

    int parkedCount;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        Instance = this;
        parkedCount = 0;
    }

    #endregion

    #region Other Methods

    public void Parked()
    {
        parkedCount++;
        if (parkedCount == parks.Length)
        {
            FxManager.Instance.LevelComplete();
            UIManager.Instance.LevelPassed();
        }           
    }

    #endregion
}
