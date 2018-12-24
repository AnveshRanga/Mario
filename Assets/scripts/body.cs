using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class body :MonoBehaviour
{
    public abstract void Walk(int walk);

    public abstract void Turn(int turn);

    public abstract void Jump();

    public abstract void Attack();
}
