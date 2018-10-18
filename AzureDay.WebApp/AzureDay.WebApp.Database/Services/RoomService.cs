using System.Linq;
using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.Database.Services
{
    public class RoomService : BaseService<RoomEntity, int>
    {
        protected override List<RoomEntity> PopulateStorage()
        {
            return new List<RoomEntity>
            {
                new RoomEntity {Id = 1, ColorNumber = 1, RoomType = Enums.RoomType.LectureRoom, Title = Localization.App.Service.Room.WebDev },
                new RoomEntity {Id = 2, ColorNumber = 2, RoomType = Enums.RoomType.LectureRoom, Title = Localization.App.Service.Room.IoT },
                new RoomEntity {Id = 3, ColorNumber = 3, RoomType = Enums.RoomType.LectureRoom, Title = Localization.App.Service.Room.AInML },
                //new RoomEntity {Id = 4, ColorNumber = 4, RoomType = Enums.RoomType.LectureRoom, Title = Localization.App.Service.Room.DevOps },
                //new RoomEntity {Id = 5, ColorNumber = 5, RoomType = Enums.RoomType.LectureRoom, Title = Localization.App.Service.Room.ITPro },

                new RoomEntity {Id = 101, ColorNumber = 1, RoomType = Enums.RoomType.WorkshopRoom, Title = Localization.App.Service.Room.Workshop1 },
                new RoomEntity {Id = 102, ColorNumber = 2, RoomType = Enums.RoomType.WorkshopRoom, Title = Localization.App.Service.Room.Workshop2 },
                new RoomEntity {Id = 103, ColorNumber = 3, RoomType = Enums.RoomType.WorkshopRoom, Title = Localization.App.Service.Room.Workshop3 },
                new RoomEntity {Id = 104, ColorNumber = 4, RoomType = Enums.RoomType.WorkshopRoom, Title = Localization.App.Service.Room.Workshop4 },
                new RoomEntity {Id = 105, ColorNumber = 5, RoomType = Enums.RoomType.WorkshopRoom, Title = Localization.App.Service.Room.Workshop5 },
                new RoomEntity {Id = 106, ColorNumber = 6, RoomType = Enums.RoomType.WorkshopRoom, Title = Localization.App.Service.Room.Workshop6 },
                new RoomEntity {Id = 107, ColorNumber = 7, RoomType = Enums.RoomType.WorkshopRoom, Title = Localization.App.Service.Room.Workshop7 },
                new RoomEntity {Id = 108, ColorNumber = 8, RoomType = Enums.RoomType.WorkshopRoom, Title = Localization.App.Service.Room.Workshop8 },
                new RoomEntity {Id = 109, ColorNumber = 9, RoomType = Enums.RoomType.WorkshopRoom, Title = Localization.App.Service.Room.Workshop9 },
                new RoomEntity {Id = 110, ColorNumber = 10, RoomType = Enums.RoomType.WorkshopRoom, Title = Localization.App.Service.Room.Workshop10 },

                new RoomEntity {Id = 999, ColorNumber = 0, RoomType = Enums.RoomType.CoffeeRoom }
            };
        }

        public RoomEntity CoffeeBreak { get { return Storage.Single(x => x.Id == 999); } }

        public RoomEntity Room1 { get { return Storage.Single(x => x.Id == 1); } }
        public RoomEntity Room2 { get { return Storage.Single(x => x.Id == 2); } }
        public RoomEntity Room3 { get { return Storage.Single(x => x.Id == 3); } }
        //public RoomEntity Room4 { get { return Storage.Single(x => x.Id == 4); } }
        //public RoomEntity Room5 { get { return Storage.Single(x => x.Id == 5); } }

        public RoomEntity Workshop1 { get { return Storage.Single(x => x.Id == 101); } }
        public RoomEntity Workshop2 { get { return Storage.Single(x => x.Id == 102); } }
        public RoomEntity Workshop3 { get { return Storage.Single(x => x.Id == 103); } }
    }
}