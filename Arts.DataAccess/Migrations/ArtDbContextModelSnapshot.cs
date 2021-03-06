// <auto-generated />
using System;
using Arts.DataAccess.EntityFramework.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Arts.DataAccess.Migrations
{
    [DbContext(typeof(ArtDbContext))]
    partial class ArtDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Arts.Entity.Entity.Art.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("Born")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Died")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Arts.Entity.Entity.Art.ArtistArtwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("ArtworkId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("ArtworkId");

                    b.ToTable("ArtistArtworks");
                });

            modelBuilder.Entity("Arts.Entity.Entity.Art.Artwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Artworks");
                });

            modelBuilder.Entity("Arts.Entity.Entity.Login.LoginClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoginClaims");
                });

            modelBuilder.Entity("Arts.Entity.Entity.Login.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUserId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Arts.Entity.Entity.Login.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LoginClaimId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoginClaimId");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Arts.Entity.Entity.Art.ArtistArtwork", b =>
                {
                    b.HasOne("Arts.Entity.Entity.Art.Artist", "ArtistFk")
                        .WithMany("ArtistArtworks")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Arts.Entity.Entity.Art.Artwork", "ArtworkFk")
                        .WithMany("ArtistArtworks")
                        .HasForeignKey("ArtworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArtistFk");

                    b.Navigation("ArtworkFk");
                });

            modelBuilder.Entity("Arts.Entity.Entity.Login.UserClaim", b =>
                {
                    b.HasOne("Arts.Entity.Entity.Login.LoginClaim", "LoginClaimFk")
                        .WithMany("UserClaims")
                        .HasForeignKey("LoginClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Arts.Entity.Entity.Login.User", "UserFk")
                        .WithMany("UserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoginClaimFk");

                    b.Navigation("UserFk");
                });

            modelBuilder.Entity("Arts.Entity.Entity.Art.Artist", b =>
                {
                    b.Navigation("ArtistArtworks");
                });

            modelBuilder.Entity("Arts.Entity.Entity.Art.Artwork", b =>
                {
                    b.Navigation("ArtistArtworks");
                });

            modelBuilder.Entity("Arts.Entity.Entity.Login.LoginClaim", b =>
                {
                    b.Navigation("UserClaims");
                });

            modelBuilder.Entity("Arts.Entity.Entity.Login.User", b =>
                {
                    b.Navigation("UserClaims");
                });
#pragma warning restore 612, 618
        }
    }
}
