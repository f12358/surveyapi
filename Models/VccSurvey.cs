using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace surveyapi.Models
{
    public class VccSurvey : Survey
    {
        public VccSurvey()
        {
        }

        [BsonIgnore]
        public IEnumerable<Office> Offices {
            get;
            set;
        }

        [BsonIgnore]
        public DateTime MeetingTime {
            get;
            set;
        }
    }
}