using Dapper;
using infrastructure.QueryModels;
using Npgsql;

namespace infrastructure.Repositories;

public class HiveRepository
{
    private NpgsqlDataSource _dataSource;

    public HiveRepository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public IEnumerable<HiveQuery> GetAllHives()
    {
        const string sql = $@"SELECT * FROM hive";

        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Query<HiveQuery>(sql);
            }
        }
        catch (Exception ex)
        {
            //TODO: use globalExceptionHandler later
            return Enumerable.Empty<HiveQuery>();
        }
    }

    public int CreateHive(int fId, string hiveName, string hiveLocation, DateTime placementDate, DateTime lCheck,
        bool readyToHarvest, string hiveColor, string hiveComment, int bType)
    {
        const string sql =
            $@"INSERT INTO hive (field_id, name, location, placement, last_check, ready, color, comment, bee_type) 
            VALUES (@fieldId, @name, @location, @placement, @lastCheck, @ready, @color, @comment, @beeType)";

        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                // ExecuteScalar is used to retrieve a single value (in this case, the ID).
                var hiveId = conn.ExecuteScalar<int>(sql, new
                {
                    fieldId = fId,
                    name = hiveName,
                    location = hiveLocation,
                    placement = placementDate,
                    lastCheck = lCheck,
                    ready = readyToHarvest,
                    color = hiveColor,
                    comment = hiveComment,
                    beeType = bType
                });
                return hiveId;
            }
        }
        catch (Exception ex)
        {
            //TODO: use globalExceptionHandler later
            return -1;
        }
    }
    public bool UpdateHive(HiveQuery hive)
    {
        const string sql = $@"UPDATE hive SET field_id=@fieldId, name=@name, location=@location, placement=@placement,
                last_check=@lastcheck, ready=@ready, color=@color, comment=@comment, bee_type=beeType WHERE id=@id";

        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                conn.Execute(sql, new
                {
                    //Protects against sql injection if used properly TODO: Ask to be sure
                    fieldId = hive.HiveFieldId,
                    name = hive.HiveName,
                    location = hive.HiveLocation,
                    placement = hive.HivePlacementDate,
                    lastCheck = hive.HiveLastCheck,
                    ready = hive.HiveReadyToHarvest,
                    color = hive.HiveColor,
                    comment = hive.HiveComment,
                    beeType = hive.BeeId
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
    public bool DeleteHive(int hiveId)
    {
        const string sql = $@"DELETE FROM hive WHERE id=@id";
        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                conn.Execute(sql, new { id = hiveId });
                return true;
            }
        }
        catch
        {
            //TODO: use globalExceptionHandler later
            return false;
        }
    }
    
    public IEnumerable<HiveQuery> GetHivesForFieldId(int fieldId)
    {
        const string sql = $@"SELECT * FROM hive WHERE field_id = @fieldId";

        try
        {
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.Query<HiveQuery>(sql, new { fieldId });
            }
        }
        catch (Exception ex)
        {
            //TODO: use globalExceptionHandler later
            return Enumerable.Empty<HiveQuery>();
        }
    }
}