using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;
namespace core
{


    public class ApplyPlayerPos : MonoBehaviour
    {
        [SerializeField]
        Material[] Mat;
        [SerializeField]
        GameObject Player;
        public float Radius = 1f;
        float maxRadius  = 0;
        float time=0;

        void Start()
        {
            // Get the material
            //Mat = GetComponent<Renderer>().material;
            // Get the player object
            //Player = GameObject.Find("Player");
            //Player = this.gameObject;
        }

        void Update()
        {
            // Set the player position in the shader file

           
            
       
           
         foreach(Material t in Mat)
            {
                t.SetVector("_PlayerPos", Player.transform.position);
                // Set the distance or radius
                t.SetFloat("_Dist", Radius);
            }
        }

        public void incleseRadiusSize(float maxRadius,float timeActive)
        {
            if (maxRadius > this.maxRadius)
                this.maxRadius = maxRadius;
            if (timeActive > time)
                time = timeActive;
            StopAllCoroutines();
            StartCoroutine(Scale());
        }

        public IEnumerator increse(float maxRadius, float timeActive)
        {
            if (maxRadius > this.maxRadius)
                this.maxRadius = maxRadius;
            if (timeActive > time)
                time = timeActive;
            if (this.Radius < maxRadius)
            {
                Radius += 1 * Time.deltaTime;
                print("entre");

                yield return null;
            }
          
            else
            {
                print("entreeeee");
            }
            

        }





        public float maxSize;
        public float growFactor=1;
        public float waitTime;

  
        IEnumerator Scale()
        {
            float timer = 0;

            while (true) // this could also be a condition indicating "alive or dead"
            {
                // we scale all axis, so they will have the same value, 
                // so we can work with a float instead of comparing vectors
                while (maxRadius > Radius)
                {
                    timer += Time.deltaTime;
                    Radius += 1 * Time.deltaTime * growFactor;
                    yield return null;
                }
                // reset the timer

                yield return new WaitForSeconds(waitTime);

                timer = 0;

                while (Radius > 0.5f)
                {
                    timer += Time.deltaTime;
                    Radius -= 1 * Time.deltaTime * growFactor;
                    yield return null;
                }
              
                    StopAllCoroutines();
                
                //while (1 < transform.localScale.x)
                //{
                //    timer += Time.deltaTime;
                //    transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                //    yield return null;
                //}

                //timer = 0;
                //yield return new WaitForSeconds(waitTime);
            }
        }




    }
}
