using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasOne(x => x.TeamOne)
                .WithMany()
                .HasForeignKey(x => x.TeamOneId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TeamTwo)
                .WithMany()
                .HasForeignKey(x => x.TeamTwoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.WinningTeam)
                .WithMany()
                .HasForeignKey(x => x.WinningTeamId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
