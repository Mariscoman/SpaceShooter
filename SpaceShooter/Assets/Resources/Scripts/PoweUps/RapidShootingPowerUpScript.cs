using UnityEngine;

public class RapidShootingPowerUpScript : PowerUpScript {
    protected override void ApplyPowerUp(PlayerShooting shootingSystem) {
        shootingSystem.SetRapidShootingMode();
    }
}
