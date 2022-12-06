using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyData {
    public bool fired = false;
    public int Health { get; set; }
    public float AttackSpeed { get; set; }
    public float AttackDistance { get; set; }
    public float MovementSpeed { get; set; }
    public EnemyTypez _enemy_type {get; set;}
    public ProjectileTypez _projectile_type {get; set;}
    public GameObject SelfObject { get; set; }

    public EnemyData(int health, float attack_speed, float attack_distance, float movement_speed, EnemyTypez enemy_type, ProjectileTypez projectile_type) {
        Health = health;
        AttackSpeed = attack_speed;
        AttackDistance = attack_distance;
        MovementSpeed = movement_speed;
        _enemy_type = enemy_type;
        _projectile_type = projectile_type;
    }

}

