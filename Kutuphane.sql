USE [Kutuphane]
GO
/****** Object:  Table [dbo].[Kitaplar]    Script Date: 03.09.2020 19:23:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kitaplar](
	[kitapId] [int] NOT NULL,
	[kitapAdi] [varchar](50) NULL,
	[yazar] [varchar](50) NULL,
	[baskiYili] [varchar](50) NULL,
	[sayfaSayisi] [varchar](50) NULL,
	[yayınEvi] [varchar](50) NULL,
	[notlar] [varchar](50) NULL,
 CONSTRAINT [PK_Kitaplar] PRIMARY KEY CLUSTERED 
(
	[kitapId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OduncKitap]    Script Date: 03.09.2020 19:23:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OduncKitap](
	[emanetId] [int] NULL,
	[uyeNo] [int] NULL,
	[kitapId] [int] NULL,
	[emanetTarihi] [varchar](50) NULL,
	[gerialınacakTarih] [varchar](50) NULL,
	[islemTarih] [varchar](50) NULL,
	[notlar] [varchar](50) NULL,
	[teslimEdildi] [varchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personel]    Script Date: 03.09.2020 19:23:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personel](
	[perNo] [int] NOT NULL,
	[perAdi] [varchar](50) NULL,
	[perSoyad] [varchar](50) NULL,
	[perKullaniciadi] [varchar](50) NULL,
	[sifre] [varchar](50) NULL,
	[eposta] [varchar](50) NULL,
	[gorevi] [nvarchar](50) NULL,
 CONSTRAINT [PK_Personel] PRIMARY KEY CLUSTERED 
(
	[perNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uyeler]    Script Date: 03.09.2020 19:23:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uyeler](
	[uyeNo] [int] NOT NULL,
	[uyeAdi] [varchar](50) NULL,
	[uyeSoyad] [varchar](50) NULL,
	[uyeTel] [varchar](50) NULL,
	[uyePosta] [varchar](50) NULL,
	[uyeAdres] [varchar](50) NULL,
 CONSTRAINT [PK_Uyeler] PRIMARY KEY CLUSTERED 
(
	[uyeNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
