using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : Entity
{    
    [Header("Icon")]
    [SerializeField]
    private GameObject iconObject;
    [SerializeField]
    private Transform iconTransform;

    protected virtual void Start()
    {
        TurnOffIcon();
    }

    public virtual void PlayerWithinDistanceToInteract()
    {
        TurnOnIcon();
        IconLookAtCamera();
    }

    public virtual void PlayerOutOfDistanceToInteract()
    {
        TurnOffIcon();
    }

    public virtual void Interact()
    {

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
        iconTransform.LookAt(2 * transform.position - Camera.main.transform.position);
    }


}
