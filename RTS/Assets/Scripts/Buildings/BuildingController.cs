using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour {


    bool _isCreating = true;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update()
    {
        if (_isCreating)
            moveNewBuilding();

        if(Input.GetMouseButtonDown(0))
              _isCreating = false;
        

    }

    void moveNewBuilding()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.x += mousePosition.y * 0.707f; // 0.707 = sin(45) 
        mousePosition.z += mousePosition.y * 0.707f; // 0.707 = cos(45) 
        mousePosition.y = transform.position.y;
        transform.position = mousePosition;  
    }

}
