using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Item : MonoBehaviour
{
    
    private float distPlayer;
    public GameObject player;
    public GameObject ePrefab;
    private GameObject eButton;
    private bool hasButton = false;
    private DialogueRunner DR;
    private SpriteRenderer SR;
    private InMemoryVariableStorage VS;

    // Start is called before the first frame update
    void Start()
    {
        VS = FindObjectOfType<Yarn.Unity.InMemoryVariableStorage>();
        DR = FindObjectOfType<Yarn.Unity.DialogueRunner>();
    }

    void Update()
    {
    
        distPlayer = Vector3.Distance(player.transform.position, this.transform.position);
        if(distPlayer < 3 && hasButton == false){
            eButton = Instantiate(ePrefab, new Vector3(this.transform.position.x, this.transform.position.y + 3, this.transform.position.z), Quaternion.identity);
            hasButton = true;
        }

        if(hasButton == true && distPlayer >= 3){
            Destroy(eButton);
            hasButton = false;
            DR.Stop();
        }

        if(hasButton == true && Input.GetKeyDown(KeyCode.E)){
            DR.StartDialogue(this.name);
            print(this.name);
        }
    }

    [YarnCommand("pick_up")]
    public void pickUp(string variableName){
        VS.SetValue(variableName, true);
        Destroy(eButton);
        hasButton = false;
        gameObject.SetActive(false);
    }

    [YarnCommand("delete")]
    public void delete(string objectName){
        Destroy(eButton);
        hasButton = false;
        GameObject.Find(objectName).SetActive(false);
    }
}
