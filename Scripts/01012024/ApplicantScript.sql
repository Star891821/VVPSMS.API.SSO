USE [VVPSMS_SSO]
GO
DROP TABLE IF EXISTS  [dbo].[Applicants]

/****** Object:  Table [dbo].[Applicants]    Script Date: 01-01-2024 23:19:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Applicants](
	[applicant_id] [int] IDENTITY(1,1) NOT NULL,
	[applicantname] [nvarchar](255) NOT NULL,
	[applicantpassword] [nvarchar](255) NOT NULL,
	[applicant_givenName] [nvarchar](255) NOT NULL,
	[applicant_surname] [nvarchar](255) NOT NULL,
	[applicant_phone] [nvarchar](15) NULL,
	[role_id] [int] NOT NULL,
	[applicant_loginType] [nvarchar](255) NULL,
	[enforce2FA] [int] NOT NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[modified_at] [datetime] NULL,
	[modified_by] [int] NULL,
	[lastlogin_at] [datetime] NULL,
	[applicantemail] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[applicant_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Applicants] ADD  DEFAULT (getdate()) FOR [created_at]
GO

ALTER TABLE [dbo].[Applicants]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[MstUserRoles] ([role_id])
GO


