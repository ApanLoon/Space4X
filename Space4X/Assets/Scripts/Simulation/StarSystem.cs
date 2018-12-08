using System.Collections.Generic;
using UnityEngine;

namespace Space4X.Simulation
{
    [System.Serializable]
    public class StarSystem
    {
        public string Name { get; set; }
        public Vector3 Position { get; set; }

        public List<CelestialBody> Bodies = new List<CelestialBody>();

        /// <summary>
        /// https://ssd.jpl.nasa.gov/txt/p_elem_t2.txt
        /// </summary>
        public StarSystem()
        {
            Star s = new Star();
            s.Name = "Sol";
            Bodies.Add(s);

            Planet p;
            p = new Planet();
            p.Name = "Earth";
            p.a = 1.00000018f;
            p.e = 0.01673163f;
            p.I = -0.00054346f * Mathf.Deg2Rad;
            p.LonPerihelion = 102.93005885f * Mathf.Deg2Rad;
            p.lonAscendingNode = -5.11260389f * Mathf.Deg2Rad;
            p.L = 100.46691572f * Mathf.Deg2Rad;
            p.b = 0f;
            p.c = 0f;
            p.s = 0f;
            p.f = 0f;
            s.Orbiters.Add(p);

            p = new Planet();
            p.Name = "Saturn";
            p.a = 9.54149883f;
            p.e = 0.05550825f;
            p.I = 2.49424102f * Mathf.Deg2Rad;
            p.LonPerihelion = 92.86136063f * Mathf.Deg2Rad;
            p.lonAscendingNode = 113.63998702f * Mathf.Deg2Rad;
            p.L = 34.33479152f * Mathf.Deg2Rad;
            p.b = 0.00025899f;
            p.c = -0.13434469f;
            p.s = 0.87320147f;
            p.f = 38.35125000f;
            s.Orbiters.Add(p);

        }

    }
}
