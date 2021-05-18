using UnityEngine;

public class Instruments : MonoBehaviour
{
    private RaycastHit hit;
    private GameObject  player;
    public  ScriptabledObject   data;
    public  int                 id;
    private AudioSource         audioSource;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        if (data.instruments[id] == false)
        {
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist < 5)
            {
                data.instruments[id] = true;
                SetActive.SetActiveMethod(id);
                audioSource.Play();
                Destroy(gameObject, 0.1f);
            }
        }
    }

    private void Update()
    {
        transform.Rotate(0, 0, 2.0f);
    }
}
