using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour
{
    public float speed = 3;

    public bool movingLeft;

    public Transform leftMost, rightMost;

    float minX, maxX;

    public List<Transform> Formation = new List<Transform>() { };

    public GameObject EnemyPrefab;

    private void Start()
    {
        foreach (var child in transform.GetComponentsInChildren<Transform>())
        {
            if (child == transform) continue;

            GameObject enemy = Instantiate(EnemyPrefab, child.position, child.rotation, child);

            Formation.Add(enemy.transform);
        }
    }

    private void Update()
    {
        if (Formation.Count == 0)
        {
            Destroy(gameObject);

            return;
        }

        foreach (var unit in Formation)
        {
            if (leftMost == null || unit.position.x < leftMost.position.x)
            {
                leftMost = unit;
            }

            if (rightMost == null || unit.position.x > rightMost.position.x)
            {
                rightMost = unit;
            }
        }

        minX = GameManager.ScreenMin.x + GameManager.ScreenPadding;
        maxX = GameManager.ScreenMax.x - GameManager.ScreenPadding;

        if (leftMost.position.x < minX || rightMost.position.x > maxX)
        {
            movingLeft = !movingLeft;
        }

        float moveSpeed = (movingLeft ? -speed : speed) * Time.deltaTime;

        float posX = (transform.position.x + moveSpeed);

        transform.position = new Vector3(posX, transform.position.y);
    }
}
