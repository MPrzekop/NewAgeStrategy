using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnitScript : MonoBehaviour
{
    private Vector3 _startPosition;

    private Vector3 _endPosition;

    private bool isSelecting;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Set origin of selection rect
            _startPosition = Input.mousePosition;
            isSelecting = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isSelecting = false;
        }
        if (!isSelecting) return;
        GetComponent<SelectedUnitController>().SelectedUnits = new List<Unit>();
        foreach (var obj in FindObjectsOfType<Unit>())
        {
            //set objects as selected if they are within selection
            obj.Selected = IsWithinSelectionBounds(obj.gameObject);
            if(obj.Selected)
            GetComponent<SelectedUnitController>().SelectedUnits.Add(obj);
        }
    }


    public bool IsWithinSelectionBounds(GameObject gameObject)
    {
        if (!isSelecting)
            return false;

        var camera = Camera.main;
        //create gameWorld selection area
        var viewportBounds = UnitSelectionUtils.GetViewportBounds(camera, _startPosition, Input.mousePosition);
        //check object if object position is within selection area. 
        //TODO Expand selection not only to the center of origin but also geometry.
        return viewportBounds.Contains(camera.WorldToViewportPoint(gameObject.transform.position));
    }

    void OnGUI()
    {
        if (isSelecting)
        {
            // Create a rect from both mouse positions
            var rect = UnitSelectionUtils.GetScreenRect(_startPosition, Input.mousePosition);
            UnitSelectionUtils.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            UnitSelectionUtils.DrawScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
        }
    }
}
