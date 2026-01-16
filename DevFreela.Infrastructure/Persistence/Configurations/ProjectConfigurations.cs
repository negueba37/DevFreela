using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
	internal class ProjectConfigurations : IEntityTypeConfiguration<Project>
	{
		public void Configure(EntityTypeBuilder<Project> builder)
		{
			builder
			.HasKey(e => e.Id);

			builder
			.Property(e => e.CreatedAt)
			.HasColumnType("DateTime");

			builder
			.Property(e => e.StartedAt)
			.HasColumnType("DateTime");

			builder
			.Property(e => e.FinishedAt)
			.HasColumnType("DateTime");


			builder
				.HasOne(p => p.Freelancer)
				.WithMany(f => f.FreelanceProjects)
				.HasForeignKey(p => p.IdFreelancer)
				.OnDelete(DeleteBehavior.Restrict);

			builder
				.HasOne(p => p.Client)
				.WithMany(f => f.OwnedProjects)
				.HasForeignKey(p => p.IdClient)
				.OnDelete(DeleteBehavior.Restrict);

		}
	}
}
