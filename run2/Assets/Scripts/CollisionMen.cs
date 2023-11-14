using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Leopotam.EcsLite;
using Unity.VisualScripting;
using UnityEngine;

namespace Client
{
    public class CollisionMen  : MonoBehaviour
{
    public GameObject menuPause;
    public GameObject play;
    public GameObject ESC;
    private AudioSource source;
    private EcsWorld world;
    private void Awake()
    {
        source =gameObject.GetComponent<AudioSource>();
    }
    public void GetWorldCoin(EcsWorld world)
    {
        this.world=world;
    } 
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            source.Play();
            Destroy(other.gameObject);
            world.GetPool<GetCoin>().Add(world.NewEntity());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Jump"))
        {
            world.GetPool<Jump>().Add(world.NewEntity());
        }
        if(other.gameObject.CompareTag("SpeedUp"))
        {
            world.GetPool<SpeedUp>().Add(world.NewEntity());
        }
        if(other.gameObject.CompareTag("OpenDoor"))
        {
            world.GetPool<OpenDoor>().Add(world.NewEntity());
        }
        if(other.gameObject.CompareTag("Dead"))
        {
            menuPause.SetActive(true);
            play.SetActive(false);
            ESC.SetActive(false);
        }
    }

}

}
