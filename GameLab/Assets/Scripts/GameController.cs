using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject menuItem1;
    public GameObject menuItem2;
    public GameObject menuItem3;
    private GameObject menuClone1;
    private GameObject menuClone2;
    private GameObject menuClone3;
    public Transform spawnPosition1;
    public Transform spawnPosition2;
    public Transform spawnPosition3;
    private bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && !spawned)
            SpawnMenu();
        if(Input.GetKeyDown(KeyCode.Z)){
            Destroy(menuClone1);
            Destroy(menuClone2);
            Destroy(menuClone3);
            spawned = false;
        }
    }

    void SpawnMenu(){
        spawned = true;
        menuClone1 = (GameObject)Instantiate(menuItem1, spawnPosition1.position, Quaternion.identity);
        menuClone2 = (GameObject)Instantiate(menuItem2, spawnPosition2.position, Quaternion.identity);
        menuClone3 = (GameObject)Instantiate(menuItem3, spawnPosition3.position, Quaternion.identity);
    }
}
