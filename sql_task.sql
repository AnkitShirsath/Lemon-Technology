USE [Ankit_Task]
GO
/****** Object:  Table [dbo].[comman_fruit_veg]    Script Date: 21/10/2023 18:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comman_fruit_veg](
	[fv] [int] IDENTITY(1,1) NOT NULL,
	[Fruit_id] [int] NULL,
	[veg_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[fv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fruits_tbl]    Script Date: 21/10/2023 18:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fruits_tbl](
	[Fruit_id] [int] IDENTITY(1,1) NOT NULL,
	[Fruit_name] [nvarchar](max) NOT NULL,
	[veg_Id] [int] NULL,
	[Start_Date] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_fruits_tbl] PRIMARY KEY CLUSTERED 
(
	[Fruit_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vegerables_tbl]    Script Date: 21/10/2023 18:37:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vegerables_tbl](
	[veg_Id] [int] IDENTITY(1,1) NOT NULL,
	[veg_Name] [nvarchar](max) NOT NULL,
	[Fruit_id] [int] NULL,
 CONSTRAINT [PK_vegerables_tbl] PRIMARY KEY CLUSTERED 
(
	[veg_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[comman_fruit_veg] ON 

INSERT [dbo].[comman_fruit_veg] ([fv], [Fruit_id], [veg_Id]) VALUES (1, 2, 1)
SET IDENTITY_INSERT [dbo].[comman_fruit_veg] OFF
GO
SET IDENTITY_INSERT [dbo].[fruits_tbl] ON 

INSERT [dbo].[fruits_tbl] ([Fruit_id], [Fruit_name], [veg_Id], [Start_Date], [IsActive]) VALUES (2, N'Apple', 3, NULL, NULL)
INSERT [dbo].[fruits_tbl] ([Fruit_id], [Fruit_name], [veg_Id], [Start_Date], [IsActive]) VALUES (5, N'Mango', 3, NULL, NULL)
INSERT [dbo].[fruits_tbl] ([Fruit_id], [Fruit_name], [veg_Id], [Start_Date], [IsActive]) VALUES (8, N'Graps', 3, NULL, NULL)
INSERT [dbo].[fruits_tbl] ([Fruit_id], [Fruit_name], [veg_Id], [Start_Date], [IsActive]) VALUES (14, N'Mango', 4, NULL, NULL)
INSERT [dbo].[fruits_tbl] ([Fruit_id], [Fruit_name], [veg_Id], [Start_Date], [IsActive]) VALUES (15, N'Banana', 5, NULL, NULL)
INSERT [dbo].[fruits_tbl] ([Fruit_id], [Fruit_name], [veg_Id], [Start_Date], [IsActive]) VALUES (18, N'Orange', 4, NULL, NULL)
INSERT [dbo].[fruits_tbl] ([Fruit_id], [Fruit_name], [veg_Id], [Start_Date], [IsActive]) VALUES (21, N'Banana', 4, NULL, NULL)
SET IDENTITY_INSERT [dbo].[fruits_tbl] OFF
GO
SET IDENTITY_INSERT [dbo].[vegerables_tbl] ON 

INSERT [dbo].[vegerables_tbl] ([veg_Id], [veg_Name], [Fruit_id]) VALUES (1, N'Select', 5)
INSERT [dbo].[vegerables_tbl] ([veg_Id], [veg_Name], [Fruit_id]) VALUES (2, N'Potato', NULL)
INSERT [dbo].[vegerables_tbl] ([veg_Id], [veg_Name], [Fruit_id]) VALUES (3, N'Salaed', NULL)
INSERT [dbo].[vegerables_tbl] ([veg_Id], [veg_Name], [Fruit_id]) VALUES (4, N'Mashroom', 2)
INSERT [dbo].[vegerables_tbl] ([veg_Id], [veg_Name], [Fruit_id]) VALUES (5, N'Tamota', 5)
INSERT [dbo].[vegerables_tbl] ([veg_Id], [veg_Name], [Fruit_id]) VALUES (6, N'Ledy Finger', 8)
INSERT [dbo].[vegerables_tbl] ([veg_Id], [veg_Name], [Fruit_id]) VALUES (7, N'Kareka', 8)
SET IDENTITY_INSERT [dbo].[vegerables_tbl] OFF
GO
ALTER TABLE [dbo].[comman_fruit_veg]  WITH CHECK ADD FOREIGN KEY([Fruit_id])
REFERENCES [dbo].[fruits_tbl] ([Fruit_id])
GO
ALTER TABLE [dbo].[comman_fruit_veg]  WITH CHECK ADD FOREIGN KEY([veg_Id])
REFERENCES [dbo].[vegerables_tbl] ([veg_Id])
GO
ALTER TABLE [dbo].[fruits_tbl]  WITH CHECK ADD  CONSTRAINT [FK_fruits_tbl_vegerables_tbl_veg_Id] FOREIGN KEY([veg_Id])
REFERENCES [dbo].[vegerables_tbl] ([veg_Id])
GO
ALTER TABLE [dbo].[fruits_tbl] CHECK CONSTRAINT [FK_fruits_tbl_vegerables_tbl_veg_Id]
GO
ALTER TABLE [dbo].[vegerables_tbl]  WITH CHECK ADD FOREIGN KEY([Fruit_id])
REFERENCES [dbo].[fruits_tbl] ([Fruit_id])
GO
