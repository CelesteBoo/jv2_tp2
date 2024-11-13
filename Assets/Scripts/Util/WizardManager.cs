using System.Collections.Generic;
using UnityEngine;

public class WizardManager : MonoBehaviour
{
    [SerializeField] Tower[] team1Towers;
    [SerializeField] Tower[] team2Towers;
    [SerializeField] Forest[] forests;

    public Tower getRandomEnemyTower(Teams team)
    {
        Tower[] towerList;
        if (team == Teams.TEAM1)
        {
            towerList = team2Towers;
        }
        else
        {
            towerList = team1Towers;
        }
        List<Tower> aliveTowerList = new List<Tower>();
        for (int i = 0; i < towerList.Length; i++)
        {
            if (towerList[i] != null && towerList[i].isAlive())
            {
                aliveTowerList.Add(towerList[i]);
            }
        }
        int index = Random.Range(0, aliveTowerList.Count);
        return aliveTowerList[index];
    }

    public Tower getRandomAllyTower(Teams team)
    {
        if (team == Teams.TEAM1)
        {
            return getRandomEnemyTower(Teams.TEAM2);
        }
        return getRandomEnemyTower(Teams.TEAM1);
    }

    public HidingSpot getClosestHidingSpot(Teams team, Vector3 position)
    {
        HidingSpot closestHidingSpot = forests[1];
        float closestDistance = closestHidingSpot.getDistanceFromPosition(position);

        //Pour que le code marche pour les deux équipes
        float directionToLookFor = -1;
        Tower[] towerList = team1Towers;
        if (team == Teams.TEAM2)
        {
            directionToLookFor = 1;
            towerList = team2Towers;
        }

        for (int i = 1; i < forests.Length; i++)
        {
            float newDistance = forests[i].getDistanceFromPosition(position) * directionToLookFor;
            float distanceX = (position.x - forests[i].getPositionX()) * directionToLookFor;
            if (forests[i] != null && newDistance < closestDistance && distanceX > 0)
            {
                closestHidingSpot = forests[i];
                closestDistance = newDistance;
            }
        }

        for (int i = 0; i < towerList.Length; i++)
        {
            float newDistance = towerList[i].getDistanceFromPosition(position) * directionToLookFor;
            float distanceX = (position.x - towerList[i].getPositionX()) * directionToLookFor;
            if (towerList[i] != null && newDistance < closestDistance && distanceX > 0)
            {
                closestHidingSpot = towerList[i];
                closestDistance = newDistance;
            }
        }
        return closestHidingSpot;
    }
}
