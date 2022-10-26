using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPC : MonoBehaviour
{
    private float distPlayer;
    public GameObject player;
    public GameObject ePrefab;
    private GameObject eButton;
    private bool hasButton = false;
    private DialogueRunner DR;
    // Start is called before the first frame update
    void Start()
    {
        DR = FindObjectOfType<Yarn.Unity.DialogueRunner>();
    }

    // Update is called once per frame
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
        }

        print(distPlayer);
    }
}
