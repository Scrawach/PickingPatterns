namespace Weapons.UserInput
{
    public interface IInput
    {
        bool ShootPressed();
        bool WeaponChanged(out int slotId);
    }
}