using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public GameObject[] ShieldPieces;

    public Transform[] SpawnPoints;

    public void SpawnShield()
    {
        for (int i = 0; i < ShieldPieces.Length; i++)
        {
            Instantiate(ShieldPieces[i], SpawnPoints[i].position, SpawnPoints[i].rotation);
        }
    }
}
