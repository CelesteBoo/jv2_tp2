using UnityEngine;

public interface Hurtable
{
    public void hurt(int damage);

    public bool isAlive();

    public Teams getTeam();

    public Vector3 getPosition();
}