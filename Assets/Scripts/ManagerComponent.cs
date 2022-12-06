using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerComponent : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _enemy;
    private List<EnemyData> _enemy_data;
    private List<ProjectileData> _projectile_data;


    public void CreateEnemy() {
        EnemyData _new_obj = new EnemyData(100, 50, 10, 2.5f, EnemyTypez.ork, ProjectileTypez.bullet);
        _new_obj.SelfObject = Instantiate(_enemy);
        _new_obj.SelfObject.transform.position = new Vector3(Random.Range(-5, 5), 1, 12);
        _enemy_data.Add(_new_obj);
    }
    public void CreateProjectile(Vector3 position, float projectile_dairection = 1.0f) {
        ProjectileData _new_obj = new ProjectileData(0, 5.0f, 2000, ProjectileTypez.bullet);
        _new_obj.projectile_dairection = projectile_dairection;
        _new_obj.SelfObject = Instantiate(_bullet);
        _new_obj.SelfObject.transform.position = position;
        _projectile_data.Add(_new_obj);
    }


    public void Fire(GameObject iniciator) {
        CreateProjectile(iniciator.transform.position + new Vector3(0, 0, 1));     
    }
    public void EnemyFire(GameObject iniciator) {
        CreateProjectile(iniciator.transform.position + new Vector3(0, 0, -1), -1.0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        _projectile_data = new List<ProjectileData>();
        _enemy_data = new List<EnemyData>();
        //Debug.Log("Started");        
    }

    // Update is called once per frame
    void Update()
    {
        ProjectileData _to_remove = null;
        foreach (var projectile in _projectile_data) {
            projectile.SelfObject.transform.position += projectile.SelfObject.transform.forward * projectile.MovementSpeed * projectile.projectile_dairection * Time.deltaTime;
            projectile.LifeTime--;
            if (projectile.LifeTime < 0) {
                _to_remove = projectile;
            }
        }
        if (_to_remove != null) {
            Destroy(_to_remove.SelfObject);
            _projectile_data.Remove(_to_remove);
        }

        if(Random.Range(0, 100 * Time.deltaTime) < 1 * Time.deltaTime) {
            CreateEnemy();
        }

        EnemyData _to_remove2 = null;
        foreach (var enemy in _enemy_data) {
            enemy.SelfObject.transform.position += new Vector3(0, 0, -enemy.MovementSpeed) * Time.deltaTime;
            if(enemy.SelfObject.transform.position.z < -5 || enemy.Health < 0) {
                _to_remove2 = enemy;
            } else if (!enemy.fired && Vector3.Distance(enemy.SelfObject.transform.position, _player.transform.position) < enemy.AttackDistance) {
                EnemyFire(enemy.SelfObject);
                enemy.fired = true;
            }
        }

        if (_to_remove2 != null) {
            Destroy(_to_remove2.SelfObject);
            _enemy_data.Remove(_to_remove2);
        }



    }
}
