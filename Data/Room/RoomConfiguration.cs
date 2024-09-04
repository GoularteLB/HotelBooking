using Domain.Room.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Rooms
{
    public class RoomConfiguration : IEntityTypeConfiguration<Domain.Room.Entities.Room>
    {
        public void Configure(EntityTypeBuilder<Domain.Room.Entities.Room> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Price)
                .Property(x => x.currency);

            builder.OwnsOne(x => x.Price)
                .Property(x => x.Value);
        }
    }
}
