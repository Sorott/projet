using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PressKeyOpenDoor : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject AnimeObject;
    public GameObject Reach;
    public AudioSource DoorOpenSound;
    public bool Action = false;

    void Start()
    {
        Instruction.SetActive(false);

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Reach")
        {
            Instruction.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false);
        Action = false;
    }


    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (Action == true)
            {
                Instruction.SetActive(false);
                var animator = AnimeObject.GetComponent<Animator>();
                animator.SetBool("DoorOpen", !animator.GetBool("DoorOpen"));
                DoorOpenSound.Play();
                Action = false;
            }
        }

    }
}


