using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMananger : MonoBehaviour
{

    [SerializeField] private float _player_movement_speed = 2.0f;
    [SerializeField] private GameObject _ground;

    //private GameObject _ground_obj;
    private ManagerComponent _manager;
    

    void Start()
    {
        //_ground_obj = GameObject.Find("Ground");
        //Debug.Log(_ground_obj);
        //_manager = _ground_obj.GetComponent<ManagerComponent>();
        _manager = _ground.GetComponent<ManagerComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > _ground.transform.position.x - (_ground.transform.localScale.x * 10 / 2)) {
            transform.position += new Vector3(-1.0f, 0, 0) * _player_movement_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < _ground.transform.position.x + (_ground.transform.localScale.x * 10 / 2)) {
            transform.position += new Vector3(1.0f, 0, 0) * _player_movement_speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            _manager.Fire(this.gameObject);
        }
    }
}
