using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    [SerializeField]
    float _health, _fuel, _baseHealth;
    [SerializeField]
    float _attack, _speed, _range, _fuelUsage;

    [SerializeField] private bool _selected, _usesFuel;
    [SerializeField] private GameObject _canvas, _healthBar;
    [SerializeField] public int Index;
    private NavMeshAgent _navMeshAgent;
    // Use this for initialization
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _baseHealth = _health;
        SetupHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        UpdateHealthBar();
    }

    void LateUpdate()
    {
        UpdateHealthBar();
    }

    /// <summary>
    /// Sets nav mesh agent destination upon right mouse click. 
    /// </summary>
    public void SetDestination(Vector3 destination)
    {
        _navMeshAgent.SetDestination(destination);
    }
    /// <summary>
    /// Checks if can move depending on fuel
    /// </summary>
    private void Move()
    {
        if (!_usesFuel) return;
        if (_fuel <= 0)
        {
            _navMeshAgent.isStopped = true;
            return;
        }
        _navMeshAgent.isStopped = false;
        _fuel -= _fuelUsage * Time.deltaTime;
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
        set
        {
            _selected = value;
            SetOutline();
            SetHealthBar();
        }
    }

    private void SetupHealthBar()
    {
        var healthBar = Instantiate(_healthBar);
        healthBar.transform.SetParent(_canvas.transform);
        _healthBar = healthBar;
        SetHealthBar();
    }
    /// <summary>
    /// set healthBar visible
    /// </summary>
    private void SetHealthBar()
    {
        _healthBar.SetActive(Selected);
        UpdateHealthBar();
    }
    /// <summary>
    /// update value and position of healthbar
    /// </summary>
    private void UpdateHealthBar()
    {
        _healthBar.GetComponent<Slider>().value = _health / _baseHealth;
        _healthBar.transform.position = Camera.main.WorldToScreenPoint(this.transform.position)+new Vector3(0,1,0);
    }
    void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            Selected = true;
        }
    }
}
