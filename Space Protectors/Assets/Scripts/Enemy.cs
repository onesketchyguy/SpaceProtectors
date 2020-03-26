using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float shootSpeed = 1f;

    public int scoreToAddOnDeath = 10;

    private float lastShot;

    public float shotVelocity = 10;

    private Health health => GetComponent<Health>() ?? gameObject.AddComponent<Health>();

    private void Start()
    {
        lastShot = Time.time + Random.Range(0, 5f);
    }

    private void Update()
    {
        //Shoot a shot.
        Shoot();

        if (health.isDead)
        {
            Die();
        }
    }

    public void Shoot()
    {
        if (Time.time - shootSpeed > lastShot)
        {
            GameObject obj = ObjectPool.instance.GetBullet();
            obj.transform.position = transform.position + -transform.up * 1.2f;

            obj.GetComponent<Shot>().AddVelocity(-shotVelocity);

            lastShot = Time.time;
        }
    }

    private void Die()
    {
        FindObjectOfType<ScoreKeeper>().AddScore(scoreToAddOnDeath);

        if (GetComponentInParent<EnemyFormation>())
        {
            GetComponentInParent<EnemyFormation>().Formation.Remove(transform);
        }

        int i = Random.Range(0, 20);

        if (i >= 17)
        {
            GameObject powerup = FindObjectOfType<PickUpManager>().GetPowerUp();

            powerup.transform.position = transform.position;
        }

        Destroy(gameObject);
    }
}