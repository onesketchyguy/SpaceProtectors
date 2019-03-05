using UnityEngine;

[CreateAssetMenu(menuName = "Create Powerup", fileName = "New Powerup")]
public class PowerUp : ScriptableObject
{
    public Sprite sprite;

    public int livesToAdd;

    public bool regenShields;

    public bool createShield;

    public GameObject lazer;

    public int time = 10;
}
