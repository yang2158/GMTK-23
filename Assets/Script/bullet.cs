using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset= new Vector3(0,0,0);
    public float bulletSpeed= 1f;
    bool start = false;
    float create = 0;
    public float dis = 0;
    public int type;
    public float slothRave = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        create += Time.deltaTime;
        if (target)
        {
            if (transform.position.y < 0)
            {
                GameObject.Destroy(gameObject);
            }
            start = true;
            transform.position += (target.transform.position - transform.position).normalized * bulletSpeed  *Time.deltaTime;
            face();
            if (getDist(transform.position, target.transform.position ) < 0.2)
            {
                if (target.GetComponent<Enemy>())
                {
                    if(type == 1 )
                        target.GetComponent<Enemy>().shot(100);
                    if (type == 2)
                        target.GetComponent<Enemy>().worth*=1.2f;
                    if (type == 3)
                    {
                        target.GetComponent<Enemy>().worth -= 3;
                        target.GetComponent<Enemy>().shot(300);
                    }
                    if (type == 4)
                    {
                        slothRave -= Time.deltaTime;
                        if (target.GetComponent<BasicEnemy>())
                        {
                            target.GetComponent<BasicEnemy>().speedMulti = 0.3f;
                        }
                        if (slothRave < 0)
                        {

                            GameObject.Destroy(gameObject);
                        }
                    }else
                        GameObject.Destroy(gameObject);
                }

            }
        }
        if( start && !target)
        {

            gameObject.GetComponent<SpriteRenderer>().color -= Color.black * (Time.deltaTime)*4 ;
            if (gameObject.GetComponent<SpriteRenderer>().color.a <= 0.1f) GameObject.Destroy(gameObject);
        }
        if(!start && create> 1)
        {
            GameObject.Destroy(gameObject);
        }
    }
    public float getDist(Vector2 a, Vector2 b)
    {

        return Mathf.Abs(Mathf.Sqrt(Mathf.Pow(a.x - b.x,2) + Mathf.Pow(a.y-b.y,2)));
    }
    float inverseTan(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg ;
    }
    protected void face()
    {

        float angle = inverseTan(transform.position, target.transform.position);
        var targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.5f);

    }
    private void Awake()
    {
        
    }
}
