using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    // All Units
    public List<Unit> units = new List<Unit>();

    //Groups of units
    public List<Unit> Selected = new List<Unit>();

    SquareFormation formations = new SquareFormation();
    CircleFormation circle = new CircleFormation();
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
        //Update all Units to do there Task
        foreach(Unit unit in units)
        {
                unit.Moveunit();
        }
    }
    public void SetFormation(Vector3 target)
    {
        //Get Current Formation
        if (Selected.Count > 1)
        {
            //formations.ExercuteFormation(Selected, target);
            circle.ExercuteFormation(Selected, target);
        }
            
    }
}
