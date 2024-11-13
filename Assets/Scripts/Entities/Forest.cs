using UnityEngine;

public class Forest : MonoBehaviour, HidingSpot
{
    public float getDistanceFromPosition(Vector3 position)
    {
        Vector3 distance = gameObject.transform.position - position;
        return distance.magnitude;
    }

    public Vector3 getPosition()
    {
        return gameObject.transform.position;
    }

    public float getPositionX()
    {
        return gameObject.transform.position.x;
    }
}
