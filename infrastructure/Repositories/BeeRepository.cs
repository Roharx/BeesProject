using Dapper;
using infrastructure.QueryModels;
using Npgsql;

namespace infrastructure.Repositories;

public class BeeRepository
{
    private NpgsqlDataSource _dataSource;

    public BeeRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }
    public IEnumerable<BeeQuery> GetAllBees()
    {
        const string sql = $@"SELECT * FROM bee";

        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Query<BeeQuery>(sql);
            }
        }
        catch (Exception ex)
        {
            //TODO: use globalExceptionHandler later
            return Enumerable.Empty<BeeQuery>();
        }
    }
    public int CreateBee(string beeName, string beeDescription, string beeComment)
    {
        const string sql =
            $@"INSERT INTO bee (name, description, comment) VALUES (@name, @description, @comment)";

        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                // ExecuteScalar is used to retrieve a single value (in this case, the ID).
                var beeId = conn.ExecuteScalar<int>(sql, new
                {
                    name = beeName,
                    description = beeDescription,
                    comment = beeComment
                });
                return beeId;
            }
        }
        catch (Exception ex)
        {
            //TODO: use globalExceptionHandler later
            return -1;
        }
    }
    public bool UpdateBee(BeeQuery bee)
    {
        const string sql = $@"UPDATE bee SET name=@name, description=@description, comment=@comment WHERE id=@id";

        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                conn.Execute(sql, new
                {
                    //Protects against sql injection if used properly TODO: Ask to be sure
                    name = bee.BeeName,
                    description = bee.BeeDescription,
                    comment = bee.BeeComment,
                    id = bee.BeeId
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
    
    public bool DeleteBee(int beeId)
    {
        const string sql = $@"DELETE FROM bee WHERE id=@id";
        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                conn.Execute(sql, new { id = beeId });
                return true;
            }
        }
        catch
        {
            //TODO: use globalExceptionHandler later
            return false;
        }
        
    }
}