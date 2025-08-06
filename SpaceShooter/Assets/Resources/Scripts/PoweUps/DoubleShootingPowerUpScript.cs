using UnityEngine;

public class DoubleShootingPowerUpScript : PowerUpScript {
    protected override void ApplyPowerUp(PlayerShooting shootingSystem) {
        shootingSystem.SetDoubleShootingMode();
    }
}
