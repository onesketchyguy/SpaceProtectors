using UnityEngine;

public class Shot : MonoBehaviour
{
    public int damage = 1;

    public AudioClip shotSound;

    private void FixedUpdate()
    {
        if (OffScreen())
        {
            ObjectPool.instance.ReturnObject(gameObject);
        }
    }

    public void AddVelocity(float shotVelocity)
    {
        float ySize = Mathf.Clamp(shotVelocity, -1, 1);

        transform.localScale = new Vector3(1, ySize, 1);

        if (GetComponent<AudioSource>())
        {
            GetComponent<AudioSource>().clip = shotSound;

            GetComponent<AudioSource>().Play();
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, shotVelocity);
    }

    public bool OffScreen()
    {
        float maxY, minY;

        minY = GameManager.ScreenMin.y - GameManager.ScreenPadding;
        maxY = GameManager.ScreenMax.y + GameManager.ScreenPadding;

        return (transform.position.y > maxY) || (transform.position.y < minY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health hp = collision.gameObject.GetComponent<Health>();

        if (hp)
        {
            hp.ModifyHealth(-damage);
        }

        var explosion = ObjectPool.instance.GetExplosion();
        explosion.transform.position = transform.position;

        ObjectPool.instance.ReturnObject(gameObject);
    }
}