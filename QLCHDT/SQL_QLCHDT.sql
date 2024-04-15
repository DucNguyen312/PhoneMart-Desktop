create database QLCHDT
go
use QLCHDT
go

create table ThuongHieu ( 
	MaTH varchar(20) primary key,
	TenTH nvarchar(50)
)

create table SanPham(
	MaSP varchar(10) primary key,
	TenSP nvarchar(70),
	Gia int,
	MotaSP nvarchar(MAX),
	MaTH varchar(20)
	CONSTRAINT fk_ThongTinSP_ThuongHieu FOREIGN KEY (MaTH) REFERENCES ThuongHieu (MaTH) on delete cascade on update cascade
)

create table NhanVien(
	MaNV varchar(10) primary key,
	MkNV varchar(30),
	TenNV nvarchar(50),
	NgaySinh date,
	GioiTinh bit,
	DiaChi nvarchar(200),
	SDT varchar(30),
	chucvu nvarchar(10)
)

create table GioHang(
	MaGH varchar(10) primary key,
	NgayBan datetime,
	TongSoLuong int,
	TongTien int,
)

create table SPMua(
	Stt int,
	SoLuong int,
	MaGH varchar(10),
	MaSP varchar(10)
	CONSTRAINT fk_MuaHang_GioHang FOREIGN KEY (MaGH) REFERENCES GioHang (MaGH) on delete cascade on update cascade,
	CONSTRAINT fk_MuaHang_SanPham FOREIGN KEY (MaSP) REFERENCES SanPham (MaSP) on delete cascade on update cascade
)


create table KhachHang(
	MaKH varchar(10) primary key,
	TenKH nvarchar(50),
	DiaChi nvarchar(200),
	SDT char(30)
)
create table HoaDon (
	MaHD varchar(10) primary key,
	MaGH varchar(10),
	MaNV varchar(10),
	MaKH varchar(10),
	TrangThai nvarchar(30),
	CONSTRAINT fk_HoaDon_GioHang FOREIGN KEY (MaGH) REFERENCES GioHang (MaGH) on delete cascade on update cascade,
	CONSTRAINT fk_HoaDon_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien (MaNV) on delete cascade on update cascade,
	CONSTRAINT fk_HoaDon_KhachHang FOREIGN KEY (MaKH) REFERENCES KhachHang (MaKH) on delete cascade on update cascade
)
/* thêm nhân viên */
insert into NhanVien (MaNV ,MkNV, TenNV , NgaySinh , GioiTinh , DiaChi , SDT , chucvu ) values ('NV001','123',N'Nguyễn Hữu Đức','12/03/2002',1,N'Tiền Giang','0378373822',N'Quản Lý')
insert into NhanVien (MaNV ,MkNV, TenNV , NgaySinh , GioiTinh , DiaChi , SDT , chucvu ) values ('NV002','123',N'Bùi Thanh Tường','04/07/2002',1,N'Tiền Giang','0818752028',N'Nhân Viên')
/* thêm Thương Hiệu */
insert into ThuongHieu (MaTH , TenTH ) values ('SS' , N'Samsung')
insert into ThuongHieu (MaTH , TenTH ) values ('IP' , N'Apple')
insert into ThuongHieu (MaTH , TenTH ) values ('OP' , N'OPPO')
insert into ThuongHieu (MaTH , TenTH ) values ('XO' , N'Xiaomi')
insert into ThuongHieu (MaTH , TenTH ) values ('RM' , N'Realme')
insert into ThuongHieu (MaTH , TenTH ) values ('SDP', N'Sạc Dự Phòng')
/* thêm Sản Phẩm */
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP001', N'OPPO Reno7 Pro 5G' ,29990000, N'Màn hình: AMOLED6.7"Quad HD+ (2K+)' + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 12' + CHAR(13) + CHAR(10) + N'Camera sau: Chính 50 MP & Phụ 50 MP, 13 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 32 MP' + CHAR(13) + CHAR(10) + N'Chip: Snapdragon 8 Gen 1' + CHAR(13) + CHAR(10) + N'RAM: 12 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 256 GB' + CHAR(13) + CHAR(10) + N'SIM: 2 Nano SIM hoặc 1 Nano SIM  + 1 eSIM,Hỗ trợ 5G' + CHAR(13) + CHAR(10) + N'Pin, Sạc: 5000 mAh ,80 W', 'OP' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP002', N'OPPO Reno8 Pro 5G' ,17990000,N'Màn hình: AMOLED6.7"Full HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 12' + CHAR(13) + CHAR(10) + N'Camera sau: Chính 50 MP & Phụ 8 MP, 2 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 32 MP' + CHAR(13) + CHAR(10) + N'Chip:  MediaTek Dimensity 8100 Max 8 nhân' + CHAR(13) + CHAR(10) + N'RAM: 12 GB'  + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 256 GB'  + CHAR(13) + CHAR(10) + N'SIM: 2 Nano SIM,Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 4500 mAh , 80 W', 'OP' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP003', N'OPPO Reno6 Pro 5G' ,14990000,N'Màn hình: AMOLED6.55"Full HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 11' + CHAR(13) + CHAR(10) + N'Camera sau: Chính 50 MP & Phụ 16 MP, 13 MP, 2 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 32 MP' + CHAR(13) + CHAR(10) + N'Chip: Snapdragon 870 5G' + CHAR(13) + CHAR(10) + N'RAM: 12 GB'  + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 256 GB'  + CHAR(13) + CHAR(10) + N'SIM: 2 Nano SIM, Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 4500 mAh , 65 W', 'OP' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP004', N'OPPO Reno8 Z 5G' ,9490000,N'Màn hình: AMOLED6.43"Full HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 11' + CHAR(13) + CHAR(10) + N'Camera sau: Chính 64 MP & Phụ 2 MP, 2 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 16 MP' + CHAR(13) + CHAR(10) + N'Chip: Snapdragon 695 5G' + CHAR(13) + CHAR(10) + N'RAM: 8 GB'  + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 256 GB'  + CHAR(13) + CHAR(10) + N'SIM: 2 Nano SIM, Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 4500 mAh , 33 W', 'OP' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP005', N'OPPO A96' ,6490000,N'Màn hình: IPS LCD, 6.59"Full HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 11' + CHAR(13) + CHAR(10) + N'Camera sau: Chính 50 MP & Phụ 2 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 16 MP' + CHAR(13) + CHAR(10) + N'Chip: Snapdragon 680' + CHAR(13) + CHAR(10) + N'RAM: 8 GB'  + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 128 GB'  + CHAR(13) + CHAR(10) + N'SIM: 2 Nano SIM, Hỗ trợ 4G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 5000 mAh , 33 W', 'OP' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP006', N'OPPO A77s' ,6290000,N'Màn hình: IPS LCD, 6.56"Full HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 12' + CHAR(13) + CHAR(10) + N'Camera sau: Chính 64 MP & Phụ 2 MP, 2 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 8 MP' + CHAR(13) + CHAR(10) + N'Chip: Snapdragon 680' + CHAR(13) + CHAR(10) + N'RAM: 8 GB'  + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 128 GB'  + CHAR(13) + CHAR(10) + N'SIM: 2 Nano SIM, Hỗ trợ 4G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 5000 mAh , 33 W', 'OP' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP007', N'iPhone 14 Plus 128GB' ,24490000, N'Màn hình: OLED, 6.7",Super Retina XDR'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: iOS 16' + CHAR(13) + CHAR(10) + N'Camera sau: 2 camera 12MP' + CHAR(13) + CHAR(10) + N'Camera trước: 12 MP' + CHAR(13) + CHAR(10) + N'Chip: MediaTek Dimensity 900 5G' + CHAR(13) + CHAR(10) + N'RAM: 6 GB'  + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 128 GB'  + CHAR(13) + CHAR(10) + N'SIM: 1 Nano SIM & 1 eSIM, Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 4325 mAh , 20 W', 'IP' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP008', N'iPhone 13 Pro 512GB' , 24980000, N'Màn hình: OLED, 6.1", Super Retina XDR'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: iOS 15'  + CHAR(13) + CHAR(10) + N'Camera sau: 3 camera 12MP' + CHAR(13) + CHAR(10) + N'Camera trước: 12 MP' + CHAR(13) + CHAR(10) + N'Chip: MediaTek Dimensity 900 5G' + CHAR(13) + CHAR(10) + N'RAM: 6 GB'  + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 512 GB'  + CHAR(13) + CHAR(10) + N'SIM: 1 Nano SIM & 1 eSIM, Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 3095 mAh , 20 W', 'IP' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP009', N'iPhone 14 128GB' , 22990000, N'Màn hình: OLED, 6.1", Super Retina XDR'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: iOS 16'  + CHAR(13) + CHAR(10) + N'Camera sau: 2 camera 12MP' + CHAR(13) + CHAR(10) + N'Camera trước: 12 MP' + CHAR(13) + CHAR(10) + N'Chip: Apple A15 Bionic' + CHAR(13) + CHAR(10) + N'RAM: 6 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 128 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 1 Nano SIM & 1 eSIM, Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 3279 mAh , 20 W', 'IP' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP010', N'iPhone 13 mini 128GB' , 17490000, N'Màn hình: OLED, 5.4", Super Retina XDR'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: iOS 16'  + CHAR(13) + CHAR(10) + N'Camera sau: 2 camera 12MP' + CHAR(13) + CHAR(10) + N'Camera trước: 12 MP' + CHAR(13) + CHAR(10) + N'Chip: Apple A15 Bionic' + CHAR(13) + CHAR(10) + N'RAM: 4 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 128 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 1 Nano SIM & 1 eSIM, Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 2438 mAh , 20 W', 'IP' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP011', N'iPhone 14 Pro Max 256GB' , 36590000, N'Màn hình: OLED, 6.7", Super Retina XDR'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: iOS 16'  + CHAR(13) + CHAR(10) + N'Camera sau: Chính 48 MP & Phụ 12 MP, 12 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 12 MP' + CHAR(13) + CHAR(10) + N'Chip: Apple A16 Bionic' + CHAR(13) + CHAR(10) + N'RAM: 6 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 256 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 1 Nano SIM & 1 eSIM, Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 4323 mAh , 20 W', 'IP' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP012', N'iPhone SE 64GB (2022)' , 10990000, N'Màn hình: IPS LCD, 4.7",  Retina HD'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: iOS 16'  + CHAR(13) + CHAR(10) + N'Camera sau: 12 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 7 MP' + CHAR(13) + CHAR(10) + N'Chip: Apple A15 Bionic' + CHAR(13) + CHAR(10) + N'RAM: 4 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 64 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 1 Nano SIM & 1 eSIM, Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 2018 mAh , 20 W', 'IP' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP013', N'Samsung Galaxy S22 Ultra 5G' , 21990000, N'Màn hình: Dynamic AMOLED 2X6.8"Quad HD+ (2K+)'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 12'  + CHAR(13) + CHAR(10) + N'Camera sau: Chính 48 MP & Phụ 12 MP, 12 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 40 MP' + CHAR(13) + CHAR(10) + N'Chip: Apple A16 Bionic' + CHAR(13) + CHAR(10) + N'RAM: 6 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 256 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 1 Nano SIM & 1 eSIM, Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 4323 mAh , 20 W', 'SS' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP014', N'Samsung Galaxy Z Flip4 512GB' , 24990000, N'Màn hình: Chính: Dynamic AMOLED 2X, Phụ: Super AMOLEDChính 6.7" & Phụ 1.9"Full HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 12'  + CHAR(13) + CHAR(10) + N'Camera sau: Chính 108 MP & Phụ 12 MP, 10 MP, 10 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 40 MP' + CHAR(13) + CHAR(10) + N'Chip: Snapdragon 8 Gen 1' + CHAR(13) + CHAR(10) + N'RAM: 6 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 128 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 2 Nano SIM hoặc 1 Nano SIM + 1 eSIMHỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 5000 mAh, 45 W', 'SS' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP015', N'Samsung Galaxy A23 5G 4GB' , 6690000, N'Màn hình: PLS TFT, LCD6.6", Full HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 12'  + CHAR(13) + CHAR(10) + N'Camera sau: Chính 50 MP & Phụ 5 MP, 2 MP, 2MP' + CHAR(13) + CHAR(10) + N'Camera trước: 8 MP' + CHAR(13) + CHAR(10) + N'Chip: Snapdragon 680' + CHAR(13) + CHAR(10) + N'RAM: 4 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 128 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 2 Nano SIM, Hỗ trợ 4G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 5000 mAh , 25 W', 'SS' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP016', N'Samsung Galaxy Z Fold4 512GB' ,40990000, N'Màn hình: Dynamic AMOLED,  2XChính 7.6" & Phụ 6.2", Quad HD+ (2K+)'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 12'  + CHAR(13) + CHAR(10) + N'Camera sau: Chính 50 MP & Phụ 12 MP, 10 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 1 MP & 4 MP' + CHAR(13) + CHAR(10) + N'Chip: Snapdragon8+ Gen 1' + CHAR(13) + CHAR(10) + N'RAM: 12 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 512 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 1 Nano SIM & 1 eSIM, Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 4400 mAh , 25 W', 'SS' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP017', N'Samsung Galaxy S22+ 5G 128GB' ,18990000, N'Màn hình: Dynamic AMOLED  2X,  6.6",  Full HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 12'  + CHAR(13) + CHAR(10) + N'Camera sau: Chính 50 MP & Phụ 12 MP, 10 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 1 MP & 4 MP' + CHAR(13) + CHAR(10) + N'Chip: Snapdragon8+ Gen 1' + CHAR(13) + CHAR(10) + N'RAM: 8 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 128 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 2 Nano SIM hoặc 1 Nano SIM + 1 eSIM, Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 4500 mAh , 45 W', 'SS' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP018', N'Samsung Galaxy S21 FE 5G' ,12990000, N'Màn hình: Dynamic AMOLED 2X,6.4”, Full HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 12'  + CHAR(13) + CHAR(10) + N'Camera sau: Chính 12 MP & Phụ 12 MP, 8 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 32 MP' + CHAR(13) + CHAR(10) + N'Chip: Exynos 2100' + CHAR(13) + CHAR(10) + N'RAM: 8 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 128 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 2 Nano SIM, Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 4500 mAh , 25 W', 'SS' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP019', N'Samsung Galaxy M53' ,10490000, N'Màn hình: Dynamic AMOLED Plus, 6.7”, Full HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 12'  + CHAR(13) + CHAR(10) + N'Camera sau: Chính 108 MP & Phụ 8 MP, 2MP, 2MP' + CHAR(13) + CHAR(10) + N'Camera trước: 32 MP' + CHAR(13) + CHAR(10) + N'Chip: Media Tek Dimensity 900 5G' + CHAR(13) + CHAR(10) + N'RAM: 8 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 256 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 1 Nano SIM & 1 eSIM, Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 4400 mAh , 25 W', 'SS' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP020', N'Xiaomi Redmi Note 11 (6GB/128GB)' ,5090000, N'Màn hình: AMOLED, 6.43”, Full HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 11'  + CHAR(13) + CHAR(10) + N'Camera sau: Chính 50 MP & Phụ 8 MP, 2 MP, 2 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 13 MP' + CHAR(13) + CHAR(10) + N'Chip: Snapdragon 680' + CHAR(13) + CHAR(10) + N'RAM: 6 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 256 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 2 Nano SIM, Hỗ trợ 4G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 5000 mAh , 33 W', 'XO' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP021', N'Xiaomi Redmi Note 11S 5G' ,5790000, N'Màn hình: IPS LCD, 6.6”, Full HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 11'  + CHAR(13) + CHAR(10) + N'Camera sau: Chính 50 MP & Phụ 8 MP, 2 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 13 MP' + CHAR(13) + CHAR(10) + N'Chip: MediaTek Dimensity 810 5G' + CHAR(13) + CHAR(10) + N'RAM: 6 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 128 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 2 Nano SIM (SIM 2 chung khe thẻ nhớ) Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 5000 mAh , 25 W', 'XO' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP022', N'Xiaomi 12T Pro 5G' ,15990000, N'Màn hình: AMOLED, 6.67”, 1.5K'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 12'  + CHAR(13) + CHAR(10) + N'Camera sau: Chính 200 MP & Phụ 8 MP, 2 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 20 MP' + CHAR(13) + CHAR(10) + N'Chip:Snapdragon 8+ Gen 1' + CHAR(13) + CHAR(10) + N'RAM: 12 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 256 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 2 Nano SIM, Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 5000 mAh , 120 W', 'XO' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP023', N'Xiaomi 11 Lite 5G NE' ,8190000, N'Màn hình: AMOLED, 6.55”, Full HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 11'  + CHAR(13) + CHAR(10) + N'Camera sau: Chính 64 MP & Phụ 8 MP, 2 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 20 MP' + CHAR(13) + CHAR(10) + N'Chip: Snapdragon 778G 5G' + CHAR(13) + CHAR(10) + N'RAM: 8 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 128 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 2 Nano SIM (SIM 2 chung khe thẻ nhớ)Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 4250 mAh , 33 W', 'XO' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP024', N'Xiaomi Redmi 10A' ,2490000, N'Màn hình: IPS LCD, 6.53”, HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 11'  + CHAR(13) + CHAR(10) + N'Camera sau: Chính 13 MP & Phụ 8 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 5 MP' + CHAR(13) + CHAR(10) + N'Chip: MediaTek Dimensity G25' + CHAR(13) + CHAR(10) + N'RAM: 2 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 32 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 2 Nano SIM, Hỗ trợ 4G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 4250 mAh , 33 W', 'XO' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP025', N'Xiaomi 12 Pro 5G' ,15990000, N'Màn hình: AMOLED, 6.73", Quad HD+ (2K+)'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 11'  + CHAR(13) + CHAR(10) + N'Camera sau: 3 camera 50 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 32 MP' + CHAR(13) + CHAR(10) + N'Chip: Snapdragon 8 Gen 1' + CHAR(13) + CHAR(10) + N'RAM: 12 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 256 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 2 Nano SIM, Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 4600 mAh , 120 W', 'XO' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP026', N'Xiaomi Redmi Note 11C 128GB' ,13990000, N'Màn hình: AMOLED, 6.55”, Full HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 11'  + CHAR(13) + CHAR(10) + N'Camera sau: Chính 64 MP & Phụ 8 MP, 2 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 20 MP' + CHAR(13) + CHAR(10) + N'Chip: Snapdragon 778G 5G' + CHAR(13) + CHAR(10) + N'RAM: 8 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 128 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 2 Nano SIM (SIM 2 chung khe thẻ nhớ)Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 4250 mAh , 33 W', 'XO' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP027', N'Xiaomi Redmi 9C (4GB/128GB)' ,3290000, N'Màn hình: AMOLED, 6.67”, 1.5K'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 12'  + CHAR(13) + CHAR(10) + N'Camera sau: Chính 200 MP & Phụ 8 MP, 2 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 20 MP' + CHAR(13) + CHAR(10) + N'Chip:Snapdragon 8+ Gen 1' + CHAR(13) + CHAR(10) + N'RAM: 4 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 256 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 2 Nano SIM, Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 5000 mAh , 120 W', 'XO' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP028', N'Samsung Galaxy M53' ,6290000, N'Màn hình: IPS LCD, 6.5”, Full HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 11'  + CHAR(13) + CHAR(10) + N'Camera sau: Chính 48 MP & Phụ 2 MP, 2MP' + CHAR(13) + CHAR(10) + N'Camera trước: 16 MP' + CHAR(13) + CHAR(10) + N'Chip: MediaTek Dimensity 700' + CHAR(13) + CHAR(10) + N'RAM: 8 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 128 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 2 Nano SIM, Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 4400 mAh , 25 W', 'RM' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP029', N'Realme C11 (2021)' ,2900000, N'Màn hình: Dynamic AMOLED Plus, 6.7”, Full HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 10'  + CHAR(13) + CHAR(10) + N'Camera sau: Chính 108 MP & Phụ 8 MP, 2MP, 2MP' + CHAR(13) + CHAR(10) + N'Camera trước: 32 MP' + CHAR(13) + CHAR(10) + N'Chip: Media Tek Dimensity 900 5G' + CHAR(13) + CHAR(10) + N'RAM: 2 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 256 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 1 Nano SIM & 1 eSIM, Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 4400 mAh , 25 W', 'RM' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP030', N'Realme C33 ( 3GB/32GB)' ,3290000, N'Màn hình: IPS LCD, 6.5”, HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 10'  + CHAR(13) + CHAR(10) + N'Camera sau: 5 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 10 MP' + CHAR(13) + CHAR(10) + N'Chip: Unisoc Tiger R612' + CHAR(13) + CHAR(10) + N'RAM: 3 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 32 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 1 Nano SIM & 1 eSIM'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 4400 mAh , 25 W', 'RM' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP031', N'Realme 9i (4G/64GB)' ,50990000, N'Màn hình: IPS LCD, 6.53”, HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 12'  + CHAR(13) + CHAR(10) + N'Camera sau: 15 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 1 MP & 4 MP' + CHAR(13) + CHAR(10) + N'Chip: MediaTek Dimensity G25' + CHAR(13) + CHAR(10) + N'RAM: 3 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 32 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 1 Nano SIM & 1 eSIM'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 4400 mAh , 25 W', 'RM' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP032', N'Realme 9 Pro 5G' ,8290000, N'Màn hình: IPS LCD, 6.6”, Full HD+'  + CHAR(13) + CHAR(10) + N'Hệ điều hành: Android 12'  + CHAR(13) + CHAR(10) + N'Camera sau: Chính 64 MP & Phụ 8 MP, 2 MP' + CHAR(13) + CHAR(10) + N'Camera trước: 16 MP' + CHAR(13) + CHAR(10) + N'Chip: Snapdragon 695 5G' + CHAR(13) + CHAR(10) + N'RAM: 6 GB' + CHAR(13) + CHAR(10) + N'Dung lượng lưu trữ: 128 GB'  + CHAR(13) + CHAR(10) +  N'SIM: 2 Nano SIM (SIM 2 chung thẻ nhớ), Hỗ trợ 5G'  + CHAR(13) + CHAR(10) + N'Pin, Sạc: 5000 mAh, 33 W', 'RM' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP033', N'Pin sạc dự phòng Polymer 10.000 mAh' ,300000, N'Hiệu suất sạc: 65%'  + CHAR(13) + CHAR(10) + N'Dung lượng pin: 10.000 mAh'  + CHAR(13) + CHAR(10) + N'Nguồn vào: Type-C: 5V - 3AMicro USB: 5V - 2A' + CHAR(13) + CHAR(10) + N'Nguồn ra: Type-C: 5V - 3AUSB: 5V - 2.4A' + CHAR(13) + CHAR(10) + N'Trọng lượng: 210g', 'SDP' )
insert into SanPham (MaSP , TenSP ,Gia , MotaSP, MaTH) values ('SP034', N'Pin sạc dự phòng Polymer 15.000 mAh' ,540000, N'Hiệu suất sạc: 65%'  + CHAR(13) + CHAR(10) + N'Dung lượng pin: 15.000 mAh'  + CHAR(13) + CHAR(10) + N'Nguồn vào: Type C: 5V - 3A, 9V - 2A ,Micro USB: 5V - 2A, 9V - 2A' + CHAR(13) + CHAR(10) + N'Nguồn ra: Type-C: 5V - 3AUSB: 5V - 2.4A' + CHAR(13) + CHAR(10) + N'Trọng lượng: 330g', 'SDP' )

--Khách Hàng Demo
insert into KhachHang (MaKH , TenKH , DiaChi , SDT ) values ('KH001' , N'Phùng Thị Lệ Nguyệt' , N'Bến Tre' , '03122590564')
insert into KhachHang (MaKH , TenKH , DiaChi , SDT ) values ('KH002' , N'Chu Khắc Tuấn' , N'Long An' , '06189201694')
insert into KhachHang (MaKH , TenKH , DiaChi , SDT ) values ('KH003' , N'Dương Kim Mỹ' , N'Tiền Giang' , '09404541731')
insert into KhachHang (MaKH , TenKH , DiaChi , SDT ) values ('KH004' , N'Đặng Cẩm Tiết' , N'Tiền Giang' , '05153869514')
insert into KhachHang (MaKH , TenKH , DiaChi , SDT ) values ('KH005' , N'Phùng Thị Lệ Nguyệt' , N'TP.HCM' , '03057986504')

--Hóa Đơn Demo
insert into GioHang ([MaGH],[NgayBan],[TongSoLuong],[TongTien]) values ('GH001','10/10/2022',1,29990000)
insert into SPMua([Stt],[SoLuong],[MaGH],[MaSP]) values (1,1,'GH001','SP001')
insert into HoaDon (MaHD , MaGH , MaKH , MaNV , TrangThai) values ('HD001','GH001','KH001','NV001',N'Chưa Thanh Toán')

--Hóa Đơn Demo
insert into GioHang ([MaGH],[NgayBan],[TongSoLuong],[TongTien]) values ('GH002','12/22/2022',2,5800000)
insert into SPMua([Stt],[SoLuong],[MaGH],[MaSP]) values (1,2,'GH002','SP029')
insert into HoaDon (MaHD , MaGH , MaKH , MaNV , TrangThai) values ('HD002','GH002','KH002','NV001',N'Chưa Thanh Toán')

--Hóa Đơn Demo
insert into GioHang ([MaGH],[NgayBan],[TongSoLuong],[TongTien]) values ('GH003','12/15/2022',2,41290000)
insert into SPMua([Stt],[SoLuong],[MaGH],[MaSP]) values (1,1,'GH003','SP016')
insert into SPMua([Stt],[SoLuong],[MaGH],[MaSP]) values (2,1,'GH003','SP033')
insert into HoaDon (MaHD , MaGH , MaKH , MaNV , TrangThai) values ('HD003','GH003','KH003','NV002',N'Chưa Thanh Toán')

--Hóa Đơn Demo
insert into GioHang ([MaGH],[NgayBan],[TongSoLuong],[TongTien]) values ('GH004','12/10/2022',2,23780000)
insert into SPMua([Stt],[SoLuong],[MaGH],[MaSP]) values (1,1,'GH004','SP010')
insert into SPMua([Stt],[SoLuong],[MaGH],[MaSP]) values (2,1,'GH004','SP006')
insert into HoaDon (MaHD , MaGH , MaKH , MaNV , TrangThai) values ('HD004','GH004','KH004','NV001',N'Chưa Thanh Toán')

--Hóa Đơn Demo
insert into GioHang ([MaGH],[NgayBan],[TongSoLuong],[TongTien]) values ('GH005','12/25/2022',1,24999000)
insert into SPMua([Stt],[SoLuong],[MaGH],[MaSP]) values (1,1,'GH005','SP014')
insert into HoaDon (MaHD , MaGH , MaKH , MaNV , TrangThai) values ('HD005','GH005','KH005','NV002',N'Chưa Thanh Toán')
