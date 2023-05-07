using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using static UnityEngine.GraphicsBuffer;

/// <summary>
/// this script protect against player getting stuck in space
/// of less then 100 tails
/// </summary>
public class stuck_checker : MonoBehaviour
{
    [SerializeField] Tilemap tilemap = null;
    //[SerializeField] TilemapCaveGenerator generator = null;
    [SerializeField] GameObject cave_generator = null;
    [SerializeField] GameObject player = null;
    // Start is called before the first frame update

    bool infunction = false;
    void Start()
    {
        //tilemap.WorldToCell(transform.position);
    }

    private void run_generating()
    {
        int count = 1000;
        int i = 0;
        int j = 1;
        Debug.Log("e_debug: start function!!!!!!!!!!!");
        Vector3Int start = tilemap.WorldToCell(player.transform.position);
        Vector3Int target = new Vector3Int(0,0,0);
        TilemapGraph graph = player.GetComponent<TargetMover>().GetTilemapGraph();
        Debug.Log("e_debug start: " + start.ToString());
        Debug.Log("e_debug target: " + target.ToString());
        //Debug.Log("e_debug graph: " + player.GetComponent<TargetMover>());

        for(j = 2;j<98;j++)
        {
            target = new Vector3Int(2, j, 0);
            Debug.Log("e_debug target: " + target.ToString());
            List<Vector3Int> shortestPath = BFS.GetPath(graph, start, target, 1000);
            Debug.Log("e_debug count: " + shortestPath.Count.ToString());
            if (shortestPath.Count > 2)
            {
                return;//
            }
        }
        for (j = 2; j < 98; j++)
        {
            target = new Vector3Int(98, j, 0);
            Debug.Log("e_debug target: " + target.ToString());
            List<Vector3Int> shortestPath = BFS.GetPath(graph, start, target, 1000);
            Debug.Log("e_debug count: " + shortestPath.Count.ToString());
            if (shortestPath.Count > 2)
            {
                return;//
            }
        }
        for (j = 2; j < 98; j++)
        {
            target = new Vector3Int(j, 2, 0);
            Debug.Log("e_debug target: " + target.ToString());
            List<Vector3Int> shortestPath = BFS.GetPath(graph, start, target, 1000);
            Debug.Log("e_debug count: " + shortestPath.Count.ToString());
            if (shortestPath.Count > 2)
            {
                return;//
            }
        }
        for (j = 2; j < 98; j++)
        {
            target = new Vector3Int(j, 98, 0);
            Debug.Log("e_debug target: " + target.ToString());
            List<Vector3Int> shortestPath = BFS.GetPath(graph, start, target, 1000);
            Debug.Log("e_debug count: " + shortestPath.Count.ToString());
            if (shortestPath.Count > 2)
            {
                return;//
            }
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update()
    {
        if(!infunction) {
            infunction = true;
            run_generating();
                
        }
    }
}
