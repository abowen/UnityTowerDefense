using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private  Transform Target;

    [Header("Attributes")]

    public float Range = 15f;
    public float FireRate = 1f;
    public float TurnSpeed = 10f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    public string EnemyTag = "Enemy";
    public Transform PartToRotate;

    public GameObject BulletPrefab;
    public Transform FirePoint;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);

        var shortestDistance = Range;
        Target = null;
        foreach (var enemy in enemies)
        {
            var distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                Target = enemy.transform;
            }
        }
    }

    private void Update()
    {
        if (Target == null)
        {
            return;
        }

        Vector3 direction = Target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * TurnSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / FireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    private void Shoot()
    {
        var bulletGameObject = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        var bullet = bulletGameObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(Target);
        }
    }

}
