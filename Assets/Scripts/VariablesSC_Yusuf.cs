using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ScriptableObjectplayer",menuName = "ScriptableObjectPlayer")]
public class VariablesSC : ScriptableObject
{
    public Player player=new Player();
    public Platform platform=new Platform();
    public HandsFromBack hands=new HandsFromBack();
    [System.Serializable]
    public class Player
    {
        public bool isAlive;
        public bool hasToy;
        public bool doubleJump;
        public bool isCrouch;
    }
    [System.Serializable]
    public class Platform
    {
        public float speed;
        public bool active;
    }
    [System.Serializable]

    public class HandsFromBack
    {
        public float HandsSpeed;
    }
   

}
