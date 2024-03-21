using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public Animator currentMoveAnim;
    public AudioSource playerAudio, footstepAudioSource;
    public AudioClip idle, jump, doubleJump, fall, crouch, crouchRun, die;
    public AudioClip grassFootstepSound, rockFootstepSound, groundFootstepSound;

    private int previousState = -1;
    private bool isDead = false;
    private bool isRunning = false;

    private void Update()
    {
        int currentState = currentMoveAnim.GetInteger("state");

        if (currentMoveAnim.GetBool("death") && !isDead)
        {
            playerAudio.clip = die;
            playerAudio.Play();
            isDead = true;
        }
        else if (!currentMoveAnim.GetBool("death"))
        {
            isDead = false;

            if (currentState != previousState)
            {
                playerAudio.Stop();

                switch (currentState)
                {
                    case 0:
                        playerAudio.clip = idle;
                        footstepAudioSource.Stop();

                        break;
                    case 2:
                        playerAudio.clip = jump;
                        footstepAudioSource.Stop();

                        break;
                    case 3:
                        playerAudio.clip = fall;
                        footstepAudioSource.Stop();

                        break;
                    case 4:
                        playerAudio.clip = doubleJump;
                        footstepAudioSource.Stop();

                        break;
                    case 5:
                        playerAudio.clip = crouch;
                        footstepAudioSource.Stop();

                        break;
                    case 6:
                        playerAudio.clip = crouchRun;
                        break;
                    case 1:
                        footstepAudioSource.Play();
                        break;
                    default:
                        footstepAudioSource.Stop();
                        break;
                }

                playerAudio.Play();
                previousState = currentState;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("GrassGround"))
        {
            footstepAudioSource.clip = grassFootstepSound;
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("RockGround") || collision.gameObject.layer == LayerMask.NameToLayer("rock"))
        {
            footstepAudioSource.clip = rockFootstepSound;
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            footstepAudioSource.clip = groundFootstepSound;
        }
    }
}
