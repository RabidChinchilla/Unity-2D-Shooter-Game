using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{

	
    // this material requires a custom shader attached to do the actual flashing
    // the shader provided is called "DefaultColorFlash", check it is attached to the material before using
    public Material flashMaterial;

    // this will store the current material on the spriterenderer
    // after the flash effect is complete, this will be re-attached to the spreiterenderer
    Material original;

    // store our attached spriterenderer
    SpriteRenderer sprite;

    void Start()
    {
        // get our attached spriterenderer
        sprite = GetComponent<SpriteRenderer>();

        // store the current material on the spriterenderer
        original = sprite.material;
    }

    // this method will activate the flash effect
    // the effect will swap materials on the spriterenderer for a short time, then swap them back again
    public void DoDamageFlash()
    {
        // set the material to the flash material on the spriterenderer
        sprite.material = flashMaterial;

        // set a timer to swap the material back to the original
        Invoke("ResetDamageFlash", 0.05f);
    }

    // this method resets the material from the flash effect to the original material
    void ResetDamageFlash()
    {
        // set the material back to the original on th espriterenderer
        sprite.material = original;
    }

    // this is a "saftey" method
    // if the gameobject gets destroyed while the flash effect timer is active, it will stop the timer
    // there is a marginal possibility the gameobject will not be destroyed immeditely otherwise
    // this is good practice if you user timers on things that may get destroyed often (bullets, enemies etc)
    void OnDestroy()
    {
        // cancel the timer on the damage flash
        CancelInvoke("ResetDamageFlash");
    }
}

