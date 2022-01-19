using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectPosition : MonoBehaviour, IPointerClickHandler
{
    public Vector3 CurrentPosition;
    public Vector3 LastPosition;

    [SerializeField]
    private UnitController unitController;

    private void Awake()
    {
        addPhysicsRaycaster();
        CurrentPosition = Vector3.zero;
        LastPosition = Vector3.zero;
    }
    //Add a physic Raycast to camera, if there wasn't one yet.
    void addPhysicsRaycaster()
    {
        PhysicsRaycaster physicsRaycaster = GameObject.FindObjectOfType<PhysicsRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }
    //Get the 2D click postion to world postion if the value is valid
    public void OnPointerClick(PointerEventData eventData)
    {
        //Left mouse button
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (eventData != null)
            {
                LastPosition = CurrentPosition; // keep the old postion
                var worldPos = eventData.pointerCurrentRaycast.worldPosition;
                CurrentPosition = worldPos;

                unitController.GetNewPostion(CurrentPosition);
            }

        }
          
    }
}
