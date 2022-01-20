# Coordinated Movement and Formation

### Introduction

The aim of the project is to create movement and formation code for a postive game experience with a RTS-style of game.
In this reseach i will be using unity 3D. This paper will evolve with the progress made.

> Current state

![Alt Text](https://media.giphy.com/media/U7b3FguUXQuHHfqQh1/giphy.gif)



## Groups
You are able to select groups of units. This is done by a list of selected objects, that is saved in another list.
The new group gets their own colour that is randomly generated.

```
  public List<Unit> Selected = new List<Unit>();
  public List<List<Unit>> Groups = new List<List<Unit>>();
  
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
  
```


![Alt Text](https://media.giphy.com/media/S1SN9WjyNm0j4MPdyO/giphy.gif)

## Formations

For both my formations,I used an interface to easily select a new formation and make new ones later on.

```
public interface IFormations
{
    void ExercuteFormation(List<Unit> units, Vector3 TargetPos);
}

```
updating the formation
```
public void UpdateFormation()
    {
        //Get Current Selected group

        //Get Current Formation
        if (Groups.Count >= 1)
        {
            Debug.Log(Groups.Count);
            //formations.ExercuteFormation(Selected, target);
           formation.ExercuteFormation(Groups[Groups.Count-1], Targetpostion);
        } 
    }
```

Circle Formation:

![Alt Text](https://media.giphy.com/media/WKmtleUsDExaYKqSkW/giphy.gif)

SquareFormation:

![Alt Text](https://media.giphy.com/media/FLmO4QkH9u7yxWAQ7V/giphy.gif)






##### Resources and helpfull
```
 + https://www.gamasutra.com/view/feature/3314/coordinated_unit_movement.php?print=1
 
 + https://www.gamedeveloper.com/programming/coordinated-unit-movement

```

![Alt Text](https://media.giphy.com/media/4grrK5QCd7ewawvw8k/giphy.gif)
