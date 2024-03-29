﻿// <auto-generated />
using System;
using CarsCrete.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarsCrete.Data.Migrations
{
    [DbContext(typeof(CarsDbContext))]
    [Migration("20181121155959_AC")]
    partial class AC
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarsCrete.Data.Models.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CarId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("DateFinish");

                    b.Property<DateTime>("DateStart");

                    b.Property<string>("Place")
                        .IsRequired();

                    b.Property<double>("Price");

                    b.Property<long>("SalesId");

                    b.Property<double>("Sum");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("CarsCrete.Data.Models.Car", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AC");

                    b.Property<string>("BodyType")
                        .IsRequired();

                    b.Property<int>("Consumption");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Description_ENG")
                        .IsRequired();

                    b.Property<int>("Doors");

                    b.Property<int>("FilterProp");

                    b.Property<string>("Fuel")
                        .IsRequired();

                    b.Property<int>("Mark");

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<int>("Passengers");

                    b.Property<string>("Photo")
                        .IsRequired();

                    b.Property<double>("Price");

                    b.Property<string>("Transmission")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarsCrete.Data.Models.FeedBack", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CarId");

                    b.Property<double>("Comfort");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<double>("Drive");

                    b.Property<double>("Look");

                    b.Property<double>("Mark");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("FeedBack");
                });

            modelBuilder.Entity("CarsCrete.Data.Models.Like", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CommentId");

                    b.Property<long>("FeedBackId");

                    b.Property<bool>("IsLike");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("FeedBackId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("CarsCrete.Data.Models.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<long>("TopicId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("CarsCrete.Data.Models.ReportComment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("FeedBackId");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("FeedBackId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CarsCrete.Data.Models.Sale", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CarId");

                    b.Property<DateTime>("DateFinish");

                    b.Property<DateTime>("DateStart");

                    b.Property<int>("DaysNumber");

                    b.Property<double>("Discount");

                    b.Property<double>("NewPrice");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("CarsCrete.Data.Models.Topic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ModifyDate");

                    b.Property<bool>("Seen");

                    b.Property<long>("UserId");

                    b.Property<long>("UserReciverId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("CarsCrete.Data.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Lang");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<string>("Photo");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarsCrete.Data.Models.Book", b =>
                {
                    b.HasOne("CarsCrete.Data.Models.Car", "Car")
                        .WithMany("Books")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarsCrete.Data.Models.User", "User")
                        .WithMany("Books")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarsCrete.Data.Models.FeedBack", b =>
                {
                    b.HasOne("CarsCrete.Data.Models.Car", "Car")
                        .WithMany("Reports")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarsCrete.Data.Models.User", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarsCrete.Data.Models.Like", b =>
                {
                    b.HasOne("CarsCrete.Data.Models.FeedBack")
                        .WithMany("Likes")
                        .HasForeignKey("FeedBackId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarsCrete.Data.Models.Message", b =>
                {
                    b.HasOne("CarsCrete.Data.Models.Topic")
                        .WithMany("Messages")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarsCrete.Data.Models.ReportComment", b =>
                {
                    b.HasOne("CarsCrete.Data.Models.FeedBack")
                        .WithMany("Comments")
                        .HasForeignKey("FeedBackId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CarsCrete.Data.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarsCrete.Data.Models.Sale", b =>
                {
                    b.HasOne("CarsCrete.Data.Models.Car", "Car")
                        .WithMany("Sales")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CarsCrete.Data.Models.Topic", b =>
                {
                    b.HasOne("CarsCrete.Data.Models.User")
                        .WithMany("Topics")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
