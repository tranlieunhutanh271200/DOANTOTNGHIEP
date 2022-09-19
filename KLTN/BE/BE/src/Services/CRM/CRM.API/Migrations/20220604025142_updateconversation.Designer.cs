﻿// <auto-generated />
using System;
using CRM.API.Persistences;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRM.API.Migrations
{
    [DbContext(typeof(CRMDbContext))]
    [Migration("20220604025142_updateconversation")]
    partial class updateconversation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Service.Core.Models.CRM.Accessory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateIn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DomainId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accessories");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.AccessoryBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccessoryId");

                    b.HasIndex("TicketId")
                        .IsUnique();

                    b.ToTable("AccessoryBooks");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("AttendeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CallerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CheckAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.Conversation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("DomainId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HostFullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MemberFullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Conversations");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.MeetingAttendee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("AttendeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("JoinAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastLeaveAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LeaveAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MeetingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MeetingId");

                    b.ToTable("Attendees");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.Member", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProjectId", "AccountId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConversationId")
                        .HasColumnType("int");

                    b.Property<bool>("IsSeen")
                        .HasColumnType("bit");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.Notify", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Notifies");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.OnlineMeeting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LeaderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DomainId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLab")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalAirCondition")
                        .HasColumnType("int");

                    b.Property<int>("TotalSeat")
                        .HasColumnType("int");

                    b.Property<int>("TotalTV")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.RoomBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("DomainId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TicketId")
                        .IsUnique();

                    b.ToTable("RoomBooks");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.StudentAbsent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("DomainId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OffDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TicketId")
                        .IsUnique();

                    b.ToTable("StudentAbsents");
                });

            modelBuilder.Entity("Service.Core.Models.DTOs.CRM.StickyNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("XPosition")
                        .HasColumnType("int");

                    b.Property<int>("YPosition")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Service.Core.Models.LogWork.LogTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<DateTime>("LogAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("LogTasks");
                });

            modelBuilder.Entity("Service.Core.Models.LogWork.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssigneeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DoneAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SupervisorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TaskName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Service.Core.Models.Tickets.AttachedFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("AttachedFiles");
                });

            modelBuilder.Entity("Service.Core.Models.Tickets.ReferenceReceiver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("ReferenceReceivers");
                });

            modelBuilder.Entity("Service.Core.Models.Tickets.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHistory")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRoot")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OwnerClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerCurrentClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerFullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OwnerUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerYourClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RootId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SupervisorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TicketType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RootId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Service.Core.Models.Tickets.TicketComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketComments");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.AccessoryBook", b =>
                {
                    b.HasOne("Service.Core.Models.CRM.Accessory", "Accessory")
                        .WithMany("BookHistories")
                        .HasForeignKey("AccessoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Service.Core.Models.Tickets.Ticket", "Ticket")
                        .WithOne("AccessoryBook")
                        .HasForeignKey("Service.Core.Models.CRM.AccessoryBook", "TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accessory");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.MeetingAttendee", b =>
                {
                    b.HasOne("Service.Core.Models.CRM.OnlineMeeting", "Meeting")
                        .WithMany("Attendees")
                        .HasForeignKey("MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meeting");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.Member", b =>
                {
                    b.HasOne("Service.Core.Models.CRM.Project", "Project")
                        .WithMany("Members")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.Message", b =>
                {
                    b.HasOne("Service.Core.Models.CRM.Conversation", "Conversation")
                        .WithMany("Messages")
                        .HasForeignKey("ConversationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conversation");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.RoomBook", b =>
                {
                    b.HasOne("Service.Core.Models.Tickets.Ticket", "Ticket")
                        .WithOne("RoomBook")
                        .HasForeignKey("Service.Core.Models.CRM.RoomBook", "TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.StudentAbsent", b =>
                {
                    b.HasOne("Service.Core.Models.Tickets.Ticket", "Ticket")
                        .WithOne("StudentAbsent")
                        .HasForeignKey("Service.Core.Models.CRM.StudentAbsent", "TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Service.Core.Models.LogWork.LogTask", b =>
                {
                    b.HasOne("Service.Core.Models.LogWork.Task", "Task")
                        .WithMany("LogTasks")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("Service.Core.Models.LogWork.Task", b =>
                {
                    b.HasOne("Service.Core.Models.CRM.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Service.Core.Models.Tickets.AttachedFile", b =>
                {
                    b.HasOne("Service.Core.Models.Tickets.Ticket", "Ticket")
                        .WithMany("AttachedFiles")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Service.Core.Models.Tickets.ReferenceReceiver", b =>
                {
                    b.HasOne("Service.Core.Models.Tickets.Ticket", "Ticket")
                        .WithMany("ReferenceReceivers")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Service.Core.Models.Tickets.Ticket", b =>
                {
                    b.HasOne("Service.Core.Models.Tickets.Ticket", "Root")
                        .WithMany("Histories")
                        .HasForeignKey("RootId");

                    b.Navigation("Root");
                });

            modelBuilder.Entity("Service.Core.Models.Tickets.TicketComment", b =>
                {
                    b.HasOne("Service.Core.Models.Tickets.Ticket", "Ticket")
                        .WithMany("Comments")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.Accessory", b =>
                {
                    b.Navigation("BookHistories");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.Conversation", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.OnlineMeeting", b =>
                {
                    b.Navigation("Attendees");
                });

            modelBuilder.Entity("Service.Core.Models.CRM.Project", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Service.Core.Models.LogWork.Task", b =>
                {
                    b.Navigation("LogTasks");
                });

            modelBuilder.Entity("Service.Core.Models.Tickets.Ticket", b =>
                {
                    b.Navigation("AccessoryBook");

                    b.Navigation("AttachedFiles");

                    b.Navigation("Comments");

                    b.Navigation("Histories");

                    b.Navigation("ReferenceReceivers");

                    b.Navigation("RoomBook");

                    b.Navigation("StudentAbsent");
                });
#pragma warning restore 612, 618
        }
    }
}
