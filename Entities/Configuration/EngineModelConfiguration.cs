using AutoDealer.Entities.Models.Auto.IntermediateModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDealer.Entities.Configuration
{
    public class EngineModelConfiguration : IEntityTypeConfiguration<EngineModel>
    {
        public void Configure(EntityTypeBuilder<EngineModel> builder)
        {
            builder.HasData(
                new EngineModel
                {
                    EnginesId = 1,
                    ModelsId = 7,
                },
                new EngineModel
                {
                    EnginesId = 2,
                    ModelsId = 7,
                },
                new EngineModel
                {
                    EnginesId = 3,
                    ModelsId = 7,
                }
            );
        }
    }
}