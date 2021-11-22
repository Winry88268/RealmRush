using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f,5f)] float speed = 1f;

    List<Node> path = new List<Node>();
    Enemy enemy;
    GridManager gridManager;
    Pathfinder pathfinder;
    
    void Awake() 
    {
        this.enemy = this.GetComponent<Enemy>();
        this.gridManager = FindObjectOfType<GridManager>();
        this.pathfinder = FindObjectOfType<Pathfinder>();
    }
    
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath()
    {
        this.path.Clear();

        this.path = this.pathfinder.GetNewPath();
    }

    void ReturnToStart()
    {
        this.transform.position = this.gridManager.GetPositionFromCoordinates(this.pathfinder.StartCoords);
    }

    void FinishPath()
    {
        this.enemy.StealGold();
        this.gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        for(int i = 0; i < this.path.Count; i++)
        {
            Vector3 startPos = this.transform.position;
            Vector3 endPos = this.gridManager.GetPositionFromCoordinates(this.path[i].coordinates);
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
