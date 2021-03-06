using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Material[] Materials;

    public Interactable Interactable;

    public GameObject[] GhostTurret;

    [SerializeField] bool isEmpty = true;

    // Start is called before the first frame update
    void Start()
    {
        if(Interactable != null)
        {
            Interactable.EvtInteracted.AddListener(Interact);
        }
    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FixedUpdate()
    {
        this.gameObject.GetComponent<Renderer>().material = Materials[0];
        GhostTurret[0].SetActive(false);
    }

    public void Interact()
    {
        //spawn ghost tower
        this.gameObject.GetComponent<Renderer>().material = Materials[1];
        GhostTurret[0].SetActive(true);
    }
}
