using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hwecosystemAPI.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDay = table.Column<int>(nullable: false),
                    CreatedMonth = table.Column<int>(nullable: false),
                    CreatedYear = table.Column<int>(nullable: false),
                    Base64String = table.Column<string>(nullable: true),
                    IsPhotographUploaded = table.Column<bool>(nullable: false),
                    Contibution = table.Column<double>(nullable: false),
                    RegistrationFee = table.Column<double>(nullable: false),
                    Contributor_Id = table.Column<Guid>(nullable: false),
                    CompanyShare = table.Column<double>(nullable: false),
                    UpLinersShare = table.Column<double>(nullable: false),
                    LogisticsShare = table.Column<double>(nullable: false),
                    SoftDevTechShare = table.Column<double>(nullable: false),
                    message = table.Column<string>(nullable: true),
                    reference = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    trans = table.Column<string>(nullable: true),
                    transactions = table.Column<string>(nullable: true),
                    trxref = table.Column<string>(nullable: true),
                    IsComfirmed = table.Column<bool>(nullable: false),
                    TypeOfStream = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDay = table.Column<int>(nullable: false),
                    CreatedMonth = table.Column<int>(nullable: false),
                    CreatedYear = table.Column<int>(nullable: false),
                    Base64String = table.Column<string>(nullable: true),
                    IsPhotographUploaded = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    UserType = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contributors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDay = table.Column<int>(nullable: false),
                    CreatedMonth = table.Column<int>(nullable: false),
                    CreatedYear = table.Column<int>(nullable: false),
                    Base64String = table.Column<string>(nullable: true),
                    IsPhotographUploaded = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    BirthDay = table.Column<int>(nullable: false),
                    BirthMonth = table.Column<int>(nullable: false),
                    BirthYear = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    ResidentialCity = table.Column<string>(nullable: true),
                    ResidentialState = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    BloodGroup = table.Column<string>(nullable: true),
                    Genotype = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<string>(nullable: true),
                    LGAOfOrigin = table.Column<string>(nullable: true),
                    StateOfOrigin = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    NOKNames = table.Column<string>(nullable: true),
                    NOKAddress = table.Column<string>(nullable: true),
                    NOKPhoneNumber = table.Column<string>(nullable: true),
                    NOKRelationship = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    AccountName = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    BVN = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserType = table.Column<string>(nullable: true),
                    ParentUserName = table.Column<string>(nullable: true),
                    nDescendants = table.Column<int>(nullable: false),
                    CurrentStream = table.Column<string>(nullable: true),
                    nChildren = table.Column<int>(nullable: false),
                    nGrandChildren = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cycles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDay = table.Column<int>(nullable: false),
                    CreatedMonth = table.Column<int>(nullable: false),
                    CreatedYear = table.Column<int>(nullable: false),
                    Base64String = table.Column<string>(nullable: true),
                    IsPhotographUploaded = table.Column<bool>(nullable: false),
                    Contributor_Id = table.Column<Guid>(nullable: false),
                    Cycle_Index = table.Column<int>(nullable: false),
                    IsThreshHoldReached = table.Column<bool>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    CycleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IsLogin = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UserType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDay = table.Column<int>(nullable: false),
                    CreatedMonth = table.Column<int>(nullable: false),
                    CreatedYear = table.Column<int>(nullable: false),
                    Base64String = table.Column<string>(nullable: true),
                    IsPhotographUploaded = table.Column<bool>(nullable: false),
                    CycleId = table.Column<Guid>(nullable: false),
                    Level_Index = table.Column<int>(nullable: false),
                    Desendants_Ids = table.Column<string>(nullable: true),
                    PaymentReceived = table.Column<double>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    LevelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PishonRefugeeCenters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDay = table.Column<int>(nullable: false),
                    CreatedMonth = table.Column<int>(nullable: false),
                    CreatedYear = table.Column<int>(nullable: false),
                    Base64String = table.Column<string>(nullable: true),
                    IsPhotographUploaded = table.Column<bool>(nullable: false),
                    contributorId = table.Column<Guid>(nullable: false),
                    contributorIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PishonRefugeeCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pishons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDay = table.Column<int>(nullable: false),
                    CreatedMonth = table.Column<int>(nullable: false),
                    CreatedYear = table.Column<int>(nullable: false),
                    Base64String = table.Column<string>(nullable: true),
                    IsPhotographUploaded = table.Column<bool>(nullable: false),
                    contributorId = table.Column<Guid>(nullable: false),
                    contributorIndex = table.Column<int>(nullable: false),
                    isLevelOneComplete = table.Column<bool>(nullable: false),
                    isLevelOneEntitlementPaid = table.Column<bool>(nullable: false),
                    isLevelTwoComplete = table.Column<bool>(nullable: false),
                    isLevelTwoEntitlementPaid = table.Column<bool>(nullable: false),
                    isLevelThreeComplete = table.Column<bool>(nullable: false),
                    isLevelThreeEntitlementPaid = table.Column<bool>(nullable: false),
                    isLevelFourComplete = table.Column<bool>(nullable: false),
                    isLevelFourEntitlementPaid = table.Column<bool>(nullable: false),
                    isLevelFiveComplete = table.Column<bool>(nullable: false),
                    isLevelFiveEntitlementPaid = table.Column<bool>(nullable: false),
                    isLevelSixComplete = table.Column<bool>(nullable: false),
                    isLevelSixEntitlementPaid = table.Column<bool>(nullable: false),
                    isLevelSevenComplete = table.Column<bool>(nullable: false),
                    isLevelSevenEntitlementPaid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pishons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefugeCenters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDay = table.Column<int>(nullable: false),
                    CreatedMonth = table.Column<int>(nullable: false),
                    CreatedYear = table.Column<int>(nullable: false),
                    Base64String = table.Column<string>(nullable: true),
                    IsPhotographUploaded = table.Column<bool>(nullable: false),
                    contributorId = table.Column<Guid>(nullable: false),
                    contributorIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefugeCenters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "Contributors");

            migrationBuilder.DropTable(
                name: "Cycles");

            migrationBuilder.DropTable(
                name: "IdentityModels");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "PishonRefugeeCenters");

            migrationBuilder.DropTable(
                name: "Pishons");

            migrationBuilder.DropTable(
                name: "RefugeCenters");
        }
    }
}
