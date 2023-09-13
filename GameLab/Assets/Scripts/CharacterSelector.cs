using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] charactersSelection;
    public GameObject characterSelector;
    public GameObject[] enemiesSelection;
    public GameObject enemySelector;
    private bool isCharacterSelected = true;
    private bool isEnemySelected = false;
    private int indexA;
    private int indexE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isCharacterSelected = !isCharacterSelected;
        }

        if (isCharacterSelected)
        {
            enemySelector.SetActive(false);
            indexA = SelectYourCharacter(characterSelector, charactersSelection, indexA);
        }
        else
        {
            enemySelector.SetActive(true);
            indexE = SelectYourCharacter(enemySelector, enemiesSelection, indexE);               
            isEnemySelected = !isEnemySelected;
        }
        if(isCharacterSelected && isEnemySelected){
            Debug.Log("El personaje " + indexA + " ha atacado al enemigo " + indexE);
            isEnemySelected = !isEnemySelected;
        }
    }
    public int SelectYourCharacter(GameObject selector, GameObject[] selectionArray, int index)
    {

        UnityEngine.Vector3 characterPosition = selectionArray[index].transform.position;
        selector.transform.position = new UnityEngine.Vector3(selector.transform.position.x, selector.transform.position.y, characterPosition.z);
        if(Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.DownArrow)){
            if(index < selectionArray.Length -1){
                index++ ;
            }
            else{
                index = 0;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.UpArrow)){
            if(index > 0){
                index--;
            }
            else{
                index = selectionArray.Length-1;
            }
        }
        return index;
    }
}
