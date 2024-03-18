using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTPSController : MonoBehaviour
{


    public Camera cam;

//public UnityEvent oninteractioninput;
    private InputData input;
    private CharacterAnimBasedMovement characterMovement;

    public bool oninteractionZone{get; set; }
    
    
    // Start is called before the first frame update
    void Start()
    {
        characterMovement = GetComponent<CharacterAnimBasedMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get input from player
        input.getInput();
        // Move the character
        characterMovement.moveCharacter(input.hMovement,
            input.vMovement, cam, input.jump, input.dash);
    }
}
