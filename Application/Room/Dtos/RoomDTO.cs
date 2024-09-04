using Domain.Enums;
using Domain.Entities;
using Domain.Enums;

namespace Application.Room.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool InMaintenance { get; set; }
        public decimal Price { get; set; }
        public AcceptedCurrencies Currency { get; set; }

        public static Domain.Room.Entities.Room MapToEntity(RoomDto dto)
        {
            return new Domain.Room.Entities.Room
            {
                Id = dto.Id,
                Name = dto.Name,
                Level = dto.Level,
                InMaintenance = dto.InMaintenance,
                Price = new Domain.ValueObjects.Price { currency = dto.Currency, Value = dto.Price }
            };
        }

        public static RoomDto MapToDto(Domain.Room.Entities.Room room)
        {
            return new RoomDto
            {
                Id = room.Id,
                Name = room.Name,
                Level = room.Level,
                InMaintenance = room.InMaintenance,
            };
        }
    }
}