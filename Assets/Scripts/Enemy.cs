
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f; //구체의 이동속도
    private Transform target; // 이동할 타겟
    private int wavapointIndex = 0; //적출현 레벨
    public static int  Hp = 10;

    void Start()
    {
        target = Waypoints.points[0]; // 처음 이동할 타겟은 WayPoints의 0번째 요소 즉 waypoint(1)
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position; // dir 은 타겟의 위치 - 에너미의 위치
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); //이동

        if (Vector3.Distance(transform.position, target.position) <= 0.2f) {
            GetNextWaypoint();  //enemy와 타겟의 거리가 0.2 이하가 되면 다음 포인트로 갈수 있는 함수 호출
        }
    }
    void GetNextWaypoint() { 
        wavapointIndex++; //적출현 레벨이 올라가고
        if(wavapointIndex >= Waypoints.points.Length -1) //적출현 레벨이 waypoint 배열의 크기보다 커지거나 같으면 객체 파괴
        {
            Destroy(gameObject);
        }
        target = Waypoints.points[wavapointIndex]; //그러면서 이동할 타겟은 index가 증가된 waypoint(2)가 되는 것. 즉 다음 타겟으로 바뀐다.
    }
}
