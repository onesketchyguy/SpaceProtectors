using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHP = 3;

    public int hp = 1;

    public bool isDead => hp <= 0;

    public void ModifyHealth(int mod)
    {
        int modification = hp + mod;

        modification = Mathf.Clamp(modification, 0, maxHP);

        hp = modification;
    }
}
