using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    // All Units
    public List<Unit> units = new List<Unit>();

    //Groups of units
    bool NewgroupCreated = false;
    public List<Unit> Selected = new List<Unit>();
    public List<List<Unit>> Groups = new List<List<Unit>>();

    IFormations formation;
    Vector3 Targetpostion = new Vector3();

    //Create the Formations
    SquareFormation square = new SquareFormation();
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
        TriggerCircleFormation();
    }

    private void Update()
    {
        if(!NewgroupCreated)
        UpdateFormation();

        //Update all Units to do there Task
        foreach (Unit unit in units)
        {
                unit.Moveunit();
        }
    }
    public void TriggerCircleFormation()
    {
        formation = circle;

    }
    public void TriggerSquareFormation()
    {
        formation = square;

    }
    public void UpdateFormation()
    {
        //Get Current Selected group

        //Get Current Formation
        if (Groups.Count >= 1)
        {
           formation.ExercuteFormation(Groups[Groups.Count-1], Targetpostion);
        } 
    }

    public void GetNewPostion( Vector3 target)
    {
        Targetpostion = target;
        NewgroupCreated = false;
    }

    public void GreateNewGroup( List<Unit> selected)
    {
        //update the currentSelectd
        Selected = selected;

        //Add to group
        if (Selected.Count > 1)
        {
            var colour = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Groups.Add(Selected);
            foreach(var unit in Selected)
            {
                unit.GetComponent<Renderer>().material.color = colour;
            }
        }
            

        NewgroupCreated = true;
    }
}

