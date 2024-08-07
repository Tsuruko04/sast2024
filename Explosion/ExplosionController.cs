using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public GameObject nuclearPrefab;
    public GameObject soulsPrefab;
    GameObject general;
    public bool trigger = false;

    // Start is called before the first frame update
    void Start()
    {
        general = GameObject.Find("General");
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger)
        {
            trigger = false;
            Explode();
        }
    }

    private void Explode()
    {
        Vector3 pos = general.transform.position - (general.transform.position - general.GetComponent<GeneralController>().target).normalized * 500;
        GameObject nuclearClip = Instantiate(nuclearPrefab);
        GameObject soulsClip = Instantiate(soulsPrefab);
        nuclearClip.transform.position = pos;
        soulsClip.transform.position = pos;
        general.GetComponent<GeneralController>().captureHim = true;
    }
}
