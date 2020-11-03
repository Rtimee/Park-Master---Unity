using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables

    public static UIManager Instance;

    [SerializeField] GameObject infoScreen;
    [SerializeField] GameObject gameScreen;
    [SerializeField] GameObject nextLevelScreen;
    [SerializeField] Text coinText;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    #region Other Methods

    public void StartGame()
    {
        infoScreen.SetActive(false);
        gameScreen.SetActive(true);
    }

    public void LevelPassed()
    {
        gameScreen.SetActive(false);
        nextLevelScreen.SetActive(true);
    }

    public void UpdateCoinText(int coin)
    {
        coinText.text = coin.ToString();
    }

    #endregion
}
