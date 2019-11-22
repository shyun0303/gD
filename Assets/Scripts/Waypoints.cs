
using UnityEngine;

public class Waypoints : MonoBehaviour { 
    public static Transform[] points; // waypoints로 묶은 waypoint의 배열 

void Awake() {
        points = new Transform[transform.childCount]; //points에 waypoints 의 자식들 waypoint들을 찾아 넣는다.
        for (int i = 0; i < points.Length; i++) { //points의 길이 만큼 points[i]에 waypoints[i]값을 넣는다.
            points[i] = transform.GetChild(i);
        }
}

}
