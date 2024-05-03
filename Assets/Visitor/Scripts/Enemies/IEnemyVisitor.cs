namespace Visitor.Scripts.Enemies
{
    public interface IEnemyVisitor
    {
        void Visit(Elf elf);
        void Visit(Human human);
    }
}