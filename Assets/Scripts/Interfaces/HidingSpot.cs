using UnityEngine;

public interface HidingSpot
{
    public Vector3 getPosition();

    public float getDistanceFromPosition(Vector3 position);
    public float getPositionX();
}