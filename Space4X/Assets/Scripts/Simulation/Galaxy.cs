using System.Collections.Generic;
using Space4X.Controllers;
using UnityEngine;

namespace Space4X.Simulation
{
    public enum GalaxyType
    {
        Spiral,
        Elliptical,
        Irregular
    }

    public enum GalaxySize
    {
        Small,
        Medium,
        Large,
        Enormous
    }

    [System.Serializable]
    public class Galaxy
    {
        public string Name { get; set; }
        public GalaxyType Type { get; protected set; }
        public GalaxySize Size { get; protected set; } 
        public List<StarSystem> StarSystems = new List<StarSystem>();

        public Galaxy(GalaxyType type, GalaxySize size)
        {
            Type = type;
            Size = size;

            GenerateStarSystems();

            TimeController.Instance.OnTick += OnTick;
        }

        public void Destroy()
        {
            TimeController.Instance.OnTick -= OnTick;
        }

        protected static Dictionary<GalaxySize, int> NumStarSystemsForSize = new Dictionary<GalaxySize, int>()
        {
            {GalaxySize.Small, 100},
            {GalaxySize.Medium, 250},
            {GalaxySize.Large, 500},
            {GalaxySize.Enormous, 1000}
        };

        protected void OnTick(float deltaTime)
        {

        }

        protected void GenerateStarSystems()
        {
            for (int i = 0; i < NumStarSystemsForSize[Size]; i++)
            {
                StarSystem system = new StarSystem();
                StarSystems.Add(system);

                //TODO: Generate a name procedurally
                system.Name = "System " + i;

                Vector3 pos = Vector3.zero;
                switch (Type)
                {
                    case GalaxyType.Spiral:
                        //TODO: Figure out a random distribution for a spiral galaxy
                        float s = NumStarSystemsForSize[Size];
                        float h = s * 0.2f;
                        pos = new Vector3(Random.Range(-s, s), Random.Range(-h, h), Random.Range(-s, s));
                        break;
                    case GalaxyType.Elliptical:
                        //TODO: Figure out a random distribution for an ellipse galaxy
                        break;
                    case GalaxyType.Irregular:
                        //TODO: Figure out a random distribution for an irregular galaxy
                        break;
                }

                system.Position = pos;
            }
        }
    }
}