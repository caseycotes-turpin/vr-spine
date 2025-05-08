using System.Collections;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 3f;
    public Transform pathParent;
    Transform targetPoint;
    int index;

    void OnDrawGizmos()
    {
        Vector3 from;
        Vector3 to;
        for (int a = 0; a < pathParent.childCount; a++)
        {
            from = pathParent.GetChild(a).position;
            to = pathParent.GetChild((a + 1) % pathParent.childCount).position;
            Gizmos.color = new Color(1, 0, 0);
            Gizmos.DrawLine(from, to);
        }
    }
    void Start()
    {
        index = 0;
        targetPoint = pathParent.GetChild(index);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            if (targetPoint.GetComponent<TargetPoint>().Mytype == TargetPoint.PointType.END)
            {
                Debug.Log("End Point");
                speed = 0;
            }
            else if (targetPoint.GetComponent<TargetPoint>().Mytype == TargetPoint.PointType.STOP)
            {
                Debug.Log("Stop Point");
                speed = 0;
                StartCoroutine(PauseMouvementForSeconds(targetPoint.GetComponent<TargetPoint>().StopDuration));
            }
            index++;
            index %= pathParent.childCount;
            targetPoint = pathParent.GetChild(index);

        }
    }

    IEnumerator PauseMouvementForSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        speed = 1;
    }
}
