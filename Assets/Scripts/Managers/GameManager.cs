using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    public static GameManager Instance;

    public bool isGameStarted;

    int totalCoin;
    int currentCoin;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    #endregion

    #region Other Methods

    public void StartGame()
    {
        isGameStarted = true;
        UIManager.Instance.StartGame();
    }

    public void GetCoin()
    {
        currentCoin++;
        UIManager.Instance.UpdateCoinText(currentCoin);
    }

    public void SaveCoin()
    {
        totalCoin = currentCoin;
    }

    public void LoadNewLevel()
    {
        isGameStarted = false;
        currentCoin = totalCoin;
        UIManager.Instance.UpdateCoinText(totalCoin);
    }

    #endregion
}
