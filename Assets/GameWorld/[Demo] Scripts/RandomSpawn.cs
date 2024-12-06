using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public List<GameObject> listObj;
    List<Vector3> spawnPositions = new List<Vector3>();
    public float minDistanceBetweenObjects = 1.5f; // Minimum distance between spawned objects
    public float Radius = 1;
    public int playerChance = 10;
    public int max = 101;
    int x;
    int artifactIndex;
    void Start(){
        for(x = 0; x<30; x++){
            if (Random.Range(0,max) < playerChance){
                artifactIndex = 2;
            } else {
                if(Random.Range(0,11) < 7){
                    artifactIndex = 0;
                } else {
                    artifactIndex = 1;
                }
            }
            spawning();
        }
    }
    public void spawning()
    {
        Vector3 randomPos;
        int attempts = 0;
        bool positionValid = false;

        do
        {
            Vector2 randomPos2D = Random.insideUnitCircle * Radius;
            randomPos = new Vector3(randomPos2D.x, randomPos2D.y, 0) + transform.position;
            positionValid = true;

            foreach (Vector3 pos in spawnPositions)
            {
                if (Vector3.Distance(pos, randomPos) < minDistanceBetweenObjects)
                {
                    positionValid = false;
                    break;
                }
            }

            attempts++;
            if (attempts > 100) // Safety check to avoid infinite loop
            {
                Debug.LogWarning("Could not find a valid spawn position");
                break;
            }
        } while (!positionValid);

        if (positionValid)
        {
            Instantiate(listObj[artifactIndex], randomPos, Quaternion.identity);
            spawnPositions.Add(randomPos);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
