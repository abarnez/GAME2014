using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{

    public GameObject bullet;
    public int MaxBullets;

    private Queue<GameObject> bulletPool;
    // Start is called before the first frame update
    void Start()
    {
        BuildBulletPool();
    }

    // Update is called once per frame
 

    private void BuildBulletPool()
    {
        bulletPool = new Queue<GameObject>();

        for (int i = 0; i < MaxBullets; i++)
        {
            var tempBullet = Instantiate(bullet);
            tempBullet.SetActive(false);
            tempBullet.transform.parent = transform;
            bulletPool.Enqueue(tempBullet);
            
        }
    }

    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = bulletPool.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;
        
        
        return newBullet;

    }

    public void ReturnBullet(GameObject returnedBullet)
    {
        
        returnedBullet.SetActive(false);
        bulletPool.Enqueue(returnedBullet);
    }

}
