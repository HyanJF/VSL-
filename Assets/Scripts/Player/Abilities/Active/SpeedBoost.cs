using UnityEngine;

[CreateAssetMenu]
public class SpeedBoost : ActiveAbility
{
    public float speedMultiplier;
    float originalSpeed;

    public override void ActivateAbility(GameObject player)
    {
        Debug.Log("Gotta go fast");
        originalSpeed = player.GetComponent<PlayerMovement>().speed;
        player.GetComponent<PlayerMovement>().speed = player.GetComponent<PlayerMovement>().speed * speedMultiplier;
    }

    public override void DeactivateAbility(GameObject player)
    {
        Debug.Log("Gotta go slow");
        player.GetComponent<PlayerMovement>().speed = originalSpeed;
    }
}
