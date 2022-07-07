using W11_Prove_retry.Game.Casting;

namespace W11_Prove_retry.Game.Services
{
    public interface PhysicsService
    {
        bool HasCollided(Actor subject, Actor agent);
    }
}