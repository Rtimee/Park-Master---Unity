using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Car : MonoBehaviour
{
    #region Variables

    [SerializeField] PathCreator pathCreator;
    [SerializeField] GameObject arrow;
    [SerializeField] float crashForce;

    Queue<Vector3> pathPoints;
    NavMeshAgent agent;
    Rigidbody rb;

    bool isStarted;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pathPoints = new Queue<Vector3>();
        agent = GetComponent<NavMeshAgent>();
        pathCreator.OnNewPathCreated += SetPoints;
    }

    private void Update()
    {
        if (isStarted)
            UpdateDestionation();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Car") || collision.transform.CompareTag("Obstacle"))
        {
            FxManager.Instance.Crash(new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y + 3f, collision.contacts[0].point.z));
            Crash();
        }
    }

    #endregion

    #region Other Methods

    public void SetPoints(IEnumerable<Vector3> points)
    {
        pathPoints = new Queue<Vector3>(points);
    }

    bool CanSetDestionation()
    {
        if (pathPoints.Count == 0)
            return false;
        if (agent.hasPath == false || agent.remainingDistance < .85f)
            return true;
        return false;
    }

    void UpdateDestionation()
    {
        if (CanSetDestionation())
            agent.SetDestination(pathPoints.Dequeue());
    }

    public void StartToMoving()
    {
        rb.isKinematic = false;
        isStarted = true;
    }

    void Crash()
    {
        agent.Stop();
        agent.enabled = false;
        rb.AddForce((crashForce * transform.up) + (-transform.forward * crashForce / 2));
        Destroy(this);
    }

    public void CarParked()
    {
        agent.Stop();
        rb.isKinematic = true;
        Destroy(this);
    }

    public void ShowArrow()
    {
        arrow.SetActive(true);
    }

    public void HideArrow()
    {
        arrow.SetActive(false);
    }

    #endregion
}
