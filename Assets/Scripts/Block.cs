using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // configs
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockParticlesVFX;

    [SerializeField] Sprite[] hitSprites;

    //cached references
    Level level;

    //state variables
    [SerializeField] int timesHit;

    private void Start()
    {
        InsantiateObjects();
        CountBreakableBlocks();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHealth = hitSprites.Length + 1;

        if (timesHit == maxHealth)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit-1;

        if (hitSprites[spriteIndex] != null)
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        else
            Debug.LogError("Block sprite is missing from array: " + gameObject.name);
    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            level.IncremementBlocks();
        }
    }

    private void InsantiateObjects()
    {
        level = FindObjectOfType<Level>();
    }

    public void DestroyBlock()
    {
        PlayBlockDestroySFX();
        CreateParticles();
        Destroy(this.gameObject);
        level.BlockDestroyed();
    }

    public void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.2f);
    }

    private void CreateParticles()
    {
        GameObject particles = Instantiate(blockParticlesVFX, transform.position, transform.rotation);
        Destroy(particles, 2f);
    }
}
