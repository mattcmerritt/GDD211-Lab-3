using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField]
    protected float Speed;
    protected Vector3 Direction;

    protected abstract void Start();

    private void Update()
    {
        Move(Speed);
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }


    public virtual void Move(float speed)
    {
        transform.position += Direction * Speed * Time.deltaTime;
    }
}
