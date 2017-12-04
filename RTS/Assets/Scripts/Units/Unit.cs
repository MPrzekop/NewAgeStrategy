using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour {
    [SerializeField]
    float _health, _fuel;
    [SerializeField]
    float _attack, _speed, _range;

    [SerializeField] private bool _selected;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SetDestination();
        SetOutline();
	    
	}

    /// <summary>
    /// Sets nav mesh agent destination upon right mouse click. 
    /// </summary>
    private void SetDestination()
    {
        if (!_selected || !Input.GetMouseButtonDown(1)) return;
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit hit;
        Ray ray = new Ray(pos, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit))
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
            Debug.DrawRay(ray.origin, ray.direction * 4, Color.blue, 10);
        }
    }
    /// <summary>
    /// Sets shaders outline depending on selection.
    /// </summary>
    private void SetOutline()
    {
        GetComponent<Renderer>().material.SetFloat("_Outline", Selected ? 0.09f : 0.00f);
    }
    /// <summary>
    /// Is unit selected?
    /// </summary>
    public bool Selected
    {
        get { return _selected; }
        set { _selected = value; }
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            Selected = true;
        }
    }
}
