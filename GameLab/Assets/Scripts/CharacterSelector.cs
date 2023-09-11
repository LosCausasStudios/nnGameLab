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
    private int indexA = 0;
    private int indexE = 0;
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
            indexA = SelectYourCharacter(characterSelector, charactersSelection, indexA);
        }
        else
        {
            indexE = SelectYourCharacter(enemySelector, enemiesSelection, indexE);
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
