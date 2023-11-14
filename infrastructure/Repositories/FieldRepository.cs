using Dapper;
using infrastructure.QueryModels;
using Npgsql;

namespace infrastructure.Repositories;

public class FieldRepository : RepositoryBase
{
    private readonly NpgsqlDataSource _dataSource;

    public FieldRepository(NpgsqlDataSource dataSource) : base(dataSource)
    {
        _dataSource = dataSource;
    }

    public IEnumerable<FieldQuery> GetAllFields()
    {
        return GetAllItems<FieldQuery>("field");
    }

    public int CreateField(string fieldName, string fieldLocation)
    {
        var parameters = new
        {
            name = fieldName,
            location = fieldLocation
        };

        return CreateItem<int>("bee", parameters);//TODO: check if it works, fix if not
    }

    public bool UpdateField(FieldQuery field)
    {
        return UpdateEntity("field", field, "id");
    }

    public bool DeleteField(int fieldId)
    {
        return DeleteItem("field", fieldId);
    }

    //TODO: change location later probably
    /// <summary>
    /// Input: Account id, Output: array of Field ids
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns>Returns an integer array that contains the ids for all the fields that are connected to the account id.</returns>
    public IEnumerable<int> GetFieldIdsForAccount(int accountId)
    {
        var parameters = new { id = accountId };
        
        return GetItemsByParameters<int>("field", parameters);
    }
}