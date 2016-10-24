using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace surveyapi.Models
{
    public class Survey
    {
        public Survey()
        {
            
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public List<Question> Questions {
            get;
            set;
        }
    }

    public class Question
    {
        public int Number {
            get;
            set;
        }

        public string Text {
            get;
            set;
        }

        public List<string> Options {
            get;
            set;
        }
    }
}
