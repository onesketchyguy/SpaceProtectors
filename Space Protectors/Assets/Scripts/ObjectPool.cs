using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private void Awake() => instance = this;

    private List<GameObject> objects = new List<GameObject>();

    public GameObject shotPrefab;

    public GameObject GetObject(GameObject _object)
    {
        if (objects.Count > 0)
        {
            foreach (var item in objects)
                if (item.activeSelf == false && (item.name == _object.name && item.tag == _object.tag))
                {
                    item.SetActive(true);

                    return item;
                }
        }

        var go = Instantiate(_object, transform);
        go.name = _object.name;

        objects.Add(go);

        return go;
    }

    public GameObject GetBullet()
    {
        if (objects.Count > 0)
        {
            foreach (var item in objects)
                if (item.activeSelf == false && item.tag == "Bullet")
                {
                    item.SetActive(true);

                    return item;
                }
        }

        var go = Instantiate(shotPrefab, transform);

        objects.Add(go);

        return go;
    }

    public GameObject explosionPrefab;

    public GameObject GetExplosion()
    {
        if (objects.Count > 0)
        {
            foreach (var item in objects)
                if (item.activeSelf == false && item.tag == "Explosion")
                {
                    item.SetActive(true);

                    return item;
                }
        }

        var go = Instantiate(explosionPrefab, transform);

        objects.Add(go);

        return go;
    }

    public void ReturnObject(GameObject objectReturning)
    {
        objectReturning.SetActive(false);
        objectReturning.transform.position = Vector3.zero;

        var rigid = objectReturning.GetComponent<Rigidbody2D>();
        if (rigid)
        {
            rigid.velocity = Vector2.zero;
        }
    }
}