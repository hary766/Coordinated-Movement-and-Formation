using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    // All Units
    public List<Unit> units = new List<Unit>();

    //Groups of units
    public List<List<Unit>> groups = new List<List<Unit>>();

    public Vector3 desiredPostion;

   void AddAllActiveUnits()
    {
        var objects = FindObjectsOfType<Unit>();
        foreach(var obj in objects)
        {
            units.Add(obj);
        }
    }
    void Start()
    {
        AddAllActiveUnits();
    }

    private void Update()
    {
        foreach(Unit unit in units)
        {
                unit.Moveunit();
        }
    }
    public void SetDesiredPosition(Vector3 newPosition)
    {
        desiredPostion = newPosition;
    }
}
