using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    public int level = 0;
    public bool to_be_destroyed = false;

    private GameObject circleMakerObject;
    void OnCollisionEnter2D(Collision2D collision)
    {

        if(to_be_destroyed == false && 
            collision.gameObject.tag == "c" &&
            gameObject.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic &&
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic &&
            collision.gameObject.GetComponent<ObjectHandler>().level == level
            )
        {
            Vector3 v1 = collision.transform.position;
            Vector3 v2 = gameObject.transform.position;

            Vector3 velocity1 = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            Vector3 velocity2 = gameObject.GetComponent<Rigidbody2D>().velocity;

            collision.gameObject.GetComponent<ObjectHandler>().to_be_destroyed = true;


            Destroy(collision.gameObject);
            Destroy(gameObject);

            GameObject new_circle = circleMakerObject.GetComponent<InputHandler>().createCircle((v1 + v2) / 2, level + 1);
            if(level+1 == 8)
            {
                // game clear
                Debug.Log("축하합니다!");
                circleMakerObject.GetComponent<UIChanger>().setWin();
            }

            if (new_circle != null)
            {
                new_circle.GetComponent<Rigidbody2D>().velocity = (velocity1 + velocity2);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        circleMakerObject = GameObject.Find("Circlemaker");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -6.49)
        {
            // game over
            Debug.Log("게임 오버!");
            circleMakerObject.GetComponent<UIChanger>().setLose();
            Destroy(gameObject);
        }
    }
}
