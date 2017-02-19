using System.Linq;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float Speed = 25f;
    public GameObject BulletImpact;
    public float ExplosionRadius = 0f;

    public void Seek(Transform _target)
    {
        target = _target;
    }
	
	void Update () {
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        var direction = target.position - transform.position;
        var distanceThisFrame = Speed * Time.deltaTime;

        // Avoid overshooting
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
	}

    void HitTarget()
    {
        var bulletImpact = Instantiate(BulletImpact, transform.position, transform.rotation);
        Destroy(bulletImpact, 5f);

        if (ExplosionRadius > 0f)
        {
            Explode();
        } else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        var colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);
        var enemies = colliders.Where(c => c.tag == "Enemy");
        foreach(var enemy in enemies)
        {
            Damage(enemy.transform);
        }
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
}
