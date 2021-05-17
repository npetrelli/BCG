using UnityEngine;

public class Instruments : MonoBehaviour
{
    private RaycastHit hit;
    private GameObject  player;
    public  ScriptabledObject   data;
    public  int                 id;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnMouseDown()
    {
        if (data.instruments[id] == false)
        {
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist < 4)
            {
                data.instruments[id] = true;
                SetActive.SetActiveMethod(id);
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        transform.Rotate(0, 0, 2.0f);
    }
}
