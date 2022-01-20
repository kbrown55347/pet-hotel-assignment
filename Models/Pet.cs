using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
  public enum PetBreedType
  {
    Shepherd, //0
    Poodle, //1
    Beagle,
    Bulldog,
    Terrier,
    Boxer,
    Labrador,
    Retriever
  }
  public enum PetColorType
  {
    Black, //0
    White, //1
    Golden,
    Tricolor,
    Spotted
  }
  public class Pet
  {
    // id is special, EF knows it a primary key and serial!
    public int id { get; set; }

    [Required]
    public string name { get; set; }

    public DateTime? checkedInAt { get; set; }

    // We need this `JsonConverter` attribute
    // to convert our `type` string into an Enum
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PetBreedType PetBreed { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PetColorType PetColor { get; set; }

    // This is the Id of the pet owner who owns the pet
    // In a moment, we'll see how .NET can use this field to 
    // join our tables together for us
    [ForeignKey("PetOwners")]
    public int petOwnerId { get; set; }

    // While petOwnerId is an integer with the pet owner's ID,
    // this field is an actual pet owner object. 
    public PetOwner ownedBy { get; set; }

  }
}
