using System.Collections;
using System.Collections.Generic;
using BigRookGames.Weapons;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private Vector3 localScale = new Vector3(0.2f, 0.2f, 0.2f);
    [SerializeField] private float forceAmount = 100f;
    [SerializeField] private Transform gunFirePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            SpawnBullet();
        }
    }

    void SpawnBullet()
    {

        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bullet.transform.position = gunFirePos.transform.position;
        bullet.transform.localScale = localScale;
        
        Bullet bulletScript = bullet.AddComponent<Bullet>(); 
        bulletScript.SetSpeed(bulletSpeed);
        bulletScript.SetDirection(transform.forward);
        bulletScript.SetForceAmount(forceAmount);

        SphereCollider sc = bullet.AddComponent<SphereCollider>();
        sc.isTrigger = true;
        sc.radius = 0.2f;

        Destroy(bullet, 10f);
    }
}

public class Bullet : MonoBehaviour
{
    private float speed;
    private float forceAmount;
    private Vector3 direction;

    
    public void SetSpeed(float bulletSpeed)
    {
        speed = bulletSpeed;
    }

    public void SetDirection(Vector3 dir){
        direction = dir;
    }

    public void SetForceAmount(float setForceAmount){
        forceAmount = setForceAmount;
    }

    void Update()
    {
        // Move the bullet forward over time
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider){
        GameObject hitObject = collider.gameObject;
        string hitObjectName = hitObject.name;
        string hitObjectTag = hitObject.tag;
        Debug.Log("Hit Object: " + hitObjectName);

        if(hitObjectTag == "Target"){
            Rigidbody hitObjectRb = hitObject.GetComponent<Rigidbody>();

            if(hitObjectRb == null){
                Debug.LogError("No RigidBody on Target");
                hitObjectRb = hitObject.AddComponent<Rigidbody>();
                return;
            }

            hitObjectRb.useGravity = true;
            hitObjectRb.AddForce(direction * forceAmount);

            ScoreManager.Instance.AddScore();
        }

        Destroy(gameObject);
    }

}

