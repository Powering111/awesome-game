using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputHandler : MonoBehaviour
{
    public GameObject[] circleObjects;
    public GameObject arrowObject;
    
    private double cooltime = 0;
    public int turn = 0;
    private int next_level = 0;
    private GameObject holding_circle = null;
    // Start is called before the first frame update
    void Start()
    {
        holding_circle = createCircle(new Vector3(0.0f, 4.81f, 0.0f), next_level);
        holding_circle.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        holding_circle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        cooltime -= Time.deltaTime;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        Vector3 new_position1 = arrowObject.transform.position;
        new_position1.x = mouseWorldPos.x;
        arrowObject.transform.position = new_position1;

        if (holding_circle != null)
        {
            Vector3 new_position2 = holding_circle.transform.position;
            new_position2.x = mouseWorldPos.x;
            holding_circle.transform.position = new_position2;
        }

        if (cooltime < 0)
        {
            holding_circle.SetActive(true);
        }
        else
        {
            //arrowObject.SetActive(false);
        }

        if (Input.GetMouseButton(0) && cooltime < 0 )
        {
            holding_circle.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            holding_circle.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-0.2f, 0.2f), 0.0f, 0.0f);


            cooltime = 0.5;
            
            next_level = Random.Range(0,2+turn/4) % 4;
            turn += 1;
            holding_circle = createCircle(new Vector3(0.0f, 4.81f, 0.0f), next_level);
            holding_circle.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            holding_circle.SetActive(false);
        }
    }

    public GameObject createCircle(Vector3 pos, int level)
    {
        if(level<0 || level >= circleObjects.Length)
        {
            return null;
        }

        GameObject a = Instantiate(circleObjects[level], pos, Quaternion.identity);
        a.GetComponent<ObjectHandler>().level = level;
        return a;
    }
}
