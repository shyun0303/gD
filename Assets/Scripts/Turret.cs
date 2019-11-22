using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform target;
    [Header("Atrributes")]
    //터렛이 쳐다보게될 타겟
    public float range = 15f;
    //터렛이 적을 인식할 수 있는 범위
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Field")]
    public string enemyTag = "Enemy";
    //터렛이 인식할 적의 태그
    public Transform partToRotate;
    //터렛이 중심으로 회전할 회전축
    public float turnSpeed = 10f;
    //터렛의 회전할때 속도

    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        //UpdateTarget함수를 딜레이 없이, 0.5초 마다 호출 무한 반복
    }

    void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); //Enemy라는 태그를 갖은 것들을 enemies[]배열에 저장
        float shortestDistance = Mathf.Infinity; //가장 짧은 거리를 무한으로 둔다.
        GameObject nearestEnemy = null; //가장 가까운 적을 null 로 둔다

        foreach (GameObject enemy in enemies) //enemy가 enemies의 수만큼 반복
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); //터렛과 enemy의 거리
            if (distanceToEnemy < shortestDistance) //터렛과 enemy의 거리가 가장 짧은 거리보다 작으면 
            {
                shortestDistance = distanceToEnemy; //가장 짧은 거리는 터렛과enemy 거리가 되고
                nearestEnemy = enemy; //가장 가까운 적은 enemy가됨
            }

        }
        if (nearestEnemy != null && shortestDistance <= range) //만약 가까운 적이 없고, 가장 짧은 거리가 터렛의 범위보다 짧으면
        {
            target = nearestEnemy.transform; //타겟은 다시한번 가장 가까운 놈으로바뀜
        }
        else {
            target = null; //아니면 타겟은 없는겨
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return; //타겟없으면 카마있고

        Vector3 dir = target.position - transform.position; //타겟과 터렛의 위치를 뺀 값을 dir로 갖고
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);  //회전 하는 건데 따로설명

        if (fireCountdown <= 0f) {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }
    void Shoot() {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; //범위 만큼 선그어주기. 빨간색으로다가
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
