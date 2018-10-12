using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : Entity
{
    [SerializeField]
    private InteractableData interactableData;

    [Header("Icon")]
    [SerializeField]
    private GameObject iconObject;
    [SerializeField]
    private Transform iconTransform;

    private void Start()
    {
        this.gameObject.tag = "Interactable";

        TurnOffIcon();
    }

    private void Update()
    {
        IconLookAtCamera();
    }

    public void PlayerInDistanceToInteract()
    {
        TurnOnIcon();
        IconLookAtCamera();
    }

    public void PlayerOutOfDistanceToInteract()
    {
        TurnOffIcon();
    }

    private void TurnOnIcon()
    {
        iconObject.SetActive(true);
    }

    private void TurnOffIcon()
    {
        iconObject.SetActive(false);
    }

    private void IconLookAtCamera()
    {
        iconTransform.LookAt(Camera.main.transform);
    }


}
