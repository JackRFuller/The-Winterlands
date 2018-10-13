using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHandler : Interactable
{
    [SerializeField]
    protected Resource resource;
    public Resource Resource
    {
        get
        {
            return resource;
        }
    }

    protected override void Start()
    {
        base.Start();
        SetTag();
    }

    private void SetTag()
    {
        this.gameObject.tag = "Resource";
    }

}
