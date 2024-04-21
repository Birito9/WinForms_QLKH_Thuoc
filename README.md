# WinForms_QLKH_Thuoc
1.	Cài đặt Visual Studio 2022: Video hướng dẫn Download Visual Studio 2022
2.	Cài đặt .NET Framework 3.5 và .NET 6.0: Video hướng dẫn Download .NET
3.	Cài đặt SQL Server: Video hướng dẫn Download SQL Server
4.	Vào link Github: WinForms_QLKH_Thuoc, copy đường dẫn Code sau: 
5.	Mở Git Bash trên Desktop, gõ 
"git clone https://github.com/Birito9/WinForms_QLKH_Thuoc.git" và Enter. Chờ clone hoàn tất sẽ xuất hiện thư mục "WinForms_QLKH_Thuoc" như sau:

   
![image](https://github.com/Birito9/WinForms_QLKH_Thuoc/assets/117338757/bf198d32-2ae5-4526-bc78-8e61bfb46cd0)

6. Nhấn vào tệp "QLKH_Thuoc.sql", Connect vào tài khoản "Windows Authentication" trong SQL Server và cho "Execute" toàn bộ tệp "QLKH_Thuoc.sql" để tạo Database
7. Nhấn vào tệp "WinForms_QLKH_Thuoc.sln", vào Visual Studio chỉnh ngay nút "Start"

![z5069067047988_786971ce2f32e1bb474213c1b820ad44](https://github.com/hongan1522/WinForms_QLKH_Thuoc/assets/95673805/573be5c6-7a4b-48e7-a5e9-43e909b7935e)

Nhấn vào "Configure Startup Projects..." -> chọn "Multiple Startup Projects" -> đặt Action hai project "FromQLKH", "WebAPI_QLKH" là "Start"

8. Trong file "appsetting.json" ở project "WebAPI_QLKH", thay đổi đường dẫn liên kết tới cơ sở dữ liệu MyConnection: "Data Source = Tên Sever Name SQL Server của bạn;"
9. Xong các bước trên thì bạn có thể chạy ứng dụng

Tài khoản test:
| Vai trò   | UserName | Password |
| :---------| :-------:|---------:|
| Admin     | User1    | @dmin    |
| Nhân viên | User2    | 123      |



 
