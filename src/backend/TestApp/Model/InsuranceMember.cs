using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Model
{
	public class InsuranceMember
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; } // Primary key with auto-increment

		[Required]
		[MaxLength(100)]
		public string FirstName { get; set; } // Member's first name

		[Required]
		[MaxLength(100)]
		public string LastName { get; set; } // Member's last name

		[Required]
		[MaxLength(100)]
		public string Address1 { get; set; } // Member's primary address line

		[MaxLength(100)]
		public string? Address2 { get; set; } // Member's secondary address line (optional)

		[Required]
		[MaxLength(100)]
		public string City { get; set; } // Member's city

		[Required]
		[MaxLength(50)]
		public string State { get; set; } // Member's state

		[Required]
		[MaxLength(20)]
		public string Zip { get; set; } // Member's zip code

		[Required]
		[MaxLength(50)]
		public string PhoneNumber { get; set; } // Member's phone number

		[Required]
		[EmailAddress]
		public string Email { get; set; } // Member's email address

		[Required]
		[MaxLength(100)]
		public string MemberPlan { get; set; } // Member's insurance plan

		[Required]
		public DateTime DateOfBirth { get; set; } // Member's date of birth

		[Required]
		public DateTime PolicyStartDate { get; set; } // Policy start date

		[Required]
		public DateTime PolicyEndDate { get; set; } // Policy end date
	}
}

//dotnet ef migrations add InitialCreate
//dotnet ef database update

//Populate 100k records
//--Create temporary tables for first names, last names, and cities
//CREATE TABLE #FirstNames (FirstName NVARCHAR(100));
//INSERT INTO #FirstNames VALUES
//    ('John'), ('Jane'), ('Michael'), ('Emily'), ('David'),
//    ('Sarah'), ('Chris'), ('Emma'), ('James'), ('Olivia');

//CREATE TABLE #LastNames (LastName NVARCHAR(100));
//INSERT INTO #LastNames VALUES
//    ('Smith'), ('Johnson'), ('Brown'), ('Taylor'), ('Anderson'),
//    ('Lee'), ('Martin'), ('Garcia'), ('Clark'), ('Rodriguez');

//CREATE TABLE #Cities (City NVARCHAR(100));
//INSERT INTO #Cities VALUES
//    ('New York'), ('Los Angeles'), ('Chicago'), ('Houston'), ('Phoenix'),
//    ('Philadelphia'), ('San Antonio'), ('San Diego'), ('Dallas'), ('San Jose');

//CREATE TABLE #States (State NVARCHAR(50));
//INSERT INTO #States VALUES
//    ('NY'), ('CA'), ('TX'), ('IL'), ('AZ'),
//    ('PA'), ('FL'), ('OH'), ('MI'), ('CO');

//--Enable optimizations for large inserts
//SET NOCOUNT ON;

//DECLARE @i INT = 1;

//--Generate 100,000 random records
//WHILE @i <= 100000
//BEGIN
//    INSERT INTO InsuranceMembers (
//        FirstName, LastName, Address1, Address2, City, State, Zip,
//		PhoneNumber, Email, MemberPlan, DateOfBirth, PolicyStartDate, PolicyEndDate
//    )
//    VALUES (
//        (SELECT TOP 1 FirstName FROM #FirstNames ORDER BY NEWID()), -- Random First Name
//        (SELECT TOP 1 LastName FROM #LastNames ORDER BY NEWID()),   -- Random Last Name
//        CONCAT(ABS(CHECKSUM(NEWID())) % 1000, ' ', (SELECT TOP 1 City FROM #Cities ORDER BY NEWID())), -- Address1 with City
//        CASE WHEN RAND() < 0.5 THEN NULL ELSE CONCAT('Apt ', ABS(CHECKSUM(NEWID())) % 1000) END, --Address2 is optional(Apt number)

//		(SELECT TOP 1 City FROM #Cities ORDER BY NEWID()),           -- Random City
//        (SELECT TOP 1 State FROM #States ORDER BY NEWID()),         -- Random State
//        RIGHT('00000' + CAST(ABS(CHECKSUM(NEWID())) % 90000 + 10000 AS NVARCHAR(5)), 5), --Correctly formatted Zip Code(5 digits)

//		CONCAT('555-', FORMAT(ABS(CHECKSUM(NEWID())), '0000000')), --Random unique phone number

//		CONCAT(NEWID(), '@example.com'), --Random Email using NEWID

//		CASE(ABS(CHECKSUM(NEWID())) % 5) + 1-- Random Member Plan
//            WHEN 1 THEN 'Basic'
//            WHEN 2 THEN 'Silver'
//            WHEN 3 THEN 'Gold'
//            WHEN 4 THEN 'Platinum'
//            ELSE 'Diamond'
//        END,
//		DATEADD(YEAR, -ABS(CHECKSUM(NEWID()) % 70) - 18, GETDATE()), -- Random Date of Birth (between 18 and 70 years ago)
//        DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 3650) * -1, GETDATE()), -- Random Policy Start Date (within the last 10 years)
//        DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 730), GETDATE())        -- Random Policy End Date (up to 2 years after the start)
//    );

//SET @i = @i + 1;
//END;

//--Clean up temporary tables
//DROP TABLE #FirstNames;
//DROP TABLE #LastNames;
//DROP TABLE #Cities;
//DROP TABLE #States;

//PRINT '100,000 records inserted successfully!';