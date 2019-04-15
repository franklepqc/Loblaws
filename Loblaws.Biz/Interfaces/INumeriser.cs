namespace Loblaws.Biz.Interfaces
{
    public interface INumeriser
    {
        bool TryGet(out string nom, out decimal prix);
    }
}
