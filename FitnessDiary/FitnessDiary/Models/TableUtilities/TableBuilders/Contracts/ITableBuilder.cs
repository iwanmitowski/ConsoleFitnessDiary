namespace FitnessDiary.Models.TableUtilities.TableBuilders.Contracts
{
    public interface ITableBuilder
    {
        abstract string BuildTable();
        bool IsEmptyTable();
    }
}
