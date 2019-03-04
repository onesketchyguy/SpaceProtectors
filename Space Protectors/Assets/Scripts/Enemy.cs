using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float shootSpeed = 1f;

    public int scoreToAddOnDeath = 10;

    private float lastShot;

    public float shotVelocity = 10;

    public GameObject shot;

    private Health health => GetComponent<Health>() ?? gameObject.AddComponent<Health>();

    private void Start()
    {
        lastShot = Time.time + Random.Range(0, 5f);
    }

    private void Update()
    {
        //Shoot a shot.
        if (shot)
        {
            Shoot();
        }

        if (health.isDead)
        {
            Die();
        }
    }

    public void Shoot()
    {
        if (Time.time - shootSpeed > lastShot)
        {
            GameObject obj = Instantiate(shot, transform.position + -transform.up * 1.2f, Quaternion.identity) as GameObject;

            obj.GetComponent<Shot>().AddVelocity(-shotVelocity);

            lastShot = Time.time;
        }
    }

    void Die()
    {
        FindObjectOfType<ScoreKeeper>().AddScore(scoreToAddOnDeath);

        if (GetComponentInParent<EnemyFormation>())
        {
            GetComponentInParent<EnemyFormation>().Formation.Remove(transform);
        }

        Destroy(gameObject);
    }
}
