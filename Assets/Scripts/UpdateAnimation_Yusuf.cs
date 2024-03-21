using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private enum MovementState { idle, run, jump, fall, doubleJump, crouched,crouchedRun,};
    private Rigidbody2D momRig;
    private float dirX,dirY;
    private Animator anim;
    public VariablesSC change_global_variable;
    void Start()
    {
        momRig=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX=momRig.velocity.x;
        dirY = momRig.velocity.y;
        update_animation();        
    }
    private void update_animation()
    {
        MovementState state;
            if (change_global_variable.player.isCrouch)
            {
            if (dirX > 0.2f || dirX < -0.2f)
            {
                state = MovementState.crouchedRun;


            }
            else
            {
                state = MovementState.crouched;
            }
            }
            else
            {
                if (dirX > 0.2f || dirX < -0.2f)
                {
                    state = MovementState.run;
                }
                else
                {
                    state = MovementState.idle;
                }
                if (dirY > 0.5f && change_global_variable.player.doubleJump == false)
                {
                    state = MovementState.jump;

                }
                else if (change_global_variable.player.doubleJump)
                {
                    if (dirY > 0f)
                    {
                        state = MovementState.doubleJump;
                    }
                    else
                    {
                        state = MovementState.fall;
                    }
                }
                else if (dirY < -1.5f && change_global_variable.player.doubleJump == false)
                {
                    state = MovementState.fall;
                }
            }
            anim.SetInteger("state", (int)state);
        
    }
}
