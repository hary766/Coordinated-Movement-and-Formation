using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    // All Units
    public List<Unit> units = new List<Unit>();

    //Groups of units
    public List<Unit> Selected = new List<Unit>();

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

        //Update Task of Active units
        {
            foreach(Unit unit in Selected)
            {
                unit.SetDesiredPostion(desiredPostion);
            }
        }
        //Update all Units to do there Task
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
