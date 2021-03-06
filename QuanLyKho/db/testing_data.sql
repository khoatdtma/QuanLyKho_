USE [Quan_ly_kho]
GO
SET IDENTITY_INSERT [dbo].[Unit] ON 

INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (1, N'kg')
INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (2, N'thung')
INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (3, N'bao')
SET IDENTITY_INSERT [dbo].[Unit] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([Id], [Displayname], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (1, N'supplier_1', N'hcm', N'123123123', N's1@gmail.com', NULL, NULL)
INSERT [dbo].[Supplier] ([Id], [Displayname], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (2, N'sup_2', N'hn', N'234234234', N's2@gmail.com', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
INSERT [dbo].[Product] ([Id], [DisplayName], [IdUnit], [IdSupplier], [QRCode], [Barcode]) VALUES (N'1', N'xi mang', 3, 1, N'ximang111', N'ximang111')
INSERT [dbo].[Product] ([Id], [DisplayName], [IdUnit], [IdSupplier], [QRCode], [Barcode]) VALUES (N'2', N'gach', 2, 2, N'gach222', N'gach222')
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Displayname], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (1, N'customer 1', N'binhduong', N'345345345', N'cus11@gmail.com', NULL, NULL)
INSERT [dbo].[Customer] ([Id], [Displayname], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (2, N'customer 2', N'dongnai', N'567567567', N'cus2@gmail.com', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
INSERT [dbo].[Outputs] ([Id], [OutputDate]) VALUES (N'1', CAST(N'2021-12-23T23:23:23.000' AS DateTime))
INSERT [dbo].[Outputs] ([Id], [OutputDate]) VALUES (N'2', CAST(N'2021-12-23T12:12:12.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[OutputInfo] ON 

INSERT [dbo].[OutputInfo] ([Id], [IdProduct], [IdOutput], [IdCustomer], [Count], [Status]) VALUES (1, N'1', N'1', 1, 200, NULL)
INSERT [dbo].[OutputInfo] ([Id], [IdProduct], [IdOutput], [IdCustomer], [Count], [Status]) VALUES (2, N'2', N'1', 2, 120, NULL)
SET IDENTITY_INSERT [dbo].[OutputInfo] OFF
GO
INSERT [dbo].[Input] ([Id], [InputDate]) VALUES (N'1', CAST(N'2021-12-03T14:20:30.000' AS DateTime))
INSERT [dbo].[Input] ([Id], [InputDate]) VALUES (N'2', CAST(N'2021-12-03T15:20:30.000' AS DateTime))
GO
INSERT [dbo].[InputInfo] ([Id], [IdProduct], [IdInput], [Count], [InputPrice], [OutputPrice], [Status]) VALUES (N'1', N'1', N'1', 500, 250000, 400000, N'new')
INSERT [dbo].[InputInfo] ([Id], [IdProduct], [IdInput], [Count], [InputPrice], [OutputPrice], [Status]) VALUES (N'2', N'2', N'2', 800, 150000, 300000, N'new')
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (1, N'admin')
INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (2, N'staff')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [DisplayName], [Username], [Password], [IdRole]) VALUES (1, N'KhoaTD', N'admin', N'db69fc039dcbd2962cb4d28f5891aae1', 1)
INSERT [dbo].[Users] ([Id], [DisplayName], [Username], [Password], [IdRole]) VALUES (2, N'staff', N'staff', N'978aae9bb6bee8fb75de3e4830a1be46', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
