using Dapper;
using infrastructure.QueryModels;
using Npgsql;

namespace infrastructure.Repositories;

public class FieldRepository
{
    private NpgsqlDataSource _dataSource;

    public FieldRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public IEnumerable<FieldQuery> GetAllFields()
    {
        const string sql = $@"SELECT * FROM field";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<FieldQuery>(sql);
        }
    }

    public int CreateField(string fieldName, string fieldLocation)
    {
        const string sql = $@"INSERT INTO field (name, location) VALUES (@name, @location)";

        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                // ExecuteScalar is used to retrieve a single value (in this case, the ID).
                var fieldId = conn.ExecuteScalar<int>(sql, new
                {
                    name = fieldName,
                    location = fieldLocation
                });
                return fieldId;
            }
        }
        catch (Exception ex)
        {
            //TODO: use globalExceptionHandler later
            return -1;
        }
    }

    public bool UpdateField(FieldQuery field)
    {
        const string sql = $@"UPDATE field SET name=@name, location=@location WHERE id=@id";

        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                conn.Execute(sql, new
                {
                    //Protects against sql injection if used properly TODO: Ask to be sure
                    id = field.FieldId,
                    name = field.FieldName,
                    location = field.FieldLocation
                });
                return true;
            }
        }
        catch
        {
            //TODO: use globalExceptionHandler later
            return false;
        }
    }

    public bool DeleteField(int fieldId)
    {
        const string sql = $@"DELETE FROM field WHERE id=@id";
        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                conn.Execute(sql, new { id = fieldId });
                return true;
            }
        }
        catch
        {
            //TODO: use globalExceptionHandler later
            return false;
        }
    }

    //TODO: change location later probably
    /// <summary>
    /// Input: Account id, Output: array of Field ids
    /// </summary>
    /// <param name="accountId"></param>
    /// <returns>Returns an integer array that contains the ids for all the fields that are connected to the account id.</returns>
    public IEnumerable<int> GetFieldIdsForAccount(int accountId)
    {
        const string sql = $@"SELECT field_id FROM field_account WHERE account_id = @accountId";

        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Query<int>(sql, new { accountId });
            }
        }
        catch (Exception ex)
        {
            //TODO: use globalExceptionHandler later
            return Enumerable.Empty<int>();
        }
    }
}