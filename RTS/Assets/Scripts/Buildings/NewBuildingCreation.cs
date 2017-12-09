using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBuildingCreation : MonoBehaviour {

    [SerializeField]
    GameObject _buildingPrefab;
    Vector3 _position;
    // Use this for initialization

    public void CreateNewBuilding()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        _position.x = mousePosition.x + mousePosition.y * 0.707f;    // 0.707 = sin(45)                          
        _position.z = mousePosition.z + mousePosition.y * 0.707f;    // 0.707 = cos(45)      
        _position.y = GameObject.FindGameObjectWithTag("ground").transform.position.y + _buildingPrefab.transform.localScale.y / 2;
         Instantiate(_buildingPrefab, _position, Quaternion.identity);
    }
}
