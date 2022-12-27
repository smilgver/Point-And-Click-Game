using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Camera camera;
    [SerializeField] Canvas canvas;
    [SerializeField] DialogueManager dialogueManager;

    Vector3 mousePosition;
    Vector3 cameraPosition1 = new Vector3(-24, 40, -25);
    Vector3 cameraPosition2 = new Vector3(-24, 40, -71);
    Vector3 cameraPosition3 = new Vector3(-24, 40, -115);
    Vector3 cameraPosition4a = new Vector3(18.5f, 40, -115);
    Vector3 cameraPosition4b = new Vector3(-68.75f, 40, -115);

    string input;



    private void Awake()
    {
        camera = Camera.main;
        navMeshAgent = GetComponent<NavMeshAgent>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<Canvas>();
        dialogueManager = GameObject.Find("DialogueManager").GetComponentInChildren<DialogueManager>();
    }
    void Start()
    {
        mousePosition = transform.position;

    }

    void Update()
    {
        navMeshAgent.destination = mousePosition;

        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() && !dialogueManager.PlayerInConversation/*!canvas.isActiveAndEnabled*/)
        {
            MovePlayer();
        }
        input = Input.inputString; // For debugging purposes... transitions camera positions 1-5 from keyboard input.
        MoveCamera(input);
    }
    void MovePlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            mousePosition = hit.point;
        }
    }
    void MoveCamera(string input)
    {

        switch (input)
        {
            case "1":
                {
                    camera.transform.DOMove(cameraPosition1, 1);
                    break;
                }
            case "2":
                {
                    camera.transform.DOMove(cameraPosition2, 1);
                    break;
                }
            case "3":
                {
                    camera.transform.DOMove(cameraPosition3, 1);
                    break;
                }
            case "4":
                {
                    camera.transform.DOMove(cameraPosition4a, 1);
                    break;
                }
            case "5":
                {
                    camera.transform.DOMove(cameraPosition4b, 1);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}