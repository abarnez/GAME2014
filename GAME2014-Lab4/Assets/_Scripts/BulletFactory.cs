using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletFactory : MonoBehaviour
{

    [Header("Bullet Types")]
    public GameObject regularBullet, fatBullet, pulsingBullet;

    public BulletManager bulletManager;
    // Start is called before the first frame update
   
    public GameObject createBullet(BulletType type = BulletType.RANDOM)
    {

        if(type == BulletType.RANDOM)
        {
            var randomBullet = Random.Range(0, 3);
            type = (BulletType) randomBullet;
        }
        

        

        GameObject tempBullet = null;
        switch (type)
        {
            case BulletType.REGULAR:
               tempBullet = Instantiate(regularBullet);
                tempBullet.GetComponent<BulletController>().damage = 10;
                break;
            case BulletType.FAT:
                tempBullet = Instantiate(fatBullet);
                tempBullet.GetComponent<BulletController>().damage = 20;
                break;
            case BulletType.PULSING:
                tempBullet = Instantiate(pulsingBullet);
                tempBullet.GetComponent<BulletController>().damage = 30;
                break;

               
        }
        tempBullet.SetActive(false);
        tempBullet.transform.parent = transform;
        return tempBullet;
    }

}
