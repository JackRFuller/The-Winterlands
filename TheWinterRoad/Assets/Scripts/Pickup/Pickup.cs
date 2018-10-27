using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Entity
{
    [SerializeField]
    private InventoryItem item;

    private Collider[] colliders;

    private PlayerView playerView;
    private bool moveToPlayer;
    private const float moveSpeed = 10;
    private const float distanceNeededToDespawn = 0.25f;

    private void Start()
    {
        colliders = GetComponents<Collider>();
    }

    private void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        if (!moveToPlayer)
            return;

        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }

        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerView.PlayerInteraction.PlayerCenterTransform.position, step);

        float dist = Vector3.Distance(transform.position, playerView.PlayerInteraction.PlayerCenterTransform.position);

        if(dist <= distanceNeededToDespawn)
        {
            playerView.PlayerInventory.AddItemToInventory(item);
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerView = other.GetComponent<PlayerView>();
            moveToPlayer = true;
        }
    }





}
