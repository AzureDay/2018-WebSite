using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.WWW.Models.Home
{
    public class SpeakerModel
    {
        public SpeakerEntity Speaker { get; set; }
        public List<WorkshopModel> Workshops { get; set; }
        public List<TopicEntity> Topics { get; set; }
    }
}