﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class doorKeyPad : MonoBehaviour {
    private RigidbodyFirstPersonController firstPersonController;
    public string currentPassword = "68";
    private string input = "";
    private bool onTrigger;
    private bool keypadScreen;
    public int level;
    bool needKeys;

    private void Start()
    {
        firstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
    }

    private void Update()
    {
        if (input.Equals(currentPassword))
        {
            Debug.Log("Password match!");
            keypadScreen = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            if(level == 3) {
                SceneManager.LoadScene("Winner");
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Inventory.inventory.lastLevelKeyCount == 2)
            {
                //firstPersonController = other.gameObject;
                needKeys = false;
                onTrigger = true;
            } else
            {
                needKeys = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            needKeys = false;
            onTrigger = false;
            keypadScreen = false;
            input = "";
        }
    }
    private void OnGUI()
    {
        if (needKeys)
        {
            GUI.Box(new Rect((Screen.width - 210) / 2, (Screen.height - 25) / 2, 210, 25), "Two keys needed to unlock keypad");
        }
        if (onTrigger)
        {
            GUI.Box(new Rect((Screen.width - 200)/2, (Screen.height-25)/2, 200, 25), "Press 'E' to open keypad");

            if (Input.GetKeyDown(KeyCode.E))
            {
                keypadScreen = true;
                onTrigger = false;
            }
        }

        if (keypadScreen)
        {
            firstPersonController.enabled = false;

            GUI.Box(new Rect(50, 400, 200, 25), "Press 'Q' to close keypad");

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Q to exit pressed");
                firstPersonController.enabled = true;
                //firstPersonController.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                keypadScreen = false;
            }


            GUI.Box(new Rect(0, 0, 320, 400), "");
            GUI.Box(new Rect(5, 5, 310, 25), input);

            if (input.Length > 2)
            {
                input = "";
            }
            if (GUI.Button(new Rect(5, 25, 50, 50), "1"))
            {
                input += "1";
            }

            if (GUI.Button(new Rect(110, 25, 50, 50), "2"))
            {
                input += "2";
            }

            if (GUI.Button(new Rect(215, 25, 50, 50), "3"))
            {
                input += "3";
            }

            if (GUI.Button(new Rect(5, 140, 50, 50), "4"))
            {
                input += "4";
            }

            if (GUI.Button(new Rect(110, 140, 50, 50), "5"))
            {
                input += "5";
            }

            if (GUI.Button(new Rect(215, 140, 50, 50), "6"))
            {
                input += "6";
            }

            if (GUI.Button(new Rect(5, 245, 50, 50), "7"))
            {
                input += "7";
            }

            if (GUI.Button(new Rect(110, 245, 50, 50), "8"))
            {
                input += "8";
            }

            if (GUI.Button(new Rect(215, 245, 50, 50), "9"))
            {
                input += "9";
            }

            if (GUI.Button(new Rect(110, 350, 50, 50), "0"))
            {
                input += "0";
            }


        }
    }
}
