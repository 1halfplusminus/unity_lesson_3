using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;

    Animator animator;
    public float jumpForce = 10.0f;

    public float gravityModifier = 1.0f;

    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;

    public AudioClip crashSound;

    private AudioSource audioSource;
    public bool isOnGround
    {
        get;
        private set;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        isOnGround = true;
        animator = GetComponent<Animator>();
        GetComponent<Hitable>().onHit.AddListener(DeathAnimation);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            audioSource.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
        if (enabled)
        {
            dirtParticle.Play();
        }
    }

    void DeathAnimation()
    {
        dirtParticle.Stop();
        playerRb.freezeRotation = true;
        animator.SetBool("Death_b", true);
        animator.SetInteger("DeathType_int", 1);
        audioSource.PlayOneShot(crashSound, 1.0f);
    }

}
