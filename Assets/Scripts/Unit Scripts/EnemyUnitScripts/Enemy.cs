using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [Header("Enemy Targeting")]
    [SerializeField]
    GameObject target;
    public GameObject Target { get { return target; } set { target = value; } }
    public float damage = 1;
    public float range = 100f;
    public GameObject firePoint;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    private void FixedUpdate()
    {
        
    }



    private void OnCollisionEnter(Collision collision)
    {
        Unit unitCollided = collision.gameObject.GetComponent<Unit>();
        if (unitCollided)
        {
            HealthComponent unitHealthComponent = unitCollided.gameObject.GetComponent<HealthComponent>();
            if (unitHealthComponent)
            {
                unitHealthComponent.TakeDamage(1);
                Destroy(this.gameObject);
            }
        }
        else
        {
            Debug.Log("Not Unit collided");
        }
    }

    public void ShootTarget()
    {
        RaycastHit hit;
        if(Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, range))
        {
            Debug.Log("Object Hit: " + hit.transform.name);
        }
        

    }

}
