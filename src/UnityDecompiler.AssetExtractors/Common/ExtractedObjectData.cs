/* Copyright 2025 Hollow1
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*     http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/
using System.Drawing;


#pragma warning disable
public class GameObject
{
    public GameObject()
    {
        this.name = "GameObject";
    }

    public string name;
    public string tag = "Untagged";
    public (int, string) layer = (0, "Default");
    public GameObject parent = null;
    public List<GameObject> children = new List<GameObject>();
    public Transform transform;
    public List<Component> components = new List<Component>();
}

public class Transform
{
    public Vector3 position = new Vector3 (0, 0, 0);
    public Vector3 rotation = new Vector3 (0, 0, 0);
    public Vector3 scale = new Vector3 (1, 1, 1);
    public bool enableConstraints = false;
}

public class Sprite
{
    public string spritePath;
}

public class Material
{
    // TODO
}

// -------------------------------------------------------------- COMPONENTS --------------------------------------------------------------

public struct Vector2
{
    public float x;
    public float y;

    public Vector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
}

public struct Vector3
{
    public float x;
    public float y;
    public float z;

    public Vector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

public class Component
{
    public string name;
}

namespace Components
{
    public class SpriteRenderer : Component
    {
        public SpriteRenderer()
        {
            this.name = "SpriteRenderer";
        }

        public Sprite sprite;
        public Material material;
        public Color color = Color.FromArgb(255, 255, 255, 255);
        public string Layer;
        public int orderInLayer;

        public void SetColor(int alpha, int red, int green, int blue)
        {
            this.color = Color.FromArgb(alpha, red, green, blue);
        }
    }

    public class RigidBody : Component
    {
        public RigidBody()
        {
            this.name = "RigidBody";
        }

        public Physics.BodyType bodyType;
        public bool isSimulated = false;
        public float mass = 1;
        public float linearDrag = 0;
        public float angularDrag = 0.05f;
        public float gravityScale = 1;
        public Physics.CollisionDetection collisionDetection;
        public Physics.SleepingMode sleepingMode;
        public Physics.Interpolate interpolate;
    }

    public class BoxCollider : Component
    {
        public BoxCollider()
        {
            this.name = "RigidBody";
        }

        public bool isTrigger = false;
        public Vector2 offset = new Vector2(0, 0);
        public Vector2 size = new Vector2(1, 1);
    }
}

namespace Physics
{
    public enum BodyType
    {
        Dynamic,
        Kinematic,
        Static
    }

    public enum CollisionDetection
    {
        Discrete,
        Continuous
    }

    public enum SleepingMode
    {
        NeverSleep,
        StartAwake,
        StartAsleep
    }

    public enum Interpolate
    {
        None,
        Interpolate,
        Extrapolate
    }
}

