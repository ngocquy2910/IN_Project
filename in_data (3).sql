-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th10 28, 2021 lúc 08:41 PM
-- Phiên bản máy phục vụ: 10.4.17-MariaDB
-- Phiên bản PHP: 8.0.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `in_data`
--

DELIMITER $$
--
-- Các hàm
--
CREATE DEFINER=`root`@`localhost` FUNCTION `TongKhoaINT` () RETURNS INT(11) BEGIN
	DECLARE S INT DEFAULT 0;
    SELECT COUNT(MaKhoa) INTO S FROM khoa;
    RETURN S;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `TongPhongINT` () RETURNS INT(11) BEGIN
	DECLARE S INT DEFAULT 0;
    SELECT COUNT(MaPhong) INTO S FROM phong;
    RETURN S;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `bacsi`
--

CREATE TABLE `bacsi` (
  `MaBS` varchar(6) NOT NULL,
  `TenBS` varchar(255) NOT NULL,
  `MaKhoa` varchar(5) DEFAULT NULL,
  `Pass` int(11) NOT NULL,
  `SDT` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `bacsi`
--

INSERT INTO `bacsi` (`MaBS`, `TenBS`, `MaKhoa`, `Pass`, `SDT`) VALUES
('BS0001', 'Nguyễn Ngọc Quý', 'KH001', 12345, 12345678),
('BS0002', 'Nguyễn Thái Nghĩa', 'KH002', 12346, 123456790),
('BS0003', 'Hồ Hồng Hoàng', 'KH003', 12347, 798841460),
('BS0004', 'Nguyễn Thắng Thành', 'KH004', 12348, 337672033),
('BS0005', 'Nguyễn Trung Thành', 'KH005', 12349, 123456793),
('BS0006', 'Đặng Quang Huy', 'KH006', 12350, 123456794),
('BS0007', 'Nguyễn Thị Hồng Ngọc', 'KH007', 12351, 123456795),
('BS0008', 'Phạm Đức Tiến', 'KH001', 12352, 123456796),
('BS0009', 'Bùi Sĩ Phong', 'Kh002', 12353, 123456797),
('BS0010', 'Ngô Văn Hưng', 'KH003', 12354, 123456798);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `benhan`
--

CREATE TABLE `benhan` (
  `MaBA` varchar(6) NOT NULL,
  `MaBN` varchar(6) DEFAULT NULL,
  `MaBS` varchar(6) DEFAULT NULL,
  `ChuanDoanBenh` varchar(255) DEFAULT NULL,
  `NgayNhap` datetime NOT NULL,
  `NgayXuat` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `benhan`
--

INSERT INTO `benhan` (`MaBA`, `MaBN`, `MaBS`, `ChuanDoanBenh`, `NgayNhap`, `NgayXuat`) VALUES
('BA0001', 'BN0001', 'BS0001', 'Cao huyết áp', '2021-10-26 00:00:00', '2021-11-10 00:00:00'),
('BA0002', 'BN0002', 'BS0002', 'Thấp huyết áp', '2021-10-27 00:00:00', '2021-11-10 00:00:00'),
('BA0003', 'BN0003', 'BS0003', 'Sốt', '2021-10-28 00:00:00', '2021-11-10 00:00:00'),
('BA0004', 'BN0004', 'BS0004', 'Sốt', '2021-10-29 00:00:00', '2021-11-10 00:00:00'),
('BA0005', 'BN0005', 'BS0005', 'Sốt', '2021-10-30 00:00:00', '2021-11-10 00:00:00'),
('BA0006', 'BN0006', 'BS0006', 'Sốt', '2021-10-31 00:00:00', '2021-11-10 00:00:00'),
('BA0007', 'BN0007', 'BS0007', 'Thấp huyết áp', '2021-11-01 00:00:00', '2021-11-10 00:00:00'),
('BA0008', 'BN0008', 'BS0008', 'Cao huyết áp', '2021-11-02 00:00:00', '2021-11-10 00:00:00'),
('BA0009', 'BN0009', 'BS0009', 'Thấp huyết áp', '2021-11-03 00:00:00', '2021-11-10 00:00:00'),
('BA0010', 'BN0010', 'BS0010', 'Cao huyết áp', '2021-11-04 00:00:00', '2021-11-10 00:00:00');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `benhnhan`
--

CREATE TABLE `benhnhan` (
  `MaBN` varchar(6) NOT NULL,
  `TenBN` varchar(255) NOT NULL,
  `MaKhoa` varchar(5) DEFAULT NULL,
  `SDT` int(11) DEFAULT NULL,
  `DiaChi` varchar(255) DEFAULT NULL,
  `GioiTinh` int(11) DEFAULT NULL,
  `Tuoi` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `benhnhan`
--

INSERT INTO `benhnhan` (`MaBN`, `TenBN`, `MaKhoa`, `SDT`, `DiaChi`, `GioiTinh`, `Tuoi`) VALUES
('BN0001', 'Nguyễn Thái Nghĩa', 'KH001', 336379418, 'TP. Đà lạt Lâm Đồng', 1, 23),
('BN0002', 'Lê Trần Phú Thịnh', 'KH002', 917556289, 'TP. Đà lạt Lâm Đồng', 0, 30),
('BN0003', 'Vũ Chí Hùng', 'KH003', 865480543, 'TP. Đà lạt Lâm Đồng', 1, 23),
('BN0004', 'Nguyễn Hoàng Ngọc Giao', 'KH004', 333529013, 'TP. Đà lạt Lâm Đồng', 0, 11),
('BN0005', 'Nguyễn Phước Tuấn', 'KH005', 336379422, 'TP. Đà lạt Lâm Đồng', 1, 12),
('BN0006', 'Huỳnh Nguyễn Thùy Linh', 'KH006', 336379423, 'TP. Đà lạt Lâm Đồng', 0, 12),
('BN0007', 'Đàm Quang Huy', 'KH007', 336379424, 'TP. Đà lạt Lâm Đồng', 1, 11),
('BN0008', 'Thào A Vanh', 'KH001', 336379425, 'TP. Đà lạt Lâm Đồng', 0, 9),
('BN0009', 'Nguyễn Cẩm Tú', 'KH002', 336379426, 'TP. Đà lạt Lâm Đồng', 1, 79),
('BN0010', 'Nguyễn Chí Kiên', 'KH003', 336379427, 'TP. Đà lạt Lâm Đồng', 0, 60);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `benhvien`
--

CREATE TABLE `benhvien` (
  `MaBV` varchar(5) NOT NULL,
  `TenBV` varchar(255) NOT NULL,
  `SDT` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `benhvien`
--

INSERT INTO `benhvien` (`MaBV`, `TenBV`, `SDT`) VALUES
('BN001', 'Bệnh viện IN', 12345678);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `giuong`
--

CREATE TABLE `giuong` (
  `SoGiuong` varchar(6) NOT NULL,
  `MaBA` varchar(6) DEFAULT NULL,
  `MaPhong` varchar(6) NOT NULL,
  `TrangThai` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `giuong`
--

INSERT INTO `giuong` (`SoGiuong`, `MaBA`, `MaPhong`, `TrangThai`) VALUES
('SG0001', 'BA0001', 'MP0001', '1'),
('SG0002', NULL, 'MP0001', '0'),
('SG0003', NULL, 'MP0001', '0'),
('SG0004', NULL, 'MP0001', '0'),
('SG0005', 'BA0002', 'MP0001', '1'),
('SG0006', NULL, 'MP0001', '0'),
('SG0007', NULL, 'MP0001', '0'),
('SG0008', NULL, 'MP0001', '0'),
('SG0009', NULL, 'MP0001', '0'),
('SG0010', NULL, 'MP0001', '0'),
('SG0011', NULL, 'MP0001', '0'),
('SG0012', NULL, 'MP0001', '0'),
('SG0013', NULL, 'MP0001', '0'),
('SG0014', NULL, 'MP0001', '0'),
('SG0015', NULL, 'MP0001', '0'),
('SG0016', NULL, 'MP0001', '0'),
('SG0017', NULL, 'MP0001', '0'),
('SG0018', 'BA0003', 'MP0001', '1'),
('SG0019', NULL, 'MP0001', '0'),
('SG0020', NULL, 'MP0001', '0');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `goiythuoc`
--

CREATE TABLE `goiythuoc` (
  `MaBenhNhan` varchar(6) DEFAULT NULL,
  `MaBenhAn` varchar(6) DEFAULT NULL,
  `Thuoc` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `khoa`
--

CREATE TABLE `khoa` (
  `MaKhoa` varchar(5) NOT NULL,
  `TenKhoa` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `khoa`
--

INSERT INTO `khoa` (`MaKhoa`, `TenKhoa`) VALUES
('KH001', 'Emergency department'),
('KH002', 'Internal medicine department'),
('KH003', 'Surgery'),
('KH004', 'Genenal Medical'),
('KH005', 'AI Medicine'),
('KH006', 'Statistics of hospital beds'),
('Kh007', 'Patient follow-up');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phong`
--

CREATE TABLE `phong` (
  `MaPhong` varchar(6) NOT NULL,
  `MaKhoa` varchar(5) DEFAULT NULL,
  `TenPhong` varchar(255) NOT NULL,
  `TongSoGiuong` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `phong`
--

INSERT INTO `phong` (`MaPhong`, `MaKhoa`, `TenPhong`, `TongSoGiuong`) VALUES
('MP0001', 'KH001', 'Phòng A1', 20),
('MP0002', 'KH002', 'Phòng B1', 25),
('MP0003', 'KH003', 'Phòng C1', 25),
('MP0004', 'KH007', 'Phòng Patient follow-up', 30);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `thongsosuckhoe`
--

CREATE TABLE `thongsosuckhoe` (
  `MaBN` varchar(6) NOT NULL,
  `NhietDo` float NOT NULL,
  `NhipTim` int(11) NOT NULL,
  `NongDoOxy` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Đang đổ dữ liệu cho bảng `thongsosuckhoe`
--

INSERT INTO `thongsosuckhoe` (`MaBN`, `NhietDo`, `NhipTim`, `NongDoOxy`) VALUES
('BN0001', 38.1, 120, 97),
('BN0002', 38.2, 60, 98),
('BN0003', 38.1, 75, 95),
('BN0004', 38.2, 75, 95),
('BN0005', 38.2, 70, 94),
('BN0006', 38.1, 80, 93),
('BN0007', 38.2, 60, 92),
('BN0008', 38.1, 150, 91),
('BN0009', 38.2, 50, 98),
('BN0010', 38.2, 130, 98);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tinnhan`
--

CREATE TABLE `tinnhan` (
  `MaTN` varchar(6) NOT NULL,
  `MaBS` varchar(6) DEFAULT NULL,
  `MaKhoa` varchar(5) DEFAULT NULL,
  `NoiDung` varchar(255) DEFAULT NULL,
  `ThoiGian` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `bacsi`
--
ALTER TABLE `bacsi`
  ADD PRIMARY KEY (`MaBS`),
  ADD KEY `BacSi_MaKhoa` (`MaKhoa`);

--
-- Chỉ mục cho bảng `benhan`
--
ALTER TABLE `benhan`
  ADD PRIMARY KEY (`MaBA`),
  ADD KEY `BA_BN` (`MaBN`),
  ADD KEY `BA_BS` (`MaBS`);

--
-- Chỉ mục cho bảng `benhnhan`
--
ALTER TABLE `benhnhan`
  ADD PRIMARY KEY (`MaBN`),
  ADD KEY `BN_KHOA` (`MaKhoa`);

--
-- Chỉ mục cho bảng `benhvien`
--
ALTER TABLE `benhvien`
  ADD PRIMARY KEY (`MaBV`);

--
-- Chỉ mục cho bảng `giuong`
--
ALTER TABLE `giuong`
  ADD PRIMARY KEY (`SoGiuong`),
  ADD KEY `Giương_BA` (`MaBA`),
  ADD KEY `SG_MP` (`MaPhong`);

--
-- Chỉ mục cho bảng `goiythuoc`
--
ALTER TABLE `goiythuoc`
  ADD KEY `T_MBN` (`MaBenhNhan`),
  ADD KEY `T_MBA` (`MaBenhAn`);

--
-- Chỉ mục cho bảng `khoa`
--
ALTER TABLE `khoa`
  ADD PRIMARY KEY (`MaKhoa`);

--
-- Chỉ mục cho bảng `phong`
--
ALTER TABLE `phong`
  ADD PRIMARY KEY (`MaPhong`),
  ADD KEY `Phong_Khoa` (`MaKhoa`);

--
-- Chỉ mục cho bảng `thongsosuckhoe`
--
ALTER TABLE `thongsosuckhoe`
  ADD KEY `TTSK_BN` (`MaBN`);

--
-- Chỉ mục cho bảng `tinnhan`
--
ALTER TABLE `tinnhan`
  ADD PRIMARY KEY (`MaTN`),
  ADD KEY `TN_BS` (`MaBS`),
  ADD KEY `T_KHOA` (`MaKhoa`);

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `bacsi`
--
ALTER TABLE `bacsi`
  ADD CONSTRAINT `BacSi_MaKhoa` FOREIGN KEY (`MaKhoa`) REFERENCES `khoa` (`MaKhoa`);

--
-- Các ràng buộc cho bảng `benhan`
--
ALTER TABLE `benhan`
  ADD CONSTRAINT `BA_BS` FOREIGN KEY (`MaBS`) REFERENCES `bacsi` (`MaBS`);

--
-- Các ràng buộc cho bảng `benhnhan`
--
ALTER TABLE `benhnhan`
  ADD CONSTRAINT `BN_KHOA` FOREIGN KEY (`MaKhoa`) REFERENCES `khoa` (`MaKhoa`);

--
-- Các ràng buộc cho bảng `giuong`
--
ALTER TABLE `giuong`
  ADD CONSTRAINT `Giương_BA` FOREIGN KEY (`MaBA`) REFERENCES `benhan` (`MaBA`),
  ADD CONSTRAINT `SG_MP` FOREIGN KEY (`MaPhong`) REFERENCES `phong` (`MaPhong`);

--
-- Các ràng buộc cho bảng `goiythuoc`
--
ALTER TABLE `goiythuoc`
  ADD CONSTRAINT `T_MBA` FOREIGN KEY (`MaBenhAn`) REFERENCES `benhan` (`MaBA`),
  ADD CONSTRAINT `T_MBN` FOREIGN KEY (`MaBenhNhan`) REFERENCES `benhnhan` (`MaBN`);

--
-- Các ràng buộc cho bảng `phong`
--
ALTER TABLE `phong`
  ADD CONSTRAINT `Phong_Khoa` FOREIGN KEY (`MaKhoa`) REFERENCES `khoa` (`MaKhoa`);

--
-- Các ràng buộc cho bảng `thongsosuckhoe`
--
ALTER TABLE `thongsosuckhoe`
  ADD CONSTRAINT `TTSK_BN` FOREIGN KEY (`MaBN`) REFERENCES `benhnhan` (`MaBN`);

--
-- Các ràng buộc cho bảng `tinnhan`
--
ALTER TABLE `tinnhan`
  ADD CONSTRAINT `TN_BS` FOREIGN KEY (`MaBS`) REFERENCES `bacsi` (`MaBS`),
  ADD CONSTRAINT `T_KHOA` FOREIGN KEY (`MaKhoa`) REFERENCES `khoa` (`MaKhoa`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
