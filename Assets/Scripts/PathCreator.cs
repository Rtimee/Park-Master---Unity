using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    #region Variables

    public Action<IEnumerable<Vector3>> OnNewPathCreated = delegate { };

    [SerializeField] Camera camera;
    [SerializeField] Material lineMaterial;

    // Drawing
    LineRenderer lineRenderer;
    List<Vector3> points = new List<Vector3>();
    
    // Raycasting
    Ray ray;
    RaycastHit hit;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!GameManager.Instance.isGameStarted)
                GameManager.Instance.StartGame();
            points.Clear();
            lineRenderer.enabled = true;
        }
        if (Input.GetMouseButton(0))
            Raycasting();
        else if (Input.GetMouseButtonUp(0))
        {
            OnNewPathCreated(points);
            PathManager.Instance.NextPathDrawing();
        }
    }

    #endregion

    #region Other Methods

    float DistanceToLastPoint(Vector3 point)
    {
        if (!points.Any())
            return Mathf.Infinity;

        float distance = Vector3.Distance(points.Last(), point);
        return distance;
    }

    void Raycasting()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit))
        {
            if (hit.transform.CompareTag("Ground") && DistanceToLastPoint(hit.point) > .25f)
            {
                Vector3 point = new Vector3(hit.point.x, 1.1f, hit.point.z);
                points.Add(point);
                lineRenderer.positionCount = points.Count;
                lineRenderer.SetPositions(points.ToArray());
            }
        }
    }

    #endregion
}
