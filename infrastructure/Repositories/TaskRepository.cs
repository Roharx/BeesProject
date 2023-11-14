using infrastructure.QueryModels;
using Npgsql;

namespace infrastructure.Repositories;

public class TaskRepository : RepositoryBase
{
    private readonly NpgsqlDataSource _dataSource;

    public TaskRepository(NpgsqlDataSource dataSource) : base(dataSource)
    {
        _dataSource = dataSource;
    }

    public IEnumerable<TaskQuery> GetAllTasks()
    {
        return GetAllItems<TaskQuery>("task");
    }

    public int CreateTask(int hiveId, string taskName, string taskDescription, bool taskDone)
    {
        var parameters = new
        {
            hive_id = hiveId,
            name = taskName,
            description = taskDescription,
            done = taskDone
        };

        return CreateItem<int>("task", parameters);
    }

    public bool UpdateInventory(TaskQuery task)
    {
        return UpdateEntity("task", task, "id");
    }

    public bool DeleteInventory(int taskId)
    {
        return DeleteItem("task", taskId);
    }
}