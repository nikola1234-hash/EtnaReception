using System.Collections.Generic;

namespace BookSoft.Domain
{
    public enum TypeOfSqlCommand
    {
        sp
    }
    public interface IDataService
    {
        public IEnumerable<T> LoadData<T, U>(string sqlParameter, U command);
        public int SaveData<T>(string sqlParameter, T command);
    }
}
