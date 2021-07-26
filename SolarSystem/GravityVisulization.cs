using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityVisulization : MonoBehaviour
{
    public Transform[] planets;
    public Transform targetPlanet;
    public float[] distancePlanet;
    float[] planetMass;
    float gravityRadius;
    Vector3 originPos;
    Vector3 maxDownPos;

    void Start()
    {
        originPos = transform.position;
        planets = new Transform[9];
        distancePlanet = new float[planets.Length];
        planetMass = new float[9] { 0.1f, 0.1f, 0.15f, 0.2f, 0.15f, 0.4f, 0.3f, 0.1f, 0.1f }; 
        FindPlanet();
    }

    void Update()
    {   
        SelectTargetPlanet();
        VisibleGravity();
    }

    void FindPlanet()
    {
        GameObject planet = GameObject.Find("SolarSystem");

        for (int i = 0; i < planets.Length; i++)
        {
            planets[i] = planet.transform.GetChild(i).transform;
        }
    }

    void SelectTargetPlanet()
    {
        float shortestDistance = 0;

        for (int i = 0; i < planets.Length; i++)
        {
            Vector3 planetDirect = planets[i].position - transform.position;
            distancePlanet[i] = planetDirect.magnitude;

            shortestDistance = Mathf.Min(distancePlanet);

            if (distancePlanet[i] == shortestDistance)
            {
                targetPlanet = planets[i];
                gravityRadius = planetMass[i];
            }
        }
    }

    void VisibleGravity()
    {
        Vector3 targetGravity = targetPlanet.position - transform.position;
        float distance = targetGravity.magnitude;
        float gravityPower = gravityRadius - distance;
        
        maxDownPos = new Vector3(originPos.x, originPos.y - Mathf.Abs(gravityPower), originPos.z);

        if (distance < gravityRadius)
        {
            transform.position = Vector3.Lerp(transform.position, maxDownPos, 0.2f);
        }
        else if (distance > gravityRadius)
        {
            transform.position = Vector3.Lerp(transform.position, originPos, 0.2f);
        }
    }
}
