using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = -6;
    public int maxInstances = 4096;
    public int instances = 0;

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            spawn();
        }

    }

    IEnumerator Start() {
        while(true) {
            yield return new WaitForSeconds(1f);
            OutputTime();
        }
    }

    void OutputTime() {
        if(instances > maxInstances){
            return;
        }

        spawn();
    }

    void spawn(){
        Rigidbody p = Instantiate(projectile, transform.position, transform.rotation);
        p.transform.parent = gameObject.transform;
        p.velocity = transform.up * speed;
        instances++;

        StartCoroutine(DisablePhysics(p, 1f));
    }



    IEnumerator DisablePhysics(Rigidbody p, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        p.GetComponent<Rigidbody>().isKinematic = true;
    }

}
