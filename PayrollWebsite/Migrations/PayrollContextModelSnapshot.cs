﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PayrollWebsite.Model;
using System;

namespace PayrollWebsite.Migrations
{
    [DbContext(typeof(PayrollContext))]
    partial class PayrollContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PayrollWebsite.Model.Employee", b =>
                {
                    b.Property<int>("EmployeeId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("PayrollWebsite.Model.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("HourlyRate");

                    b.Property<string>("JobCode");

                    b.HasKey("JobId");

                    b.HasIndex("JobCode")
                        .IsUnique()
                        .HasFilter("[JobCode] IS NOT NULL");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("PayrollWebsite.Model.Payroll", b =>
                {
                    b.Property<int>("PayrollId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime>("StopDate");

                    b.HasKey("PayrollId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Payroll");
                });

            modelBuilder.Entity("PayrollWebsite.Model.Report", b =>
                {
                    b.Property<int>("ReportId");

                    b.HasKey("ReportId");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("PayrollWebsite.Model.Timesheet", b =>
                {
                    b.Property<int>("TimesheetId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("EmployeeId");

                    b.Property<decimal>("HoursWorked");

                    b.Property<int>("JobId");

                    b.Property<int>("ReportId");

                    b.HasKey("TimesheetId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("JobId");

                    b.HasIndex("ReportId");

                    b.ToTable("Timesheet");
                });

            modelBuilder.Entity("PayrollWebsite.Model.Payroll", b =>
                {
                    b.HasOne("PayrollWebsite.Model.Employee", "Employee")
                        .WithMany("Payrolls")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollWebsite.Model.Timesheet", b =>
                {
                    b.HasOne("PayrollWebsite.Model.Employee", "Employee")
                        .WithMany("Timesheets")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollWebsite.Model.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollWebsite.Model.Report", "Report")
                        .WithMany("Timesheets")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
