using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFormations
{
    void ExercuteFormation(List<Unit> units, Vector3 TargetPos);
}

public class SquareFormation : IFormations
{
    float defaultSpeed = 20;

    public void ExercuteFormation(List<Unit> units, Vector3 Targetpos)
    {
        //Check whenever you selected units
        if(units.Count >= 0)
        {
            // get closed by targetPos
            Unit Commander = units[0];
            for(int x = 0; x < units.Count; ++x)
            {
                // set all speed to the same
                units[x].navMeshAgent.speed = defaultSpeed;
                // Select a unit to fill that slot using a game specific heuristic that:
                // Minimizes the distance the unit has to travel.
                if ( Vector3.Distance(units[x].GetCurrentPostion(), Targetpos) < Vector3.Distance(Commander.GetCurrentPostion(), Targetpos))
                {
                    Commander = units[x];
                }
            }

            //We got a comander, now the other units should follow him
            float sqrt = Mathf.Sqrt(units.Count);
            float startposx = Commander.currentPostion.x;
            float counter = -1;
            float xoffset = 0;
            for(int j = 0; j < units.Count; ++j)
            {
                counter++;
                Targetpos = new Vector3(Commander.currentPostion.x + xoffset, Commander.currentPostion.y, Commander.currentPostion.z);
                xoffset = 5;
                if(counter== Mathf.Floor(sqrt))
                {
                    counter = 0;
                    Targetpos.x = startposx;
                    Targetpos.z += 5;
                }
                Debug.LogError(Targetpos);
                units[j].SetDesiredPostion(Targetpos);
            }

        }


    }
}
public class CircleFormation : IFormations
{
    public void ExercuteFormation(List<Unit> units, Vector3 TargetPos)
    {
        for(int x = 0; x < units.Count; x++)
        {
            float radius = 5;
            float angle = x * (2 * Mathf.PI / units.Count);
            float xpos = Mathf.Cos(angle) * radius;
            float ypos = Mathf.Sin(angle) * radius;

            TargetPos = new Vector3(TargetPos.x + xpos, TargetPos.y, TargetPos.z + ypos);

            units[x].desiredPostion = TargetPos;
        }
    }
}
