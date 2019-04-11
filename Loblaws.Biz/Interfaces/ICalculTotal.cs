namespace Loblaws.Biz.Interfaces
{
    public interface ICalculTotal
    {
        decimal Calculer(decimal sousTotal, decimal taxes);
    }
}
