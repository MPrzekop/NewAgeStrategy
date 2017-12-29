using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Formations;
using UnityEngine;

public class SelectedUnitController : MonoBehaviour {
    public List<Unit> SelectedUnits { get; set; }
	// Use this for initialization
	void Start () {
		SelectedUnits = new List<Unit>();
	}
	
	// Update is called once per frame
	void Update () {
		SetDestination();
	}

    void SetDestination()
    {
        var formation = new FullSquareFormation(SelectedUnits.Count);
        if (!Input.GetMouseButtonDown(1)) return;
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit hit;
        Ray ray = new Ray(pos, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit))
        {
            for (int i = 0; i < SelectedUnits.Count; i++)
            {
               SelectedUnits[i].SetDestination(hit.point+formation.UnitRelativePosition(i));
                SelectedUnits[i].Index = i;
            }
        }
        
    }
}
