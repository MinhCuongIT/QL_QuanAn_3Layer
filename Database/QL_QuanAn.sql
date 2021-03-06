USE [QL_QuanAn]
GO
/****** Object:  Table [dbo].[QuanAn]    Script Date: 2019-05-25 11:08:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuanAn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Owner] [nvarchar](50) NULL,
	[Address] [nvarchar](150) NULL,
	[Phone] [varchar](12) NULL,
	[IsOpen] [bit] NULL,
 CONSTRAINT [PK_QuanAn] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[QuanAn] ON 

INSERT [dbo].[QuanAn] ([Id], [Name], [Owner], [Address], [Phone], [IsOpen]) VALUES (1, N'Đông Hà', N'Nguyễn Như Phương', N'36 Phạm Hồng Hải, Tam Kì, Hải Yên', N'0987673642', 1)
INSERT [dbo].[QuanAn] ([Id], [Name], [Owner], [Address], [Phone], [IsOpen]) VALUES (2, N'Nhà Hàng Hải Sản', N'Trần Bá Sơn', N'162 Phạm Thế Lữ, Cung Yên, TP.Huế', N'0984736273', 1)
INSERT [dbo].[QuanAn] ([Id], [Name], [Owner], [Address], [Phone], [IsOpen]) VALUES (3, N'Hải Yến', N'Trần Hải Yến', N'Long Khánh, Đồng Nai', N'0976636372', 0)
INSERT [dbo].[QuanAn] ([Id], [Name], [Owner], [Address], [Phone], [IsOpen]) VALUES (5, N'Hải Sản Tươi', N'Trần Hiếu Nghĩa', N'Cái Bè', N'093453452', 0)
INSERT [dbo].[QuanAn] ([Id], [Name], [Owner], [Address], [Phone], [IsOpen]) VALUES (6, N'Sóng Biến', N'Trần Ngọc Yến', N'Bình Phước', N'093453452', 1)
SET IDENTITY_INSERT [dbo].[QuanAn] OFF
