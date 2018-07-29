using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreaseMaker : MonoBehaviour {


    public ParticleSystem greaseParticle;



    private void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(other.gameObject.name + "Hit me");

        if(other.gameObject.tag == "Ingredient")
        {

            ContactPoint2D[] pointsOfContact = new ContactPoint2D[10];

            other.GetContacts(pointsOfContact);

            //Debug.Log(pointsOfContact.Length + " points of contact");

            int count = pointsOfContact.Length;
            for (int i = 0; i < count; i++)
            {
                //Debug.Log(pointsOfContact[i].point + " is a point of contact");

                if(pointsOfContact[i].point != Vector2.zero)
                {
                    PlayParticleAtLocation(pointsOfContact[i].point);
                }

            }

        }
    }

    private void PlayParticleAtLocation(Vector2 location)
    {
        greaseParticle.gameObject.transform.position = location;
        greaseParticle.Play();
    }

}
