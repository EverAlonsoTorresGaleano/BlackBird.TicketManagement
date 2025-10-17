using BlackBird.TicketManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace BlackBird.TicketManagement.Infrastructure.TransverseRepositories.DataContext;

public partial class ModelDataContext : DbContext, IModelDataContext
{
    public ModelDataContext()
    {
    }

    public ModelDataContext(DbContextOptions<ModelDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GeneralTypeGroup> GeneralTypeGroups { get; set; }

    public virtual DbSet<GeneralTypeItem> GeneralTypeItems { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GeneralTypeGroup>(entity =>
        {
            entity.HasKey(e => e.GeneralTypeGroupId).HasName("PK_GeneralTypes");

            entity.Property(e => e.GroupName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GeneralTypeItem>(entity =>
        {
            entity.Property(e => e.ItemName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.GeneralTypeGroupFkNavigation).WithMany(p => p.GeneralTypeItems)
                .HasForeignKey(d => d.GeneralTypeGroupFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GeneralTypeItems_GeneralTypeGroups");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Tickets__712CC607530232FC");

            entity.ToTable(tb => tb.IsTemporal(ttb =>
            {
                ttb.UseHistoryTable("TicketsHistory", "dbo");
                ttb
                    .HasPeriodStart("ValidFrom")
                    .HasColumnName("ValidFrom");
                ttb
                    .HasPeriodEnd("ValidTo")
                    .HasColumnName("ValidTo");
            }));

            entity.Property(e => e.Audience).IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Details).IsUnicode(false);
            entity.Property(e => e.EventDate).HasColumnType("datetime");
            entity.Property(e => e.Localization).IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.AsignedToUserFkNavigation).WithMany(p => p.TicketAsignedToUserFkNavigations)
                .HasForeignKey(d => d.AsignedToUserFk)
                .HasConstraintName("FK_Tickets_Users1");

            entity.HasOne(d => d.CreatedByUserFkNavigation).WithMany(p => p.TicketCreatedByUserFkNavigations)
                .HasForeignKey(d => d.CreatedByUserFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_Users");

            entity.HasOne(d => d.TicketStateFkNavigation).WithMany(p => p.TicketTicketStateFkNavigations)
                .HasForeignKey(d => d.TicketStateFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_GeneralTypeItems1");

            entity.HasOne(d => d.TicketTypeFkNavigation).WithMany(p => p.TicketTicketTypeFkNavigations)
                .HasForeignKey(d => d.TicketTypeFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tickets_GeneralTypeItems");

            entity.HasOne(d => d.UpdatedByUserFkNavigation).WithMany(p => p.TicketUpdatedByUserFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserFk)
                .HasConstraintName("FK_Tickets_Users2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastAccess).HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserSecret)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.RoleFkNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_UserRoles");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
