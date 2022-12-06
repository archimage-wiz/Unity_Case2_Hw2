using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ProjectileData {
    public float projectile_dairection = 1.0f;
    public float Damage { get; set; }
    public float MovementSpeed { get; set; }
    public float LifeTime { get; set; }
    public ProjectileTypez ProjectileType { get; set; }
    public GameObject SelfObject { get; set; }

    public ProjectileData(float damage, float move_speeed, float life_time, ProjectileTypez type) {
        Damage = damage;
        MovementSpeed = move_speeed;
        LifeTime = life_time;
        ProjectileType = type;
    }

}


