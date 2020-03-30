using System.Collections;
using UnityEngine;

public class Person : MonoBehaviour
{
    float speed = 0.9f;
    Vector3 localV3;
    public int dir = 1;
    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(localV3) * 5;
        Gizmos.DrawRay(transform.position, direction);
    }

    // Start is called before the first frame update
    void Start()
    {
        localV3 = new Vector3(0, 0, 0);
        randR(Random.Range(1, 9));
        // StartCoroutine(waitabit());
        // InvokeRepeating("UpdateLocalV3", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(localV3 * Time.deltaTime * speed);
        //randR(dir);
    }

    //  7 6 5 
    //  8   4     
    //  1 2 3
    int[] goDown = new int[] { 1, 2, 3, 8, 4 };
    int[] goLeft = new int[] { 1, 8, 7, 2, 6 };
    int[] goUp = new int[] { 5, 6, 7, 8, 4 };
    int[] gorigt = new int[] { 5, 4, 3, 6, 2 };
    void randR(int r)
    {
        print(r);
        switch (r)
        {
            case 1:
                localV3 = new Vector3(-1, 0, -1);
                break;
            case 2:
                localV3 = new Vector3(0, 0, -1);
                break;
            case 3:
                localV3 = new Vector3(1, 0, -1);
                break;
            case 4:
                localV3 = new Vector3(1, 0, 0);
                break;
            case 5:
                localV3 = new Vector3(1, 0, 1);
                break;
            case 6:
                localV3 = new Vector3(0, 0, 1);
                break;
            case 7:
                localV3 = new Vector3(-1, 0, 1);
                break;
            case 8:
                localV3 = new Vector3(-1, 0, 0);
                break;
            case 0:
                localV3 = new Vector3(0, 0, 0);
                break;


        }
        // localV3 = new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2)).normalized;

    }

    void Decide(int[] reffarra)
    {
        int direction = reffarra[Random.Range(0, 3)];
        randR(direction);
    }

    void DecideOnTag(string argtag)
    {
        print(argtag);
        if (string.Compare(argtag, "botwall") == 0) { Decide(goUp); }
        else
                if (string.Compare(argtag, "upwall") == 0) { Decide(goDown); }
        else
                if (string.Compare(argtag, "rightwall") == 0) { Decide(goLeft); }
        else
                if (string.Compare(argtag, "leftwall") == 0) { Decide(gorigt); }

    }

    void UpdateLocalV3() { localV3 = new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2)).normalized; }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("boom");
        DecideOnTag(other.gameObject.tag);

    }


    IEnumerator waitabit()
    {
        yield return new WaitForSeconds(1f);

    }






}
