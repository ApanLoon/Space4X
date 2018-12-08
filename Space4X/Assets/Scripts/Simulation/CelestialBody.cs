using System.Collections.Generic;
using Space4X.Controllers;
using UnityEngine;

namespace Space4X.Simulation
{
    [System.Serializable]
    public class CelestialBody
    {
        public string Name;

        /// <summary>
        /// Semi-major axis in au
        /// </summary>
        public float a;

        /// <summary>
        /// Eccentricity
        /// </summary>
        public float e;

        /// <summary>
        /// Inclination in radians
        /// </summary>
        public float I;

        /// <summary>
        /// Mean longitude in radians
        /// </summary>
        public float L;

        /// <summary>
        /// Longitude of perihelion in radians
        /// </summary>
        public float LonPerihelion;

        /// <summary>
        /// Longitude of ascending node in radians
        /// </summary>
        public float lonAscendingNode;

        public float b;
        public float c;
        public float s;
        public float f;

        public List<CelestialBody> Orbiters = new List<CelestialBody>();

        /// <summary>
        /// https://ssd.jpl.nasa.gov/txt/aprx_pos_planets.pdf
        /// https://space.stackexchange.com/questions/8911/determining-orbital-position-at-a-future-point-in-time
        /// </summary>
        public Vector3 Position
        {
            get
            {
                if (Mathf.Abs(a) < 0.001f)
                {
                    return Vector3.zero;
                }

                float T = TimeController.Instance.CurrentTime / 1000000; //TODO: Is it ok to reference the TimeController from the model?

                // Argument of perihelion:
                float w = LonPerihelion - lonAscendingNode;

                // Mean anomaly:
                float M = L - LonPerihelion + b * T * T + c * Mathf.Cos(f * T) + s * Mathf.Sin(f * T);

                // Estimate eccentric anomaly:
                float E = M;
                float dE;
                do
                {
                    dE = (E - e * Mathf.Sin(E) - M) / (1 - e * Mathf.Cos(E));
                    E -= dE;
                } while (Mathf.Abs(dE) > 1e-4); //1e-6

                // Get polar coordinates:
                float P = a * (Mathf.Cos(E) - e);
                float Q = a * Mathf.Sin(E) * Mathf.Sqrt(1f - Mathf.Pow(e, 2));

                Vector3 pos = new Vector3();

                // Rotate by argument of periapsis:
                pos.x = Mathf.Cos(w) * P - Mathf.Sin(w) * Q;
                pos.y = Mathf.Sin(w) * P + Mathf.Cos(w) * Q;

                // Rotate by inclination:
                pos.z = Mathf.Sin(I) * pos.x;
                pos.x = Mathf.Cos(I) * pos.x;

                // Rotate by longitude of ascending node:
                float xtemp = pos.x;
                pos.x = Mathf.Cos(lonAscendingNode) * xtemp - Mathf.Sin(lonAscendingNode) * pos.y;
                pos.y = Mathf.Sin(lonAscendingNode) * xtemp + Mathf.Cos(lonAscendingNode) * pos.y;
                return pos;



                /*
                float L = this.L + Ldot * t
                           + b * Mathf.Pow(t, 2)
                           + c * Mathf.Cos(f * t)
                           + s * Mathf.Sin(f * t);

                float M = L - LonPerihelion;
                float w = LonPerihelion - lonAscendingNode;

                // Estimate eccentric anomaly:
                float E = M;
                //float dE;
                //do
                //{
                //    dE = (E - e * Mathf.Sin(E) - M) / (1 - e * Mathf.Cos(E));
                //    E -= dE;
                //} while (Mathf.Abs(dE) > 1e-6);

                // Get polar coordinates:
                float P = a * (Mathf.Cos(E) - e);
                float Q = a * Mathf.Sin(E) * Mathf.Sqrt(1f - Mathf.Pow(e, 2));

                Vector3 pos = new Vector3();

                // Rotate by argument of periapsis:
                pos.x = Mathf.Cos(w) * P - Mathf.Sin(w) * Q;
                pos.y = Mathf.Sin(w) * P + Mathf.Cos(w) * Q;

                // Rotate by inclination:
                pos.z = Mathf.Sin(I) * pos.x;
                pos.x = Mathf.Cos(I) * pos.x;

                // Rotate by longitude of ascending node:
                float xtemp = pos.x;
                pos.x = Mathf.Cos(lonAscendingNode) * xtemp - Mathf.Sin(lonAscendingNode) * pos.y;
                pos.y = Mathf.Sin(lonAscendingNode) * xtemp + Mathf.Cos(lonAscendingNode) * pos.y;
                return pos;
                */
            }
        }
    }
}
