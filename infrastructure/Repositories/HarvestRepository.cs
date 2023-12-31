﻿using infrastructure.QueryModels;
using Npgsql;

namespace infrastructure.Repositories;

public class HarvestRepository : RepositoryBase
{
    private readonly NpgsqlDataSource _dataSource;

    public HarvestRepository(NpgsqlDataSource dataSource) : base(dataSource)
    {
        _dataSource = dataSource;
    }
    public IEnumerable<HarvestQuery> GetAllFields()
    {
        return GetAllItems<HarvestQuery>("harvest");
    }

    public int CreateField(int hiveId, DateTime harvestTime, int honeyAmount, int beeswaxAmount, string harvestComment)
    {
        var parameters = new
        {
            hive_id = hiveId,
            time = harvestTime,
            honey_amount = honeyAmount,
            beeswax_amount = beeswaxAmount,
            comment = harvestComment
        };

        return CreateItem<int>("harvest", parameters);//TODO: check if it works, fix if not
    }

    public bool UpdateField(HarvestQuery harvest)
    {
        return UpdateEntity("harvest", harvest, "id");
    }

    public bool DeleteField(int harvestId)
    {
        return DeleteItem("harvest", harvestId);
    }
}