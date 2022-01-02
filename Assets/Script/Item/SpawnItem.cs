using System.Collections;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject shield;
    public GameObject speed;
    public GameObject health;
    public GameObject bullet;
    GameObject item;

    public int minTime, maxTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        float time;
        int count = Random.Range(1, 5);

        if(count == 1)
        {
            item = shield;
        }
        else if(count == 2)
        {
            item = speed;
        }
        else if(count == 3)
        {
            item = health;
        }
        else if(count == 4)
        {
            item = bullet;
        }

        time = Random.Range(minTime, maxTime);

        Vector2 tranformItem;
        tranformItem.x = Random.Range(-8, 8);
        tranformItem.y = Random.Range(-4, 4);

        
        yield return new WaitForSeconds(time);
        GameObject _Item = Instantiate(item, tranformItem, gameObject.transform.rotation);
        Destroy(_Item, 7f);
        StartCoroutine(Spawn());
    }
}
