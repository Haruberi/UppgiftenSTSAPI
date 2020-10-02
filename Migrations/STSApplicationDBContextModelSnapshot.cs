﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UppgiftenSTSAPI.Context;

namespace UppgiftenSTSAPI.Migrations
{
    [DbContext(typeof(STSApplicationDBContext))]
    partial class STSApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UppgiftenSTSAPI.Context.Paymentmethod", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("paymentmethodname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("paymentmethods");
                });

            modelBuilder.Entity("UppgiftenSTSAPI.Context.Seminar", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SeminarOfPaymentmethodId")
                        .HasColumnType("int");

                    b.Property<string>("seminarname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("SeminarOfPaymentmethodId")
                        .IsUnique();

                    b.ToTable("seminars");
                });

            modelBuilder.Entity("UppgiftenSTSAPI.Context.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("currentDormId")
                        .HasColumnType("int");

                    b.Property<string>("mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("currentDormId");

                    b.ToTable("students");
                });

            modelBuilder.Entity("UppgiftenSTSAPI.Entities.Dorm", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("dorms");
                });

            modelBuilder.Entity("UppgiftenSTSAPI.Entities.StudentSeminar", b =>
                {
                    b.Property<int>("studentId")
                        .HasColumnType("int");

                    b.Property<int>("seminarId")
                        .HasColumnType("int");

                    b.HasKey("studentId", "seminarId");

                    b.HasIndex("seminarId");

                    b.ToTable("studentSeminars");
                });

            modelBuilder.Entity("UppgiftenSTSAPI.Context.Seminar", b =>
                {
                    b.HasOne("UppgiftenSTSAPI.Context.Paymentmethod", "Paymentmethod")
                        .WithOne("seminar")
                        .HasForeignKey("UppgiftenSTSAPI.Context.Seminar", "SeminarOfPaymentmethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UppgiftenSTSAPI.Context.Student", b =>
                {
                    b.HasOne("UppgiftenSTSAPI.Entities.Dorm", "dorm")
                        .WithMany("students")
                        .HasForeignKey("currentDormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UppgiftenSTSAPI.Entities.StudentSeminar", b =>
                {
                    b.HasOne("UppgiftenSTSAPI.Context.Seminar", "seminar")
                        .WithMany("studentSeminars")
                        .HasForeignKey("seminarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UppgiftenSTSAPI.Context.Student", "student")
                        .WithMany("studentseminars")
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
