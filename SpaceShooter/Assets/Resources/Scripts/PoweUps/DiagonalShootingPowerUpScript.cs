using UnityEngine;

public class DiagonalShootingPowerUpScript : PowerUpScript {
    protected override void ApplyPowerUp(PlayerShooting shootingSystem) {
        shootingSystem.SetDiagonalShootingMode();
    }
}
