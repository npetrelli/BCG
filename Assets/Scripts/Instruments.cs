using UnityEngine;

public class Instruments : MonoBehaviour
{
    private RaycastHit hit;
    private GameObject  player;
    public  ScriptabledObject   data;
    public  int                 id;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnMouseDown()
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
