using Dapper;
using infrastructure.QueryModels;
using Npgsql;

namespace infrastructure.Repositories;

public class AilmentRepository
{
    private NpgsqlDataSource _dataSource;

    public AilmentRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }
    public IEnumerable<AilmentQuery> GetAllAilments()
    {
        const string sql = $@"SELECT * FROM ailment";

        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Query<AilmentQuery>(sql);
            }
        }
        catch (Exception ex)
        {
            //TODO: use globalExceptionHandler later
            return Enumerable.Empty<AilmentQuery>();
        }
    }
    public IEnumerable<AilmentQuery> GetAilmentsForHive(int hiveId)
    {
        const string sql = $@"SELECT * FROM ailment WHERE hive_id=@hiveId";

        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Query<AilmentQuery>(sql, new { hiveId });
            }
        }
        catch (Exception ex)
        {
            //TODO: use globalExceptionHandler later
            return Enumerable.Empty<AilmentQuery>();
        }
    }
    
    public IEnumerable<AilmentQuery> GetGlobalAilments()
    {
        const string sql = $@"SELECT * FROM ailment WHERE severity IN (5, 6)";//TODO: test
        //TODO: try not to hard code it, fix it when have time
        //maybe good enough as enums won't change

        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Query<AilmentQuery>(sql);
            }
        }
        catch (Exception ex)
        {
            //TODO: use globalExceptionHandler later
            return Enumerable.Empty<AilmentQuery>();
        }
    }
    //TODO: Create Ailment, Remove Ailment, Add Ailment to hive
}