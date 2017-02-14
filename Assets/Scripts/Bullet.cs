using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float Speed = 25f;
    public GameObject BulletImpact;

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
	}

    void HitTarget()
    {
        var bulletImpact = Instantiate(BulletImpact, transform.position, transform.rotation);
        Destroy(bulletImpact, 2f);
        Destroy(gameObject);
        Destroy(target.gameObject);
    }
}
