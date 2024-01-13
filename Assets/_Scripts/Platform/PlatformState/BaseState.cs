using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    public abstract void MovePlatformUp(Transform trans,float duration);
    public abstract void MovePlatformRight(Transform trans, float duration);
}
