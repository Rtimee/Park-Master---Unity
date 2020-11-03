using System.Collections.Generic;
using UnityEngine;

public class Traffic : MonoBehaviour
{
    #region Variables

    public static Traffic Instance;

    [SerializeField] GameObject[] cars;

    List<GameObject> carPool;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        Instance = this;
        carPool = new List<GameObject>();
    }

    private void Start()
    {
        SpawnCar();
        GetCar();
    }

    #endregion

    #region Other Methods

    public void SpawnCar()
    {
        foreach (GameObject car in cars)
        {
            GameObject _car = Instantiate(car, transform.position, transform.rotation, transform);
            _car.SetActive(false);
            carPool.Add(_car);
        }
    }

    void GetCar()
    {
        int random = Random.Range(0, cars.Length);
        GameObject car = carPool[random];
        car.SetActive(true);
        carPool.Remove(car);
    }

    public void ReturnToPool(GameObject _car)
    {
        _car.SetActive(false);
        _car.transform.position = transform.position;
        carPool.Add(_car);
    }

    #endregion
}
