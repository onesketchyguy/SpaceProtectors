using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    public PowerUp[] powerUps;

    public GameObject GetPowerUp()
    {
        GameObject toReturn = new GameObject();

        PowerUp powerUpToUse = powerUps[Random.Range(0, powerUps.Length)];

        toReturn.AddComponent<SpriteRenderer>().sprite = powerUpToUse.sprite;

        toReturn.AddComponent<WorldPowerUp>().powerUp = powerUpToUse;

        toReturn.AddComponent<BoxCollider2D>();

        toReturn.AddComponent<Rigidbody2D>();

        return toReturn;
    }
}
