using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimator : MonoBehaviour
{
    private bool rotated;
    private bool done;
    private float timer = 10f;
    private bool text = false;
    private float fakeAngle;
    private int flicker;
    private bool cameraSet = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!gameObject.tag.Equals("MainCamera"))
        {
            timer = 0.75f;
            text = true;
            fakeAngle = 18000;
               
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.tag.Equals("MainCamera") && cameraSet == false)
        {
            cameraSet = true;
            timer = 7f;
            text = false;
            fakeAngle = -360;

        }

        if (text)
        {

            

            transform.position = new Vector3(GameObject.Find("Main Camera").transform.position.x, GameObject.Find("Main Camera").transform.position.y + 1.5f, GameObject.Find("Main Camera").transform.position.z);
            if (fakeAngle > 360)
            {
                transform.Rotate(Vector3.forward,-Time.fixedDeltaTime*5000);
                fakeAngle -= Time.fixedDeltaTime * 5000;
            }
            else if (!rotated)
            {
                transform.rotation = Quaternion.identity;
                fakeAngle = 360;
                rotated = true;              
            }

            if (fakeAngle > 180 && rotated)
            {
                transform.Rotate(Vector3.forward, -Time.deltaTime * 500);
                fakeAngle -= Time.fixedDeltaTime*500;                
            }
            else if (fakeAngle > 0 && rotated)
            {
                transform.rotation = new Quaternion(0, 0, 180, transform.rotation.w);
                fakeAngle = 180;
                done = true;               
            }

            if (done == true)
            {
                if (timer <= 0)
                {
                    GameObject.FindGameObjectWithTag("MainCamera").AddComponent<TextAnimator>();
                    Destroy(gameObject);
                }
                else
                {
                    timer -= Time.fixedDeltaTime;
                }
            }
        }
        else
        {
            if(fakeAngle < -180)
            {
                transform.Rotate(Vector3.forward,Time.fixedDeltaTime * 500);
                fakeAngle += Time.fixedDeltaTime * 500;
               
            }
            else
            {
                
                if (timer > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 180);                   
                    fakeAngle = 180;
                    timer -= Time.fixedDeltaTime;
                    
                }
                else if(fakeAngle > 0.1f)
                {
                    transform.Rotate(Vector3.forward,-Time.fixedDeltaTime * 500);
                    fakeAngle -= Time.fixedDeltaTime * 500;
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    Destroy(this);
                }
               
            }
        }



    
    }   
}
