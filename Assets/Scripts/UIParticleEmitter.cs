using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIParticleEmitter : MonoBehaviour {

    public Texture particleImage;
    public Color color;
    public float particleSize;
    public int particleQuntity;
    public float gravity;

    Vector2 position, size;
    float width, height, halfSize;

    ArrayList particles;
    
    public Vector2 debug;

    public Canvas parentCanvas;
    //Button particleButton;
	// Use this for initialization
	void Start () {
        debug = new Vector2(Random.Range(-300, 300), Random.Range(-300, 300));
        

        debug.Normalize();
        debug.x = debug.x* 20000 * Time.deltaTime;
        width = GetComponent<RectTransform>().rect.width;
        height = GetComponent<RectTransform>().rect.height;
        halfSize = particleSize * 0.5f;

        //Area of emitting
        size = new Vector2(width, height);

        position = new Vector2(transform.position.x - halfSize, transform.position.y - halfSize);

        //list of particles
        particles = new ArrayList();

        for (int i = 1; i< particleQuntity; i++)
        {
            Vector2 tempPos = new Vector2(Random.Range(position.x - (width * 0.15f), position.x + (width * 0.15f)),
                Random.Range(position.y - (height * 0.15f), position.y + (height * 0.15f)));
            Vector2 tempDir = new Vector2(Random.Range(-300, 300), Random.Range(-300, 20));
            tempDir.Normalize();
            UIParticle p = new UIParticle();
            p.Initialize(tempPos, particleSize, tempDir, color);
            particles.Add(p);
        }

        //particleButton = transform.parent.transform.GetChild(1).GetComponent<Button>();
        //particleButton.onClick.AddListener(Esplode);
        //Reset();
    }
	
	// Update is called once per frame
	void Update () {
        width = GetComponent<RectTransform>().rect.width;
        height = GetComponent<RectTransform>().rect.height;
        halfSize = particleSize * 0.5f;
        size = new Vector2(width, height);
        position = new Vector2(transform.position.x-halfSize, transform.position.y-halfSize);

        foreach(UIParticle p in particles)
        {
            p.Update(gravity);
        }
    }

    void OnGUI()
    {
        foreach (UIParticle p in particles)
        {
            if (!p.dead)
            {
                GUI.color = color;
                GUI.DrawTexture(new Rect(p.pos.x, p.pos.y, particleSize, particleSize), particleImage);
            }
        }
    }

    public void Reset()
    {
        foreach (UIParticle p in particles)
        {
            p.dead = false;
            Vector2 tempPos = new Vector2(Random.Range(position.x - (width * 0.15f), position.x + (width * 0.15f)),
                Random.Range(position.y - (height * 0.15f), position.y + (height * 0.15f)));
            Vector2 tempDir = new Vector2(Random.Range(-300, 300), Random.Range(-1000, 1000));
            tempDir.Normalize();
            p.pos = tempPos;
            p.dir = tempDir;
            p.gravityPull = 0;
            p.elapsedLyfe = 0;
        }
    }

    void Esplode()
    {
        Reset();
    }
    
}

public class UIParticle : MonoBehaviour
{
    public Vector2 pos;
    public float sizeC;
    public bool dead;
    public Vector2 dir;
    public float timeTilDed;
    Color colorC;
    public float gravityPull;
    float speed;
    public float elapsedLyfe;

    public void Initialize(Vector2 position, float size, Vector2 direction, Color color)
    {
        dead = true;
        timeTilDed = Random.Range(0.0f, 1.0f);
        //timeTilDed = 0.1f;
        elapsedLyfe = 0;
        pos = position;
        size = sizeC;
        dir = direction;
        colorC = color;
        gravityPull = 0;
        speed = Random.Range(1, 60);
    }

    public void Update(float gravity)
    {
        if (!dead)
        {
            elapsedLyfe += Time.unscaledDeltaTime;
            if (elapsedLyfe >= timeTilDed)
                dead = true;
            gravityPull += gravity;
            pos.x= (pos.x + (dir.x*speed) * Time.unscaledDeltaTime);
            pos.y = (pos.y + ((dir.y * speed) * Time.unscaledDeltaTime) + gravityPull);
        }
    }
}