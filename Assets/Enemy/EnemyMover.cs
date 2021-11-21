using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Tile> path = new List<Tile>();
    [SerializeField] [Range(0f,5f)] float speed = 1f;

    Enemy enemy;
    
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void Start() 
    {
        this.enemy = this.GetComponent<Enemy>();
    }

    void FindPath()
    {
        this.path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in parent.transform)
        {
            Tile waypoint = child.GetComponent<Tile>();

            if(waypoint!= null)
            {
                this.path.Add(waypoint);
            }
        }
    }

    void ReturnToStart()
    {
        this.transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        this.enemy.StealGold();
        this.gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        foreach(Tile waypoint in this.path)
        {
            Vector3 startPos = this.transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPercent = 0f;

            this.transform.LookAt(endPos);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * this.speed;
                this.transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return new WaitForEndOfFrame();
            }   
        }
        FinishPath();
    }
}
