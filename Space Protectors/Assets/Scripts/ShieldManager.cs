using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public GameObject[] ShieldPieces;

    public Transform[] SpawnPoints;

    public void SpawnShield()
    {
        foreach (var child in transform.GetComponentsInChildren<Transform>())
        {
            if (child.transform == transform || child.name.Contains("SpawnPoint")) continue;

            Destroy(child.gameObject);
        }

        for (int i = 0; i < ShieldPieces.Length; i++)
        {
            Instantiate(ShieldPieces[i], SpawnPoints[i].position, SpawnPoints[i].rotation);
        }
    }
}
