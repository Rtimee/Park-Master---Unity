using UnityEngine;

public class PathManager : MonoBehaviour
{
    #region Variables

    public static PathManager Instance;

    [SerializeField] PathCreator[] paths;
    [SerializeField] Car[] cars;

    PathCreator currentPath;
    int index;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        Instance = this;
        index = 0;
        ActivePath(index);
    }

    #endregion

    #region Other Methods

    public void NextPathDrawing()
    {
        currentPath.enabled = false;
        cars[index].HideArrow();
        if (index < paths.Length - 1)
        {
            index++;
            ActivePath(index);
        }
        else
        {
            foreach (Car car in cars)
            {
                car.StartToMoving();
            }
        }
    }

    void ActivePath(int index)
    {
        currentPath = paths[index];
        currentPath.enabled = true;
        cars[index].ShowArrow();
    }

    #endregion
}
