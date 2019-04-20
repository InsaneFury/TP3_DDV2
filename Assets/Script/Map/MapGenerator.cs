using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class MapGenerator : MonoBehaviour
{
    //Types of prefabs
    List<GameObject> typesOfTerrain;
    //Total prefabs in map
    List<GameObject> map;
    //Aux object array to get prefabs from the res folder
    Object[] ob;

    [Header("MapSettings")]
    //Size of map
    public int xSize = 20;
    public int zSize = 20;

    //Size of tile
    public int tileX;
    public int tileY;

    //Total GameObjects to spawn
    int totalPlanes = 0;

    void Start() 
    {
        totalPlanes = xSize * zSize;
        typesOfTerrain = new List<GameObject>();
        map = new List<GameObject>();

        //Loading all the types of terrain in the platforms folder to a Object array
        ob = Resources.LoadAll("Prefab/platforms", typeof(Object));

        //Adding all the terrains to a list
        foreach (GameObject go in ob) 
        {
            go.transform.position = new Vector3(0, 0, 0);
            typesOfTerrain.Add((GameObject)go);
        }

        //Adding all the terrains randomly to a map list all with pos 0,0,0. And setActive(false)
        for (int t = 0; t < totalPlanes; t++) 
        {
            if (t == 0) //This spawn 100% a clean platform in the 0,0,0 position to keep the player safe of overlapping
            {
                //Here in the first position of the list you can add a started platform for the player if u want
                map.Add(Instantiate(typesOfTerrain[0], typesOfTerrain[0].transform.position, Quaternion.identity));
            }
            //Then add random stuff to the map
            else 
            {
                int randPrefab = (int)(Random.Range(1f, typesOfTerrain.Count));
                map.Add(Instantiate(typesOfTerrain[randPrefab], typesOfTerrain[randPrefab].transform.position, Quaternion.identity));
                map[t].SetActive(false);
            }
            //Make child of map generator just to by more cleany
            map[t].transform.parent = transform;
        }

        //Creating the map
        CreateMap();
    }


    void CreateMap() 
    {
        //Count its used for in the list to spawn any terrain on the list using total of terrains
        int count = 0;
        for (int i = 0; i <= zSize - 1; i++) 
        {
            for (int j = 0; j <= xSize - 1; j++) 
            {
                //Saving and moving to next position of the next terrain to spawn
                typesOfTerrain[0].transform.position = new Vector3(j * tileX, 0, i * tileY);

                //Assign to the actual map to spawn the last position of the last terrain instantiated
                //And then set active
                map[count].transform.position = typesOfTerrain[0].transform.position;
                map[count].SetActive(true);
                count++;
            }
        }
    }
}
