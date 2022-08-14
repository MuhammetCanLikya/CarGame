using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Araba_hareket : MonoBehaviour
{

    bool oyunbitti = false;
    public int puan=0;

    // Start is called before the first frame update
    void Start()
    {
        puan=0;
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunbitti == false)
        GetComponent<Rigidbody>().AddForce(Vector3.right * 2, ForceMode.Force);
        else if (oyunbitti == true)
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (Input.GetKey("d"))
        GetComponent<Rigidbody>().AddForce(0,0,-3, ForceMode.Force);
        if (Input.GetKey("a"))
        GetComponent<Rigidbody>().AddForce(0,0,3, ForceMode.Force);

        if (GetComponent<Rigidbody>().position.x >=70){
        oyunbitti = true;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
         Invoke("restart", 3f);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Engel")
        {
            Invoke("restart", 3f);
           oyunbitti = true;
        }
         if (collision.collider.tag == "Coin")
         {
            puan++;
            Destroy(collision.gameObject);
         }
    }

    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        oyunbitti = false;
    }
}
