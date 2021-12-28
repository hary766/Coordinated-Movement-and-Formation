using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    [SerializeField]
    RectTransform selectWindow;

    private Vector2 startpos;
    private Camera cam;
    private Ray ray;

    List<Unit> SelectedUnits;
    UnitController controller;
    private void Start()
    {
        controller = FindObjectOfType<UnitController>(); //Singleton?
        cam = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            SelectionBox(Input.mousePosition);

            if(Input.GetMouseButtonDown(1))
            {
                selectWindow.gameObject.SetActive(true);
                SelectedUnits = new List<Unit>();
                startpos = Input.mousePosition;

            }
        }
        else if(Input.GetMouseButtonUp(1))
        {
            int groupnumber = UnityEngine.Random.Range (1, 3);
            selectWindow.gameObject.SetActive(false);

            Vector2 min = selectWindow.anchoredPosition - selectWindow.sizeDelta / 2;
            Vector2 max = selectWindow.anchoredPosition + selectWindow.sizeDelta / 2;

            foreach(Unit unit in controller.units)
            {
                Vector3 screenpos = cam.WorldToScreenPoint(unit.transform.position);
                if(screenpos.x > min.x && screenpos.x < max.x && screenpos.y > min.y && screenpos.y < max.y)
                {
                    controller.group.Add(groupnumber, unit);
                    unit.SetCurrentPostion(unit.transform.position);
                    unit.SetIsActive(true);
                }
            }
        }

    }
    private void SelectionBox(Vector3 mousepostion)
    {
        float width = mousepostion.x - startpos.x;
        float height = mousepostion.y - startpos.y;

        selectWindow.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs( height));
        selectWindow.anchoredPosition = startpos + new Vector2(width / 2, height / 2);
    }
}
