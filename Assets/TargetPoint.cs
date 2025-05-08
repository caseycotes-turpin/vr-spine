using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    public enum PointType { START, STOP, TRANSITION, END }

    [SerializeField] private PointType myType;
    public PointType Mytype
    {
    get { return myType; }   // get method
    set { myType = value; }  // set method
    }

    [SerializeField] int stopDuration;
    public int StopDuration
    {
        get { return stopDuration; }
        set { stopDuration = value; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
