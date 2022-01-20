using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFormations
{
    void ExercuteFormation(List<Unit> units, Vector3 TargetPos);
}

public class SquareFormation : IFormations
{

    public void ExercuteFormation(List<Unit> units, Vector3 Targetpos)
    {
        //Check whenever you selected units
        if(units.Count >= 0)
        {
            // get closed by targetPos
            Unit Commander = units[0];

            Commander.SetDesiredPostion(Targetpos);

            //We got a comander, now the other units should follow him
            for (int j = 1; j < units.Count; ++j)
            {
                if(Commander != units[j])
                {
                    Vector3 pos = GetPostions(j);
                    Vector3 newpos = new Vector3(pos.x + Commander.desiredPostion.x, 0,  pos.z +Commander.desiredPostion.z);
                    Debug.Log(pos.x + Commander.desiredPostion.x + " " + pos.z + Commander.desiredPostion.z);
                    units[j].transform.rotation = Commander.transform.rotation;
                    units[j].SetDesiredPostion(newpos);
                }     
            }
        }
    }

    //Code from: https://answers.unity.com/questions/1402840/how-can-i-create-a-squad-of-soldiers-in-specific-f.html
    private Vector3 GetPostions(int index)
    {
        float posX;
        float posY;

        float space = 5;
        int colum = 4;

        posX = (index % colum) * space;
        posY = (index / colum) * space;
    
        return new Vector3(posX, 0, posY);
    }
}
public class CircleFormation : IFormations
{
    public void ExercuteFormation(List<Unit> units, Vector3 TargetPos)
    {
        Debug.LogError(TargetPos);

        for (int i = 0; i < units.Count; i++)
        {
            float radius = 5;
            float radians = i *( 2 * 3.14159f/units.Count); 
            float x =(Mathf.Cos(radians) * radius);
            float z = (Mathf.Sin(radians) * radius);

            TargetPos = new Vector3(TargetPos.x + x, 0, TargetPos.z + z);

            units[i].SetDesiredPostion(TargetPos);
        }
    }
}
