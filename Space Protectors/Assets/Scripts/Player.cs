using UnityEngine;

public class Player : MonoBehaviour
{
    public float movespeed = 8;

    public float shootSpeed = 0.2f;

    public float shotVelocity = 10;

    public GameObject DefaultShot;

    internal GameObject shot;

    public float timeSinceGotShot = -1;

    private float minX, maxX;

    private Health health;

    private void Start()
    {
        health = GetComponent<Health>() ?? gameObject.AddComponent<Health>();
    }

    private void Update()
    {
        minX = GameManager.ScreenMin.x + GameManager.ScreenPadding;
        maxX = GameManager.ScreenMax.x - GameManager.ScreenPadding;

        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot a shot.
            InvokeRepeating(nameof(Shoot), 0, shootSpeed);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            CancelInvoke(nameof(Shoot));
        }

        float movX = (Input.GetAxisRaw("Horizontal") * movespeed) * Time.deltaTime;

        float xPos = transform.position.x + movX;

        xPos = Mathf.Clamp(xPos, minX, maxX);

        transform.position = new Vector3(xPos, transform.position.y, 0);

        if (health.isDead)
        {
            Die();
        }
    }

    public void Shoot()
    {
        if (timeSinceGotShot < Time.time)
        {
            shot = DefaultShot;
        }

        GameObject obj = ObjectPool.instance.GetObject(shot);
        obj.transform.position = transform.position + transform.up * 1.2f;

        obj.GetComponent<Shot>().AddVelocity(shotVelocity);
    }

    private void Die()
    {
        FindObjectOfType<GameManager>().KillPlayer();

        Destroy(gameObject);
    }
}