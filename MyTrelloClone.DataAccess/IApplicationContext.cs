using Microsoft.EntityFrameworkCore;
using MyTrelloClone.Models;
using System.Threading;

namespace MyTrelloClone.DataAccess
{
    public interface IApplicationContext
    {
        DbSet<Board> Boards { get; set; }
        DbSet<TaskList> TaskLists { get; set; }
        DbSet<Task> Task { get; set; }


        System.Threading.Tasks.Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}