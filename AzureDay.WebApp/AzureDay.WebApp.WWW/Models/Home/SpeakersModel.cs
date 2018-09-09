using System.Collections.Generic;
using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.WWW.Models.Home
{
    public sealed class SpeakersModel
    {
        public List<List<SpeakerEntity>> SpeakersCollections { get; set; }

        public SpeakersModel()
        {
            SpeakersCollections = new List<List<SpeakerEntity>>();
        }
    }
}