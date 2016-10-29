// see https://docs.mongodb.com/v3.2/tutorial/geospatial-tutorial/#searching-for-restaurants for reference

db.Office.drop()

db.Office.find({})

// create 2dsphere geo index
db.Office.createIndex( { Location : "2dsphere" } )

// see indexes for collection
db.Office.getIndexes()


db.Office.insertMany([
   {
      Name: "NY",
      Location : { type: "Point", coordinates: [ -73.974912, 40.763845 ] },
      Rooms: ["10-1","10-2","10-Plaza"]
   },
   {
      Name: "SF",
      Location : { type: "Point", coordinates: [ -122.403697, 37.792291 ] },
      Rooms: ["Houston"]
   }
])

var METERS_PER_MILE = 1609.34
db.Office.find({ 
    Location: { 
        $nearSphere: { 
            $geometry: { type: "Point", coordinates: [ -73.973858, 40.766906 ] }, 
            $maxDistance: 5 * METERS_PER_MILE } 
    } 
})
