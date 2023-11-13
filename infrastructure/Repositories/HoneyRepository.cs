using Dapper;
using infrastructure.DataModels;
using infrastructure.QueryModels;
using Npgsql;

namespace infrastructure.Repositories;

public class HoneyRepository
{
    private NpgsqlDataSource _dataSource;

    public HoneyRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public IEnumerable<HoneyQuery> GetAllHoneys()
    {
        const string sql = $@"SELECT * FROM honey";

        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Query<HoneyQuery>(sql);
            }
        }
        catch (Exception ex)
        {
            //TODO: use globalExceptionHandler later
            return Enumerable.Empty<HoneyQuery>();
        }
    }

    public int CreateHoney(int harvestId, string honeyName, bool honeyLiquidity, string honeyFlowers, float honeyMoisture)
    {
        const string sql =
            $@"INSERT INTO honey (harvest_id, name, liquid, flowers, moisture) VALUES (@id, @name, @liquid, @flowers, @moisture)";

        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                // ExecuteScalar is used to retrieve a single value (in this case, the ID).
                var honeyId = conn.ExecuteScalar<int>(sql, new
                {
                    id = harvestId,
                    name = honeyName,
                    liquid = honeyLiquidity,
                    flowers = honeyFlowers,
                    moisture = honeyMoisture
                });
                return honeyId;
            }
        }
        catch (Exception ex)
        {
            //TODO: use globalExceptionHandler later
            return -1;
        }
    }

    public bool UpdateHoney(HoneyQuery honey)
    {
        const string sql = $@"UPDATE honey SET harvest_id=@harvestId name=@name, liquid=@liquid, flowers=@flowers, moisture=@moisture WHERE id=@id";

        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                conn.Execute(sql, new
                {
                    //Protects against sql injection if used properly TODO: Ask to be sure
                    harvest_id = honey.HoneyHarvest,
                    name = honey.HoneyName,
                    liquid = honey.HoneyLiquid,
                    flowers = honey.HoneyFlowers,
                    moisture = honey.HoneyMoisture,
                    id = honey.HoneyId
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

    public bool DeleteHoney(int honeyId)
    {
        const string sql = $@"DELETE FROM honey WHERE id=@id";
        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                conn.Execute(sql, new { id = honeyId });
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