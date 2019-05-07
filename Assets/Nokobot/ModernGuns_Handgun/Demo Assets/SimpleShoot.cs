using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShoot : MonoBehaviour
{
    public Camera cameramain;
    public GameObject gun;
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitLocation;
    

    public float shotPower = 100f;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<Animator>().SetTrigger("Fire");
        }
    }

    void Shoot()
    {
        //  GameObject bullet;
        //  bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        // bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

       GameObject tempFlash;
        //Quaternion rotacion = barrelLocation.rotation;
        //rotacion.Set(0,0,0,0);
        //Camera.main.
        //Vector3 mousePostion = new Vector3((Camera.main.ScreenToWorldPoint(Input.mousePosition).x), 0, (Camera.main.ScreenToWorldPoint(Input.mousePosition).z));
        //Quaternion rotation = new Quaternion();
        //float angle = 90;
        //rotation.ToAngleAxis(out angle ,out mousePostion);
        //transform.Rotate(new Vector3(0, 0, 0), Space.World);
        //rotation.Set(-90, -90, 0, -90);
        /*
        Ray ray = cameramain.ScreenPointToRay(Input.mousePosition);
        print(Input.mousePosition);
        RaycastHit hit;
        //print(ray);
        if (Physics.Raycast(ray, out hit, 5))
        {
            Debug.DrawLine(barrelLocation.position, hit.point);

            GameObject projectile = Instantiate(bulletPrefab, barrelLocation.position, Quaternion.identity);
            // turn the projectile to hit.point
            projectile.transform.LookAt(hit.point);
            //Vector3 point = new Vector3(20, 20, 20);
            //Vector3 direction = (hit.point - barrelLocation.transform.position).normalized;
            //Quaternion lookRotation = Quaternion.LookRotation(direction);
            //projectile.transform.rotation = Quaternion.Slerp(projectile.transform.rotation, lookRotation,0);
            //print(hit.point);
            // accelerate it
            projectile.GetComponent<Rigidbody>().AddForce(barrelLocation.forward* shotPower);
        }*/

        Vector3 rayOrigin2 = cameramain.ViewportToWorldPoint(Input.mousePosition);
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        print("ray");
        print(rayOrigin);
        //print("ray2");
        //print(rayOrigin2);
        RaycastHit hit;
        LayerMask layerMask = ~(1 << 8);
        //if (Physics.Raycast(rayOrigin2, cameramain.transform.forward, out hit, 10))
        if (Physics.Raycast(rayOrigin.origin, rayOrigin.direction, out hit,100, layerMask))
        {
            GameObject projectile = Instantiate(bulletPrefab, barrelLocation.position, Quaternion.identity);
            //Quaternion pos = new Quaternion(hit.point.x, hit.point.y, hit.point.z, 1);
            //projectile.transform.worldToLocalMatrix* pos;
            //print("hit");
            //print(hit.point);
            //Vector3 pos = gun.transform.InverseTransformPoint(hit.point);
            //print(pos);
            gun.transform.LookAt(hit.point);
            projectile.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        }
            //Instantiate(bulletPrefab, barrelLocation.position, rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
            //tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            // Destroy(tempFlash, 0.5f);
            //  Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation).GetComponent<Rigidbody>().AddForce(casingExitLocation.right * 100f);

        }

    void CasingRelease()
    {
         GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }


}
