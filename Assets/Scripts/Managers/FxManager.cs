using DG.Tweening;
using UnityEngine;

public class FxManager : MonoBehaviour
{
    #region Variables

    public static FxManager Instance;

    [SerializeField] Camera camera;
    [SerializeField] GameObject crashFx;
    [SerializeField] GameObject levelPassedFx;
    [SerializeField] GameObject coinFx;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    #region Other Methods

    public void GetCoin(Vector3 pos)
    {
        GameObject fx = Instantiate(coinFx, pos, Quaternion.identity);
    }

    public void Crash(Vector3 pos)
    {
        GameObject fx = Instantiate(crashFx, pos, Quaternion.identity);
        camera.transform.DOShakePosition(1f, .5f, 10, 90, false, true);
    }

    public void LevelComplete()
    {
        levelPassedFx.SetActive(true);
    }

    #endregion
}
