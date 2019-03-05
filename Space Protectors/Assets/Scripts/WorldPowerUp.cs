using UnityEngine;

public class WorldPowerUp : MonoBehaviour
{
    public PowerUp powerUp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (powerUp.livesToAdd > 0)
            {
                //Adding of lives
                FindObjectOfType<GameManager>().lives += powerUp.livesToAdd;
            }

            if (powerUp.lazer != null)
            {
                //Adding of a new lazer

                Player p = collision.gameObject.GetComponent<Player>();

                p.shot = powerUp.lazer;

                p.timeSinceGotShot = Time.time + powerUp.time;
            }

            if (powerUp.regenShields)
            {
                //Regenshields
                foreach (var shield in FindObjectsOfType<ShieldManager>())
                {
                    shield.SpawnShield();
                }
            }

            Destroy(gameObject);
        }
    }
}
