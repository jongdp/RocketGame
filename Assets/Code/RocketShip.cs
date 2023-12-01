using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control the player on screen
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class RocketShip : MonoBehaviour
{
    /// <summary>
    /// Prefab for the missiles we will shoot
    /// </summary>
    public GameObject MissilePrefab;

    /// <summary>
    /// Field that stores the rigid body of the player
    /// </summary>
    private Rigidbody2D rigidBodyPlayer;

    /// <summary>
    /// The time required to cool down per shot
    /// </summary>
    private float CoolDown = 0.1f;

    /// <summary>
    /// The minimum time until the next shot
    /// </summary>
    private float NextShot;

    public AudioClip missileSound;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        rigidBodyPlayer = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Manoeuvre();
        MaybeFire();
    }

    /// <summary>
    /// Accelerates the player
    /// </summary>
    void Manoeuvre()
    {
        var direction = new Vector2(Input.GetAxis("Horizontal"), 0);
        rigidBodyPlayer.AddForce(direction * 10);
    }

    /// <summary>
    /// Checks to see if the user has fired a missile
    /// </summary>
    void MaybeFire()
    {
        if (Input.GetAxis("Fire1") == 1 && Time.time >= NextShot)
        {
            Fire();
            NextShot = Time.time + CoolDown;
        }
    }

    /// <summary>
    /// Fire one missile in front of the rocket ship
    /// </summary>
    private void Fire()
    {
        var missile = Instantiate(MissilePrefab, transform.localPosition, Quaternion.identity);
        missile.transform.localPosition += transform.up;
        missile.GetComponent<Rigidbody2D>().velocity = 10 * transform.up;
        audioSource.PlayOneShot(missileSound);
    }

    /// <summary>
    /// If the character leaves the screen then the game is over
    /// </summary>
    private void OnBecameInvisible()
    {
        var pos = transform.position;
        pos.x = pos.x * -1;
        transform.position = pos;
    }
}
