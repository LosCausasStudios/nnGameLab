using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] charactersSelection;
    public GameObject characterSelector;
    public int[] charactersHealth;
    public int[] charactersDamage;
    public GameObject[] enemiesSelection;
    public GameObject enemySelector;
    public int[] enemiesHealth;
    public int[] enemiesDamage;
    private bool isCharacterSelected = true;
    private bool isEnemySelected = false;
    private int indexA;
    private int indexE;
    void Start()
    {   
        charactersSelection = GameObject.FindGameObjectsWithTag("Ally"); 
        charactersHealth = new int [charactersSelection.Length];
        charactersDamage = new int [charactersSelection.Length];

        enemiesSelection = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesHealth = new int [enemiesSelection.Length];
        enemiesDamage = new int [enemiesSelection.Length];
        for(int i = 0; i < enemiesSelection.Length && i < charactersSelection.Length; i++){
            GameManager healthValueE = enemiesSelection[i].GetComponent<GameManager>();
            enemiesHealth[i] = healthValueE.healthE;  
            GameManager DamageValueE = enemiesSelection[i].GetComponent<GameManager>();
            enemiesDamage[i] = DamageValueE.damageE;

            GameManager healthValueA = enemiesSelection[i].GetComponent<GameManager>();    
            charactersHealth[i] = healthValueA.healthA;
            GameManager DamageValueA = enemiesSelection[i].GetComponent<GameManager>();
            charactersDamage[i] = DamageValueA.damageA;

        }
    }

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
            Combat(enemiesSelection, indexE, charactersDamage[indexA], enemiesHealth);
            isEnemySelected = !isEnemySelected;
            
            Combat(charactersSelection, 0, 0, charactersHealth);
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
    void Combat(GameObject[] selection, int index, int damage, int[] healthArray){
        if(selection == charactersSelection){
            for(int i = 0; i < charactersSelection.Length; i++){
                int rN = Random.Range(0,charactersSelection.Length);
                charactersHealth[rN] -= enemiesDamage[i];
                if(charactersHealth[rN] <= 0){              
                    Destroy(charactersSelection[rN]);
                    if(rN + 1 > charactersSelection.Length - 1){
                        System.Array.Resize(ref charactersSelection, charactersSelection.Length -1);
                    }
                    else{
                        charactersSelection[rN] = charactersSelection[rN+1];
                    }
                }
                Debug.Log("Recibio daño"+ (rN+1) + " " + charactersHealth[i]);
            }

        }
        else{
            healthArray[index] -= damage;
            if(healthArray[index] <= 0){ 
                Destroy(selection[index]);
                if(index + 1 > selection.Length - 1){
                    System.Array.Resize(ref selection, selection.Length -1);
                }
                else{
                    selection[index] = selection[index + 1];
                }
            }
            Debug.Log("Daño al enemigo: "+ index+1 +" " + healthArray[index]);
        }
    }
}
