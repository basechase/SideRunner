using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private bool startCollided = false;

    

    public bool Collided { get { return startCollided; } }
    private bool _collided = false;


    public bool Contact()
    {
        _collided = true;
        return true;
    }


    void Start()
    {
      
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.TryGetComponent(out CollisionController collisionController))
        {
            if(collisionController.Contact())
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

               
                
            }
        }
    }
}
