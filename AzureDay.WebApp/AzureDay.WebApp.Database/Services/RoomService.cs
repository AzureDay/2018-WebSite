using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.Database.Services
{
    public class RoomService: BaseService<RoomEntity, int>
    {
        protected override List<RoomEntity> PopulateStorage()
        {
            return new List<RoomEntity>
            {
//                new RoomEntity { Id = 1, Name = "First" },
//                new RoomEntity { Id = 2, Name = "Second" },
//                new RoomEntity { Id = 3, Name = "Third" }
            };
        }
    }
}