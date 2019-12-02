// this script shamelessly stolen from http://guidohenkel.com/ (will be customised later)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


public class particleManager : MonoBehaviour
{
    public int zOffset;
    public int MaxStars = 100;
    public float StarSize = 0.1f;
    public float StarSizeRange = 0.5f;
    public float FieldWidth = 20f;
    public float FieldHeight = 25f;

    float xOffset;
    float yOffset;

    ParticleSystem Particles;
    ParticleSystem.Particle[] Stars;

    Transform camera;

    void Awake()
    {
        camera = GameObject.Find("Camera").transform;
        Stars = new ParticleSystem.Particle[MaxStars];
        Particles = GetComponent<ParticleSystem>();

        Assert.IsNotNull(Particles, "Particle system missing from object!");

        xOffset = FieldWidth * 0.5f;                                                         // Offset the coordinates to distribute the spread
        yOffset = FieldHeight * 0.5f;                                                        // around the object's center

        for (int i = 0; i < MaxStars; i++)
        {
            float randSize = Random.Range(1f - StarSizeRange, StarSizeRange + 1f);           // Randomize star size within parameters

            Stars[i].position = GetRandomInRectangle(FieldWidth, FieldHeight) + transform.position + new Vector3(0, 0 , zOffset);
            Stars[i].startSize = StarSize * randSize;
        }
        Particles.SetParticles(Stars, Stars.Length);                                        // Write data to the particle system
        Particles.Simulate(1);
    }

    void Update()
    {
        for (int i = 0; i < MaxStars; i++)
        {
            Vector3 pos = Stars[i].position + transform.position;

            if (pos.x < (camera.position.x - xOffset))
            {
                pos.x += FieldWidth;
            }
            else if (pos.x > (camera.position.x + xOffset))
            {
                pos.x -= FieldWidth;
            }

            if (pos.y < (camera.position.y - yOffset))
            {
                pos.y += FieldHeight;
            }
            else if (pos.y > (camera.position.y + yOffset))
            {
                pos.y -= FieldHeight;
            }

            Stars[i].position = pos - transform.position;
        }
        Particles.SetParticles(Stars, Stars.Length);

    }


    Vector3 GetRandomInRectangle(float width, float height)
    {
        float x = Random.Range(0, width);
        float y = Random.Range(0, height);
        return new Vector3(x - xOffset, y - yOffset, 0);
    }
}