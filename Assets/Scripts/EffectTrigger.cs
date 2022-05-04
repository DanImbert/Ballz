using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTrigger : MonoBehaviour
{

   public ParticleSystem particleEffect;
    public GameObject particleObject;
    public float delay = 5f;
    bool once = false;


    float countdown;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !once)
        {
           
             once = true;
            effectSwitch();
            
        }

       // else if(once == false)
       // {
            //particleEffect.Stop();
       // }
    }

    public void effectSwitch()
    {
       particleObject.SetActive(true);
       particleEffect.Play();

        //Instantiate(particleObject, transform.position, transform.rotation);

    }

   
}
